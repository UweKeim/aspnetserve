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
using System.Threading;
using aspNETserve.Configuration;

namespace aspNETserve {
    /// <summary>
    /// An implementation of IServer that provides asynchronous operations.
    /// </summary>
    public class AsyncServer : Server, IAsyncServer {
        private EventHandler _serverRunning;
        private EventHandler _failureStarting;

        public AsyncServer(IPAddress endPoint, string virtualDir, string physicalDir, int port)
            : base(endPoint, virtualDir, physicalDir, port) { }

        public AsyncServer(IApplication application) : base(application) {}

        public virtual void StartAsync() {
            bool queued = ThreadPool.QueueUserWorkItem(
                    delegate(object o) {
                        try {
                            Start();
                        } catch { } //this needs to be supressed in this context
                    });
            if (!queued)
                throw new ApplicationException("Error starting");
        }

        public virtual event EventHandler ServerRunning {
            add { _serverRunning += value; }
            remove { _serverRunning -= value; }
        }

        public virtual event EventHandler FailureStarting {
            add { _failureStarting += value; }
            remove { _failureStarting -= value; }
        }

        protected override void SetStatus(ServerStatus status) {
            ServerStatus previousStatus = Status;
            base.SetStatus(status);

            if (Status == ServerStatus.Running && _serverRunning != null)
                _serverRunning(this, EventArgs.Empty);

            if (previousStatus == ServerStatus.Starting && Status == ServerStatus.Stopped && _failureStarting != null)
                _failureStarting(this, EventArgs.Empty);
        }
    }
}
