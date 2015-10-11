_This page is part of the ApiReferenceGuide._

# Introduction #

Creating an embedded server using aspNETserve involves only a few lines of code.


### Sample 1 ###

Sample 1 is perhaps the simplist of console web servers. This particular server is so simple because it does not accept user inputs for its configurations, those are simply hard coded.

###### C# ######
```
using System;
using System.Collections.Generic;
using System.Text;
using aspNETserve;

namespace ConsoleWebServer {
    class Program {
        static void Main(string[] args) {
            string physicalPath = "c:\\wwwroot";
            int port = 8080;
            using (Server s = new Server(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), "/", physicalPath, port)) {
                s.Start();
                Console.WriteLine("Press any key to stop the server");
                Console.ReadKey();
                s.Stop();
            }
        }
    }
}
```
###### VB.NET ######
```
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports aspNETserve
 
Namespace ConsoleWebServer
    Class Program
        Shared  Sub Main(ByVal args() As String)
            Dim physicalPath As String =  "c:\\wwwroot" 
            Dim port As Integer =  8080 
            Imports (Server s = New Server(New System.Net.IPAddress(New Byte() { 127, 0, 0, 1 }), "/", physicalPath, port)) {
                s.Start()
                Console.WriteLine("Press any key to stop the server")
                Console.ReadKey()
                s.Stop()
        End Sub
    End Class
End Namespace
```

The ServerObject is the core component for any embedded server. It is this object that represents the instance of aspNETserve hosted within your own application.

### Sample 2 ###
The second sample of a console based embedded web server is actually part of the official aspNETserve code base. The ConsoleServer project contains the following code:
```
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
using aspNETserve;

namespace ConsoleServer {
    class Program {
        /* NOTE:
         * This is only intended to be an example of a web server.
         * It is not intended to be a serious implementation, and as
         * such is lacking user input validation.
         */ 
        static void Main(string[] args) {
            Console.WriteLine("aspNETserve console server");
            Console.Write("IP: ");
            string rawIp = Console.ReadLine();
            Console.Write("Port: ");
            string port = Console.ReadLine();
            Console.Write("Physical Path: ");
            string physicalPath = Console.ReadLine();
            Console.Write("Virtual Path: ");
            string virtualPath = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Starting...");
            System.Net.IPAddress endPoint = System.Net.IPAddress.Parse(rawIp);
            using (Server s = new Server(endPoint, virtualPath, physicalPath, int.Parse(port))) {
                s.Start();
                Console.WriteLine("DONE");
                Console.Write("Press any key to stop");
                Console.Read();
            }
        }
    }
}
```
The latest versions of the above code can be viewed @ http://code.google.com/p/aspnetserve/source/browse/trunk/ConsoleServer/Program.cs