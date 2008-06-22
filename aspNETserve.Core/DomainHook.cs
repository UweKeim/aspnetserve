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
using System.Net;
using System.Web;
using System.Threading;
using System.Web.Hosting;
using System.Diagnostics;

namespace aspNETserve.Core {
    /// <summary>
    /// The DomainHook acts as a known point of contact for the Server into the Hosting 
    /// AppDomain.
    /// </summary>
    public sealed class DomainHook : MarshalByRefObject, IRegisteredObject, IDisposable {
        private IAspNetWorkerRequest _worker = null;

        public DomainHook() {
            HostingEnvironment.RegisterObject(this);
        }

        public override object InitializeLifetimeService() {
            return null;
        }

        public void Stop(bool immediate) {
            HostingEnvironment.UnregisterObject(this);
        }

        public void Dispose() {
            HostingEnvironment.InitiateShutdown();
        }

        public void Configure(string virtualDir, string physicalDir, IDictionary<string, string> serverVariables) {
            if(IsConfigured)
                throw new Exception("The DomainHook is already configured.");

            AspNetWorker aspNetEngine = new AspNetWorker();

            _worker = new AspNetWorkerRequest(aspNetEngine, virtualDir, physicalDir, serverVariables);
        }

        public void ProcessTransaction(ITransaction transaction) {
            /*
             * This method is the primary reason for the DomainHook to exist.
             */
            if(!IsConfigured)
                throw new Exception("DomainHook has not yet been configured.");
            _worker.ProcessTransaction(transaction);
        }

        private bool IsConfigured {
            get { return _worker != null; }
        }
    }
}
