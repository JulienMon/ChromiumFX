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


// cef_load_handler

typedef struct _cfx_load_handler_t {
    cef_load_handler_t cef_load_handler;
    unsigned int ref_count;
    gc_handle_t gc_handle;
    // managed callbacks
    void (CEF_CALLBACK *on_loading_state_change)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, int isLoading, int canGoBack, int canGoForward);
    void (CEF_CALLBACK *on_load_start)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, cef_transition_type_t transition_type);
    void (CEF_CALLBACK *on_load_end)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, int httpStatusCode);
    void (CEF_CALLBACK *on_load_error)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, cef_errorcode_t errorCode, char16 *errorText_str, int errorText_length, char16 *failedUrl_str, int failedUrl_length);
} cfx_load_handler_t;

void CEF_CALLBACK _cfx_load_handler_add_ref(struct _cef_base_t* base) {
    int count = InterlockedIncrement(&((cfx_load_handler_t*)base)->ref_count);
    if(count == 2) {
        ((cfx_load_handler_t*)base)->gc_handle = cfx_gc_handle_switch(((cfx_load_handler_t*)base)->gc_handle, count);
    }
}
int CEF_CALLBACK _cfx_load_handler_release(struct _cef_base_t* base) {
    int count = InterlockedDecrement(&((cfx_load_handler_t*)base)->ref_count);
    if(count == 1) {
        ((cfx_load_handler_t*)base)->gc_handle = cfx_gc_handle_switch(((cfx_load_handler_t*)base)->gc_handle, count);
    } else if(!count) {
        cfx_gc_handle_free(((cfx_load_handler_t*)base)->gc_handle);
        free(base);
        return 1;
    }
    return 0;
}
int CEF_CALLBACK _cfx_load_handler_has_one_ref(struct _cef_base_t* base) {
    return ((cfx_load_handler_t*)base)->ref_count == 1 ? 1 : 0;
}

static cfx_load_handler_t* cfx_load_handler_ctor(gc_handle_t gc_handle) {
    cfx_load_handler_t* ptr = (cfx_load_handler_t*)calloc(1, sizeof(cfx_load_handler_t));
    if(!ptr) return 0;
    ptr->cef_load_handler.base.size = sizeof(cef_load_handler_t);
    ptr->cef_load_handler.base.add_ref = _cfx_load_handler_add_ref;
    ptr->cef_load_handler.base.release = _cfx_load_handler_release;
    ptr->cef_load_handler.base.has_one_ref = _cfx_load_handler_has_one_ref;
    ptr->ref_count = 1;
    ptr->gc_handle = gc_handle;
    return ptr;
}

static gc_handle_t cfx_load_handler_get_gc_handle(cfx_load_handler_t* self) {
    return self->gc_handle;
}

// on_loading_state_change

void CEF_CALLBACK cfx_load_handler_on_loading_state_change(cef_load_handler_t* self, cef_browser_t* browser, int isLoading, int canGoBack, int canGoForward) {
    int _release_browser;
    ((cfx_load_handler_t*)self)->on_loading_state_change(((cfx_load_handler_t*)self)->gc_handle, browser, &_release_browser, isLoading, canGoBack, canGoForward);
    if(_release_browser) browser->base.release((cef_base_t*)browser);
}

// on_load_start

void CEF_CALLBACK cfx_load_handler_on_load_start(cef_load_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_transition_type_t transition_type) {
    int _release_browser;
    int _release_frame;
    ((cfx_load_handler_t*)self)->on_load_start(((cfx_load_handler_t*)self)->gc_handle, browser, &_release_browser, frame, &_release_frame, transition_type);
    if(_release_browser) browser->base.release((cef_base_t*)browser);
    if(_release_frame) frame->base.release((cef_base_t*)frame);
}

// on_load_end

void CEF_CALLBACK cfx_load_handler_on_load_end(cef_load_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, int httpStatusCode) {
    int _release_browser;
    int _release_frame;
    ((cfx_load_handler_t*)self)->on_load_end(((cfx_load_handler_t*)self)->gc_handle, browser, &_release_browser, frame, &_release_frame, httpStatusCode);
    if(_release_browser) browser->base.release((cef_base_t*)browser);
    if(_release_frame) frame->base.release((cef_base_t*)frame);
}

// on_load_error

void CEF_CALLBACK cfx_load_handler_on_load_error(cef_load_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_errorcode_t errorCode, const cef_string_t* errorText, const cef_string_t* failedUrl) {
    int _release_browser;
    int _release_frame;
    ((cfx_load_handler_t*)self)->on_load_error(((cfx_load_handler_t*)self)->gc_handle, browser, &_release_browser, frame, &_release_frame, errorCode, errorText ? errorText->str : 0, errorText ? (int)errorText->length : 0, failedUrl ? failedUrl->str : 0, failedUrl ? (int)failedUrl->length : 0);
    if(_release_browser) browser->base.release((cef_base_t*)browser);
    if(_release_frame) frame->base.release((cef_base_t*)frame);
}

static void cfx_load_handler_set_callback(cef_load_handler_t* self, int index, void* callback) {
    switch(index) {
    case 0:
        ((cfx_load_handler_t*)self)->on_loading_state_change = (void (CEF_CALLBACK *)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, int isLoading, int canGoBack, int canGoForward))callback;
        self->on_loading_state_change = callback ? cfx_load_handler_on_loading_state_change : 0;
        break;
    case 1:
        ((cfx_load_handler_t*)self)->on_load_start = (void (CEF_CALLBACK *)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, cef_transition_type_t transition_type))callback;
        self->on_load_start = callback ? cfx_load_handler_on_load_start : 0;
        break;
    case 2:
        ((cfx_load_handler_t*)self)->on_load_end = (void (CEF_CALLBACK *)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, int httpStatusCode))callback;
        self->on_load_end = callback ? cfx_load_handler_on_load_end : 0;
        break;
    case 3:
        ((cfx_load_handler_t*)self)->on_load_error = (void (CEF_CALLBACK *)(gc_handle_t self, cef_browser_t* browser, int *_release_browser, cef_frame_t* frame, int *_release_frame, cef_errorcode_t errorCode, char16 *errorText_str, int errorText_length, char16 *failedUrl_str, int failedUrl_length))callback;
        self->on_load_error = callback ? cfx_load_handler_on_load_error : 0;
        break;
    }
}

