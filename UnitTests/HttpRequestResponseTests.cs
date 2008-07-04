using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using aspNETserve;
using NUnit.Framework;

namespace UnitTests {
    [TestFixture]
    public class HttpRequestResponseTests {

        [Test]
        public void Simple_Get_Request_Test() {
            string httpRequest =
                @"GET / HTTP/1.1
Host: Localhost

";
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(httpRequest));
            HttpRequestResponse httpRequestResponse = new HttpRequestResponse(stream, null, null);

            Assert.AreEqual(httpRequestResponse.Request.HttpMethod, "GET");
            Assert.AreEqual(httpRequestResponse.Request.RawUrl, "/");
            Assert.IsFalse(httpRequestResponse.Request.IsKeepAlive);
        }
    }
}
