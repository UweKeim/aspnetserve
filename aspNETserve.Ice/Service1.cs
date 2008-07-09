/************************************************************************
 * Copyright (c) 2006-2008, Jason Whitehorn (jason.whitehorn@gmail.com)
 * All rights reserved.
 * 
 * Source code and binaries distributed under the terms of the included
 * license, see license.txt for details.
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using System.Text;
using aspNETserve;

namespace aspNETserve.Ice {
    public partial class Service1 : ServiceBase {
        private IServer _server = new Server(IPAddress.Any, "/", @"C:\webroot", 8081);
        
        public Service1() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            _server.Start();
        }

        protected override void OnStop() {
            _server.Stop();
        }

        protected void CycleServer() {
            OnStop();
            OnStart(null);
        }
    }
}
