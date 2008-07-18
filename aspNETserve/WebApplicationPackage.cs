using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace aspNETserve {
    /// <summary>
    /// Represents a WebApplicationPackage archive.
    /// </summary>
    public class WebApplicationPackage : IDisposable {
        private bool _isOpen;
        private bool _ownsStream;
        private Stream _stream;
        private string _physicalPath;

        /// <summary>
        /// Constructs an instance of WebApplicationPackage.
        /// This constructor assumes ownership of the stream, and will
        /// close it when the WebApplicationPackage is disposed.
        /// </summary>
        /// <param name="stream">A Stream containing the WAP archive.</param>
        public WebApplicationPackage(Stream stream) : this(stream, true) {}

        /// <summary>
        /// Constructs an instance of WebApplicationPackage.
        /// </summary>
        /// <param name="stream">A Stream containing the WAP archive.</param>
        /// <param name="ownsStream">If true the stream will be closed when the 
        /// instance of WebApplicationPackage is disposed, otherwise it will be left open.
        /// </param>
        public WebApplicationPackage(Stream stream, bool ownsStream) {
            _stream = stream;
            _ownsStream = ownsStream;
        }

        /// <summary>
        /// releases the unmanaged resources allocated by the current
        /// WebApplicationPackage instance.
        /// </summary>
        public virtual void Dispose() {
            if(_ownsStream)
                _stream.Close();
            if(IsOpen)
                DeleteExtractedArchive();
            IsOpen = false;
        }

        /// <summary>
        /// Opens the WebApplicationPackage for reading.
        /// </summary>
        public virtual void Open() {
            if(IsOpen)
                throw new Exception("Cannot open WAP, it is already opened.");
            IsOpen = true;
            string directory = (new Guid()).ToString();
            _physicalPath = Path.Combine(Path.GetTempPath(), directory);
            ExtractWapToPath(_physicalPath);
        }

        /// <summary>
        /// Returns the path on disk to the contents
        /// of an opened WebApplicationPackage.
        /// </summary>
        public virtual string PhysicalPath {
            get {
                if(!IsOpen)
                    throw new Exception("The WAP is not opened yet.");
                return _physicalPath;
            }
        }

        /// <summary>
        /// Determines if the WebApplicationPackage has been opened
        /// </summary>
        public virtual bool IsOpen {
            get { return _isOpen; }
            protected set { _isOpen = value; }
        }

        protected virtual void ExtractWapToPath(string path) {
            throw new NotImplementedException();
        }

        protected virtual void DeleteExtractedArchive() {
            throw new NotImplementedException();
        }
    }
}
