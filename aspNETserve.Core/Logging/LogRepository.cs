/************************************************************************
 * Copyright (c) 2006-2008, Jason Whitehorn (jason.whitehorn@gmail.com)
 * All rights reserved.
 * 
 * Source code and binaries distributed under the terms of the included
 * license, see license.txt for details.
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace aspNETserve.Core.Logging {
    public class LogRepository {
        private Stream _backingStream;
        private bool _readOnly;

        private LogRepository(){}  //do not expose a constructor.

        public static LogRepository Connect(Stream backingStream, bool readOnly) {
            LogRepository result = new LogRepository();
            result.ReadOnly = readOnly;
            result.BackingStream = backingStream;
            return result;
        }

        protected virtual Stream BackingStream {
            get { return _backingStream; }
            set { _backingStream = value; }
        }

        public virtual bool ReadOnly {
            get { return _readOnly; }
            protected set { _readOnly = value; }
        }

        public virtual void AttachILogger(ILogger logger) {
            logger.LogExceptionEvent += LogExceptionEventHandler;
            logger.LogMessageEvent += LogMessageEventHandler;
        }

        public virtual void DetachILogger(ILogger logger) {
            logger.LogExceptionEvent -= LogExceptionEventHandler;
            logger.LogMessageEvent -= LogMessageEventHandler;
        }

        protected virtual void LogExceptionEventHandler(LogLevel level, string message, Exception ex) {
            throw new NotImplementedException();
        }

        protected virtual void LogMessageEventHandler(LogLevel level, string message) {
            throw new NotImplementedException();
        }

        protected virtual void Write(MemberInfo callingMember, DateTime eventTime, EventType eventType, string message, params string[] fields) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the first calling member that does not implement ILogger
        /// </summary>
        /// <returns></returns>
        private MemberInfo GetCallingMember() {
            StackTrace stackTrace = new StackTrace(); 
            MemberInfo result = null;

            for (int i = 0; i != stackTrace.FrameCount; i++) {
                StackFrame frame = stackTrace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                if(method.DeclaringType.GetInterface(typeof(ILogger).ToString()) == null) {
                    if (!method.DeclaringType.IsSubclassOf(GetType())) {
                        //if we've made it here, then the frame in the stack trace is not
                        //from an ILogger and not from this (or a decendent of this) class.
                        result = method;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
