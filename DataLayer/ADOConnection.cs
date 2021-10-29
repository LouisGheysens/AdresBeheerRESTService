using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataLayer {
    public static class ADOConnection {
        private static SqlConnection _sqlConnection = null;

        public static SqlConnection Connection { get { if (_sqlConnection == null) { _sqlConnection = CreateConnection(); } return _sqlConnection; } }


        public static SqlConnection CreateConnection() {
            return new SqlConnection(@"Data Source=DESKTOP-3CJB43N\SQLEXPRESS;Initial Catalog=AdresBeheerRestService;Integrated Security=True");
        }
    }
}
