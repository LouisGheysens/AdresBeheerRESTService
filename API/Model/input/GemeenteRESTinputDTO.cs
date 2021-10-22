using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.input {
    /// <summary>
    /// DTO = DATA TRANSFERED OBJECT, OBJECT DIE ENKEL DATA BEVAT
    /// </summary>
    public class GemeenteRESTinputDTO {
        public int NIScode { get; set; }

        public string Naam { get; set; }
    }
}
