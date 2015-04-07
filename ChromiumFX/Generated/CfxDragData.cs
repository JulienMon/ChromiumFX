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

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent drag data. The functions of this structure may be
    /// called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
    /// </remarks>
    public class CfxDragData : CfxBase {

        static CfxDragData () {
            CfxApiLoader.LoadCfxDragDataApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxDragData Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxDragData)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxDragData(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxDragData(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns true (1) if the drag data is a link.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsLink {
            get {
                return 0 != CfxApi.cfx_drag_data_is_link(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the drag data is a text or html fragment.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsFragment {
            get {
                return 0 != CfxApi.cfx_drag_data_is_fragment(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the drag data is a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsFile {
            get {
                return 0 != CfxApi.cfx_drag_data_is_file(NativePtr);
            }
        }

        /// <summary>
        /// Return the link URL that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_link_url(NativePtr));
            }
        }

        /// <summary>
        /// Return the title associated with the link being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkTitle {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_link_title(NativePtr));
            }
        }

        /// <summary>
        /// Return the metadata, if any, associated with the link being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkMetadata {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_link_metadata(NativePtr));
            }
        }

        /// <summary>
        /// Return the plain text fragment that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_fragment_text(NativePtr));
            }
        }

        /// <summary>
        /// Return the text/html fragment that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentHtml {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_fragment_html(NativePtr));
            }
        }

        /// <summary>
        /// Return the base URL that the fragment came from. This value is used for
        /// resolving relative URLs and may be NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentBaseUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_fragment_base_url(NativePtr));
            }
        }

        /// <summary>
        /// Return the name of the file being dragged out of the browser window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FileName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_drag_data_get_file_name(NativePtr));
            }
        }

        /// <summary>
        /// Retrieve the list of file names that are being dragged into the browser
        /// window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool GetFileNames(System.Collections.Generic.List<string> names) {
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            var __retval = CfxApi.cfx_drag_data_get_file_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.cfx_string_list_free(names_unwrapped);
            return 0 != __retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
