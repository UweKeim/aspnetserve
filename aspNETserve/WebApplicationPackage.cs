using System;
using System.Collections.Generic;
using System.Text;

namespace aspNETserve {
    public class WebApplicationPackage : IDisposable {

        /// <summary>
        /// releases the unmanaged resources allocated by the current
        /// WebApplicationPackage instance.
        /// </summary>
        public void Dispose(){}

        /// <summary>
        /// Opens the WebApplicationPackage for reading.
        /// </summary>
        public void Open(){}

        /// <summary>
        /// Returns the path on disk to the contents
        /// of an opened WebApplicationPackage.
        /// </summary>
        public string PhysicalPath {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
