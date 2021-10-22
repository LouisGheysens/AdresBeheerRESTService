using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services {
    /// <summary>
    /// Service klasse is hetzelfde als de managerklasse, puur gewoon een andere naam!
    /// </summary>
    public class GemeenteService {
        private IGemeenteRepository repo;
        public Gemeente GeefGemeente(int id) {
            try {
                return repo.GeefGemeente(id);
            }catch(Exception ex) {
                throw new GemeenteServiceException("GeefGemeente", ex);
            }
        }
    }
}
