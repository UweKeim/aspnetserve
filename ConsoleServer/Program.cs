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

            string rawIp;
            if (string.IsNullOrEmpty(args[0])) {
                rawIp = Console.ReadLine();
            }else {
                rawIp = args[0];
                Console.WriteLine(rawIp);
            }

            Console.Write("Port: ");
            string port;
            if (string.IsNullOrEmpty(args[1])) {
                port = Console.ReadLine();
            }else {
                port = args[1];
                Console.WriteLine(port);
            }

            Console.Write("Physical Path: ");
            string physicalPath;
            if (string.IsNullOrEmpty(args[2])) {
                physicalPath = Console.ReadLine();
            }else {
                physicalPath = args[2];
                Console.WriteLine(physicalPath);
            }

            Console.Write("Virtual Path: ");
            string virtualPath;
            if (string.IsNullOrEmpty(args[3])) {
                virtualPath = Console.ReadLine();
            }else {
                virtualPath = args[3];
                Console.WriteLine(virtualPath);
            }

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
