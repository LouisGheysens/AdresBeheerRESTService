using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.output {
    public class GemeenteRESToutputDTO {
        public GemeenteRESToutputDTO(string id, int niscode, string naam, int aantalStraten, List<string> straten) {
            Id = id;
            NIScode = niscode;
            Naam = naam;
            AantalStraten = aantalStraten;
            Straten = straten;
        }
        public string Id { get; set; }

        public int NIScode { get; set; }

        public string Naam { get; set; }

        public int AantalStraten { get; set; }

        public List<string> Straten { get; set; }
    }
}
