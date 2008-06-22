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
        public void GetAppPath_Test() {
            MockRepository mocks = new MockRepository();
            string virtualPath = @"/";

            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, virtualPath, @"z:\temp");

            Assert.AreEqual(virtualPath, aspNetWorker.GetAppPath());
        }
    }
}
