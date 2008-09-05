using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebServer {
    public class DataWriteEventArgs : EventArgs {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public DataWriteEventArgs(byte[] buffer) : this(buffer, 0, buffer.Length) { }

        public DataWriteEventArgs(byte[] buffer, int offset, int count) {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public virtual byte[] Buffer {
            get { return _buffer; }
        }

        public virtual int Offset {
            get { return _offset; }
        }

        public virtual int Count {
            get { return _count; }
        }
    }
}
