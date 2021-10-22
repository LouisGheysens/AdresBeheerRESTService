using API.Model.output;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Exceptions;
using BusinessLayer.Services;

namespace API.Mappers {
    public static class MapfromDomain {
        public static GemeenteRESToutputDTO MapFromGemeenteDomain(string url, Gemeente gemeente, StraatService straatservice) {
            try {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                List<string> straten = straatservice.GeefstratenInGemeente(gemeente.NIScode).Select(x => gemeenteURL + $"/straat/{x.Id}").ToList(); // Geeft alle straten uit een gemeente!
                GemeenteRESToutputDTO dto = new GemeenteRESToutputDTO(gemeenteURL, gemeente.NIScode, gemeente.GemeenteNaam, straten.Count, straten);
                return dto;
            }catch(Exception ex) {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
    }
}
