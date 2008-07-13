/************************************************************************
 * Copyright (c) 2006-2008, Jason Whitehorn (jason.whitehorn@gmail.com)
 * All rights reserved.
 * 
 * Source code and binaries distributed under the terms of the included
 * license, see license.txt for details.
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace aspNETserve.Configuration.Xml {
    public class XmlConfigurationManager {
        private static readonly XmlSchema _xmlSchema;

        static XmlConfigurationManager() {
            Assembly currentAsm = Assembly.GetExecutingAssembly();
            using (Stream s = currentAsm.GetManifestResourceStream("aspNETserve.Configuration.Xml.aspNETserve.config.xsd")) {
                _xmlSchema = XmlSchema.Read(s, null);
                s.Close();
            }
        }

        public static IApplication FromXml(Stream stream) {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(_xmlSchema);
            XmlReader xmlReader = XmlReader.Create(stream, settings);

            
            throw new NotImplementedException();
        }

    }
}
