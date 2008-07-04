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
            MemoryStream stream = GetRequestStream("GET / HTTP/1.1", "Host: Localhost", "");
            HttpRequestResponse httpRequestResponse = new HttpRequestResponse(stream, null, null);

            Assert.AreEqual(httpRequestResponse.Request.HttpMethod, "GET");
            Assert.AreEqual(httpRequestResponse.Request.RawUrl, "/");
            Assert.IsFalse(httpRequestResponse.Request.IsKeepAlive);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Error parsing request headers.")]
        public void Simple_Get_Request_Lacking_Host_Header_Test() {
            //This test should throw an exception as the Host header is required.
            //Ideally we would be able to better test for this, but for now all we
            //can do is test for the above generic exception.
            MemoryStream stream = GetRequestStream("GET / HTTP/1.1", "");
            HttpRequestResponse httpRequestResponse = new HttpRequestResponse(stream, null, null);
        }

        private MemoryStream GetRequestStream(params string[] lines) {
            MemoryStream result = new MemoryStream();
            foreach(string line in lines) {
                byte[] rawData = Encoding.ASCII.GetBytes(string.Format("{0}\r\n", line));
                result.Write(rawData, 0, rawData.Length);
            }
            result.Position = 0;
            return result;
        }
    }
}
