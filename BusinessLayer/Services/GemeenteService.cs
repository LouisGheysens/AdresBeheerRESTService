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

        public GemeenteService(IGemeenteRepository repo) {
            this.repo = repo;
        }
        public Gemeente GeefGemeente(int id) {
            try {
                return repo.GeefGemeente(id);
            }catch(Exception ex) {
                throw new GemeenteServiceException("GeefGemeente", ex);
            }
        }

        public Gemeente VoegGemeenteToe(Gemeente gemeente) {
            try {
                if (gemeente == null) throw new GemeenteServiceException("VoegGemeenteToe - gemeente is null");
                if (repo.HeeftGemeente(gemeente.NIScode)) throw new GemeenteServiceException("VoegGemeenteToe - Gemeente bestaat niet!");
                repo.VoegGemeenteToe(gemeente);
                return gemeente;
            }catch(Exception ex) {
                throw new GemeenteServiceException("VoegGemeenteToe", ex);
            }
        }
    }
}
