using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions {
    public class GemeenteRepositoryADOException : Exception {
        public GemeenteRepositoryADOException() {
        }

        public GemeenteRepositoryADOException(string message) : base(message) {
        }

        public GemeenteRepositoryADOException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
