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

        [Test]
        [Description("Determines that the GetBytesRead method returns the number of bytes read from the IRequest")]
        public void GetBytesRead_When_Bytes_Read_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();
            byte[] postData = new byte[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

            using(mocks.Unordered()) {
                Expect.Call(request.PostData).Return(postData).Repeat.Any();
                Expect.Call(request.RawUrl).Return("/test/").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); } ).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual(postData.Length, aspNetWorker.GetBytesRead());

        }

        [Test]
        [Description("Determines that the GetBytesRead method returns the number of bytes read from the IRequest")]
        public void GetBytesRead_When_No_Bytes_Read_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();
            byte[] postData = new byte[] { };

            using (mocks.Unordered()) {
                Expect.Call(request.PostData).Return(postData).Repeat.Any();
                Expect.Call(request.RawUrl).Return("/test/").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); }).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual(postData.Length, aspNetWorker.GetBytesRead());

        }

        [Test]
        [Description("Determines that GetConnectionID allows returns zero.")]
        public void GetConnectionID_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");
            Assert.AreEqual(0, aspNetWorker.GetConnectionID());
            
        }

        [Test]
        [Description("Determines that the GetFilePath correctly returns the file path for a folder request.")]
        public void GetFilePath_For_Root_Folder_Path_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();

            using (mocks.Unordered()) {
                Expect.Call(request.RawUrl).Return("/test/").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); }).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual("/test/", aspNetWorker.GetFilePath());
        }

        [Test]
        [Description("Determines that the GetFilePath correctly returns the file path for a folder request.")]
        public void GetFilePath_For_Root_Page_Path_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();

            using (mocks.Unordered()) {
                Expect.Call(request.RawUrl).Return("/test/Test.aspx").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); }).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual("/test/Test.aspx", aspNetWorker.GetFilePath());
        }

        [Test]
        [Description("Determines that the GetFilePath correctly returns the file path for a folder request.")]
        public void GetFilePath_For_Non_Root_Folder_Path_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();

            using (mocks.Unordered()) {
                Expect.Call(request.RawUrl).Return("/test/").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); }).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/foo", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual("/test/", aspNetWorker.GetFilePath());
        }

        [Test]
        [Description("Determines that the GetFilePath correctly returns the file path for a folder request.")]
        public void GetFilePath_For_Non_Root_Page_Path_Test() {
            MockRepository mocks = new MockRepository();
            IAspNetRuntime aspNetRuntime = mocks.CreateMock<IAspNetRuntime>();
            ITransaction transaction = mocks.CreateMock<ITransaction>();
            IResponse response = mocks.CreateMock<IResponse>();
            IRequest request = mocks.CreateMock<IRequest>();

            using (mocks.Unordered()) {
                Expect.Call(request.RawUrl).Return("/test/Test.aspx").Repeat.Any();
                Expect.Call(transaction.Request).Return(request).Repeat.Any();
                Expect.Call(transaction.Response).Return(response).Repeat.Any();
                Expect.Call(delegate { aspNetRuntime.ProcessRequest(null); }).IgnoreArguments();
            }
            mocks.ReplayAll();

            AspNetWorker aspNetWorker = new AspNetWorker(aspNetRuntime, "/foo", @"c:\temp");

            aspNetWorker.ProcessTransaction(transaction);
            Assert.AreEqual("/test/Test.aspx", aspNetWorker.GetFilePath());
        }
    }
}
