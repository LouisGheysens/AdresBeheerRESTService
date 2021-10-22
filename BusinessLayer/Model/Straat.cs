using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model {
    public class Straat {
        public Straat(int id, string straatNaam, Gemeente gemeente) {
            ZetId(id);
            ZetStraatNaam(straatNaam);
            ZetGemeente(gemeente);
        }

        public Straat(string straatnaam, Gemeente gemeente) {
            ZetStraatNaam(straatnaam);
            ZetGemeente(gemeente);
        }
        
        public Straat(string straatnaam) {
            ZetStraatNaam(straatnaam);
        }

        public int Id { get; private set; }

        public string StraatNaam { get; private set; }

        public Gemeente Gemeente { get; private set; }

        public void ZetStraatNaam(string naam) {
            if (string.IsNullOrWhiteSpace(naam)) {
                StraatException ex = new StraatException("Naam niet correct!");
                ex.Data.Add("Straatnaam", naam);
                throw ex;
            }
            StraatNaam = naam;
        }

        public void ZetId(int id) {
            if(id <= 0) {
                StraatException ex = new StraatException("ID niet correct!");
                ex.Data.Add("ID", id);
                throw ex;
            }
            Id = id;
        }

        public void ZetGemeente(Gemeente nieuweGemeente) {
            if (nieuweGemeente == null) throw new StraatException("ZetGemeente - null");
            if (nieuweGemeente == Gemeente) throw new StraatException("ZetGemeente - niet nieuw");
            Gemeente = nieuweGemeente;
        }

    }
}
