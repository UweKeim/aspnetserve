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

namespace aspNETserve.Core.Logging {
    public static class Logger {
        private static event LogExceptionEventHandler _logExceptionEvent;
        private static event LogMessageEventHandler _logMessageEvent;

        public static void LogException(LogLevel level, string message, Exception ex) {
            if (_logExceptionEvent != null)
                _logExceptionEvent(level, message, ex);
        }

        public static void LogException(LogLevel level, Exception ex) {
            LogException(level, string.Empty, ex);
        }

        public static void LogMessage(LogLevel level, string message) {
            if (_logMessageEvent != null)
                _logMessageEvent(level, message);
        }

        public static event LogExceptionEventHandler LogExceptionEvent {
            add { _logExceptionEvent += value; }
            remove { _logExceptionEvent -= value; }
        }

        public static event LogMessageEventHandler LogMessageEvent {
            add { _logMessageEvent += value; }
            remove { _logMessageEvent -= value; }
        }
    }
}
