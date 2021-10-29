using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services {
    public class StraatService {
        private IStraatRepository repo;

        public StraatService(IStraatRepository repo) {
            this.repo = repo;
        }
        public List<Straat> GeefstratenInGemeente(int gemeenteId) {
            try {
                return repo.GeefstratenInGemeente(gemeenteId);
            }catch(Exception ex) {
                throw new StraatServiceException("GeefStratenInGeemnte", ex);
            }
        }
    }
}
