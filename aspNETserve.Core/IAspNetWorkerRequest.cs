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
    /// <summary>
    /// An IAspNetWorker does all the dirty work
    /// of handling a request, and generating a response.
    /// </summary>
    public interface IAspNetWorker {
        void ProcessTransaction(ITransaction transaction);
        IDictionary<string, string> ServerVariables { set; get; }
    }
}
