using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces {
    public interface IGemeenteRepository {
        Gemeente GeefGemeente(int id);
        bool HeeftGemeente(int NISCode);
        void VoegGemeenteToe(Gemeente gemeente);
    }
}
