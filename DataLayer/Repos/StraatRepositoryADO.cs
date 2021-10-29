using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using BusinessLayer.Exceptions;

namespace DataLayer.Repos {
    public class StraatRepositoryADO : IStraatRepository {
        private string connectionstring;

        public StraatRepositoryADO(string connectionstring) {
            this.connectionstring = connectionstring;
        }

        public List<Straat> GeefstratenInGemeente(int gemeenteId) {
            string query = "SELECT t1.*,t2.Naam FROM dbo.Straat t1 "
                 + " INNER JOIN dbo.Gemeente t2 on t1.NISCode=t2.NISCode WHERE t1.NISCode=@NISCode";
            SqlConnection conn = ADOConnection.CreateConnection();
            using (SqlCommand command = new SqlCommand(query, conn)) {
                try {
                    List<Straat> straten = new List<Straat>();
                    conn.Open();
                    command.Parameters.AddWithValue("@NISCode", gemeenteId);
                    IDataReader dataReader = command.ExecuteReader();
                    Gemeente g = null;
                    while (dataReader.Read()) {
                        if (g == null) g = new Gemeente((int)dataReader["NISCode"], (string)dataReader["Naam"]);
                        Straat s = new Straat((int)dataReader["id"], (string)dataReader["Straatnaam"], g);
                        straten.Add(s);
                    }
                    dataReader.Close();
                    return straten;
                }
                catch (Exception ex) {
                    throw new StraatRepositoryADOException("GeefStraten niet gelukt", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }
    }
}
