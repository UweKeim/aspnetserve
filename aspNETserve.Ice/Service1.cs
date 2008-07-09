using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace aspNETserve.Ice {
    public partial class Service1 : ServiceBase {
        public Service1() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
        }

        protected override void OnStop() {
        }
    }
}
