using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BusinessLayer.Exceptions;
using System.Data;

namespace DataLayer.Repos {
    public class GemeenteRepositoryADO : IGemeenteRepository {
        private string connectionstring;

        public GemeenteRepositoryADO(string connectionstring) {
            this.connectionstring = connectionstring;
        }

        //POST  = GEEFGEMEENTE, HEEFTGEMEENTE en VOEGGEMEENTETOE
        public Gemeente GeefGemeente(int NISCODE) {
            string query = "SELECT * FROM dbo.Gemeente WHERE NISCODE=@NISCODE";
            SqlConnection conn = ADOConnection.CreateConnection();
            using (SqlCommand command = new SqlCommand(query, conn)) {
                try {
                    conn.Open();
                    command.Parameters.AddWithValue("@NISCODE", NISCODE);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Gemeente g = new Gemeente((int)dataReader["NISCODE"], (string)dataReader["Naam"]);
                    dataReader.Close();
                    return g;
                }
                catch (Exception ex) {
                    throw new GemeenteRepositoryADOException("GeefGemeente niet gelukt", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public bool HeeftGemeente(int NISCode) {
            string query = "SELECT COUNT(*) FROM dbo.Gemeente WHERE NISCode=@NISCode";
            SqlConnection conn = ADOConnection.CreateConnection();
            using(SqlCommand cmd = new SqlCommand(query, conn)) {
                try {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@NISCode", NISCode);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true;
                    return false;
                }catch(Exception ex) {
                    GemeenteRepositoryADOException dbex = new GemeenteRepositoryADOException("FAILED!", ex);
                    dbex.Data.Add("NISCode", NISCode);
                    throw dbex;
                }
                finally {
                    conn.Close();
                }
            }
        }

        public void VoegGemeenteToe(Gemeente gemeente) {
            string query = "INSERT INTO dbo.Gemeente (NISCOde, gemeentenaam) VALUES (@NISCode, @gemeentenaam)";
            SqlConnection conn = ADOConnection.CreateConnection();
            using (SqlCommand comm = new SqlCommand(query, conn)) {
                try {
                    conn.Open();
                    comm.Parameters.Add(new SqlParameter("@NISCode", SqlDbType.Int));
                    comm.Parameters.Add(new SqlParameter("@gemeentenaam", SqlDbType.NVarChar));
                    comm.Parameters["@NISCode"].Value = gemeente.NIScode;
                    comm.Parameters["@gemeentenaam"].Value = gemeente.GemeenteNaam;
                    comm.ExecuteNonQuery();

                }catch(Exception ex) {
                    throw new GemeenteRepositoryADOException("VoegGemeenteToe - Failed!");
                }
                finally {
                    conn.Close();
                }
            }
        }
    }
}
