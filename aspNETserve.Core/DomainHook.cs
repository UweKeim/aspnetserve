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

        public void Configure(IAspNetWorkerRequest httpWorker) {
            if (IsConfigured)
                throw new Exception("The DomainHook is already configured.");
            if (httpWorker == null)
                throw new ArgumentNullException("httpWorker", "IHttpWorker cannot be null.");
            _worker = httpWorker;
        }

        public void Configure(Type t, params object[] args) {
            if(IsConfigured)
                throw new Exception("The DomainHook is already configured.");

            Type[] implementedInterfaces = t.GetInterfaces();
            bool isIHttpWorker = false;
            foreach (Type implementedInterface in implementedInterfaces) {
                if (implementedInterface == typeof(IAspNetWorkerRequest))
                    isIHttpWorker = true;
            }

            if (!isIHttpWorker)
                throw new Exception("Type does not implement IHttpWorker");

            _worker = (IAspNetWorkerRequest)Activator.CreateInstance(t, args);
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
