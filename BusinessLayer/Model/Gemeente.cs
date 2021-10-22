using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model {
    public class Gemeente {
        public int NIScode { get; private set; }
        public string GemeenteNaam { get; private set; }

        public Gemeente(int niscode, string gemeentenaam) {
            ZetNIScode(niscode);
            ZetGemeentenaam(gemeentenaam);
        }

        public void ZetGemeentenaam(string gemeentenaam) {
            if(((string.IsNullOrWhiteSpace(GemeenteNaam)) || (!char.IsUpper(GemeenteNaam[0])))) {
                GemeenteException ex = new GemeenteException("Naam niet correct");
                //Doe steeds de ex.Data.add = zo kan je makkeljker fouten opsporen!
                ex.Data.Add("Gemeentenaam", gemeentenaam);
                throw ex;
            }
            GemeenteNaam = gemeentenaam;
        }

        public void ZetNIScode(int code) {
            if((code < 10000) || (code > 99999)) {
                GemeenteException ex = new GemeenteException("Niscode niet correct");
                ex.Data.Add("NIScode", code);
                throw ex;
            }
        }

        public override string ToString() {
            return base.ToString();
        }

        public override bool Equals(object obj) {
            return obj is Gemeente gemeente &&
                   NIScode == gemeente.NIScode &&
                   GemeenteNaam == gemeente.GemeenteNaam;
        }

        public override int GetHashCode() {
            return HashCode.Combine(NIScode, GemeenteNaam);
        }
    }
}
