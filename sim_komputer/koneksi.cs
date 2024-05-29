using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sim_komputer
{
    internal class koneksi
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=LAPTOP-BH0TSUTL;Initial Catalog=sim_komputer3;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
