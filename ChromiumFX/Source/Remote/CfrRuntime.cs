// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



using System;
using System.Collections.Generic;
using System.Threading;

namespace Chromium.Remote {
    /// <summary>
    /// Collection of global static CEF functions acessible in the render process.
    /// </summary>
    public partial class CfrRuntime {

        internal readonly RemoteConnection connection;

        internal CfrRuntime(RemoteConnection connection) {
            this.connection = connection;
            this.Marshal = new CfrMarshal(connection);
        }


        /// <summary>
        /// Provides access to the remote process unmanaged memory.
        /// </summary>
        public CfrMarshal Marshal { get; private set; }


        /// <summary>
        /// This function should be called from the render process startup callback
        /// provided to CfxRuntime.Initialize() in the browser process. It will
        /// call into the render process passing in the provided |application| 
        /// object and block until the render process exits. 
        /// The |application| object will receive CEF framework callbacks 
        /// from within the render process.
        /// </summary>
        public int ExecuteProcess(CfrApp application) {
            var call = new CfxRuntimeExecuteProcessRenderProcessCall();
            call.application = CfrObject.Unwrap(application);
            // Looks like this almost never returns with a value
            // from the call into the render process. Probably the
            // IPC connection doesn't get a chance to send over the
            // return value from CfxRuntime.ExecuteProcess() when the
            // render process exits. So we don't throw an exception but
            // use a return value of -2 to indicate connection lost.
            try {
                call.Execute();
                return call.__retval;
            } catch(CfxException) {
                return -2;
            }
        }

        [ThreadStatic]
        private static Stack<CfrRuntime> m_contextStack;
        private static Stack<CfrRuntime> contextStack {
            get {
                if(m_contextStack == null) m_contextStack = new Stack<CfrRuntime>();
                return m_contextStack;
            }
        }

        /// <summary>
        /// Enter the thread-local context of this remote runtime. Unless within the scope of a 
        /// remote callback event, a context must be explicitly entered before calling 
        /// constructors like new CfrTask() or static members like CfrTaskRunner.GetForThread() 
        /// or CfrV8Value.Create*() on remote (Cfr*) classes. Within the scope of a remote callback 
        /// event, the executing thread is always in the context of the event's remote runtime.
        /// 
        /// Calls to EnterContext/ExitContext must be balanced. Use try/finally constructs
        /// to make sure that ExitContext() is called the same number of times as EnterContext().
        /// </summary>
        public void EnterContext() {
            contextStack.Push(this);
        }

        /// <summary>
        /// Exit the thread-local context of this remote runtime. Throws an exception if the 
        /// calling thread is not currently in the context of this remote runtime.
        /// </summary>
        public void ExitContext() {
            var s = contextStack;
            if(s.Count == 0 || this != s.Peek())
                throw new CfxException("The calling thread is not currently in the context of this remote runtime");
            contextStack.Pop();
        }

        /// <summary>
        /// Returns the remote runtime context for the calling thread. Throws an exception if the 
        /// calling thread is not currently in the context of a remote runtime.
        /// </summary>
        public static CfrRuntime CurrentContext {
            get {
                var s = contextStack;
                if(s.Count > 0)
                    return s.Peek();
                else
                    throw new CfxException("The calling thread is not currently in the context of a remote runtime");
            }
        }

        /// <summary>
        /// True if the calling thread is currently in the context of a remote runtime, false otherwise.
        /// </summary>
        public static bool IsInContext {
            get {
                return contextStack.Count > 0;
            }
        }

        internal static int ContextStackCount {
            get {
                return contextStack.Count;
            }
        }

        internal static void ResetContextStackTo(int count) {
            while(contextStack.Count > count)
                contextStack.Pop();
        }
    }
}
