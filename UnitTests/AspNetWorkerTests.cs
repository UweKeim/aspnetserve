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
using aspNETserve.Core;
using NUnit.Framework;
using Rhino.Mocks;

namespace UnitTests {
    [TestFixture]
    public class AspNetWorkerTests {

        [Test]
        [Description("Determines that the GetAppPath method of the AspNetWorker IAspNetWorker implementation returns the virtual path provided on the constructor.")]
        public void GetAppPath_When_Virtual_Path_Is_Root_Test() {
            MockRepository mocks = new MockRepository();
            string virtualPath = @"/";

            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, virtualPath, @"z:\temp");

            Assert.AreEqual(virtualPath, aspNetWorker.GetAppPath());
        }

        [Test]
        [Description("Determines that the GetAppPath method of the AspNetWorker IAspNetWorker implementation returns the virtual path provided on the constructor.")]
        public void GetAppPath_When_Virtual_Path_Is_Complex_Test() {
            MockRepository mocks = new MockRepository();
            string virtualPath = @"/foo";

            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, virtualPath, @"z:\temp");

            Assert.AreEqual(virtualPath, aspNetWorker.GetAppPath());
        }

        [Test]
        [Description("Determines that the GetAppPathTranslated method returns the physical path as passed on AspNetWorker's constructor.")]
        public void GetAppPathTranslated_Test() {
            MockRepository mocks = new MockRepository();
            string physicalPath = @"c:\temp";

            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", physicalPath);

            Assert.AreEqual(physicalPath, aspNetWorker.GetAppPathTranslated());
        }

        [Test]
        [Description("Determines that the GetAppPoolID method returns teh ID of the AppDomain that the worker process resides in.")]
        public void GetAppPoolID_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");

            Assert.AreEqual(AppDomain.CurrentDomain.Id.ToString(), aspNetWorker.GetAppPoolID());
            
        }
    }
}
