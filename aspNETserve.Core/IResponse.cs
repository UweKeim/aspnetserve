/************************************************************************
 * Copyright (c) 2006-2008, Jason Whitehorn (jason.whitehorn@gmail.com)
 * All rights reserved.
 * 
 * Source code and binaries distributed under the terms of the included
 * license, see license.txt for details.
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace aspNETserve.Core {

    public interface IResponse {

        int StatusCode { get; set; }
        string StatusDescription { get; set; }
        byte[] RawData { get; set; }
        string MimeType { get; set; }
        byte[] ToHttpResponse();
        void SendKnownResponseHeader(int index, string value);
        void SendUnknownResponseHeader(string name, string value);
    }
}
