using API.Exceptions;
using API.Model.input;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappers {
    public static class MapToDomain {
        public static Gemeente MapToGemeenteDomain(GemeenteRESTinputDTO dto) {
            try {
                Gemeente gem = new Gemeente(dto.NIScode, dto.Naam);
                return gem;
            }
            catch (Exception ex) {
                throw new MapException("MapToGemeenteException", ex);
            }
        }
    }
}
