using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sim_komputer
{
    public partial class Dashboard_admin : UserControl
    {
        public Dashboard_admin()
        {
            InitializeComponent();
            UpdateJumlahBarang();
        }
        private void UpdateJumlahBarang()
        {
            try
            {
                int jumlahBarang = GetJumlahBarang();
                if (label3 != null)
                {
                    label3.Text = jumlahBarang.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetJumlahBarang()
        {
            int jumlahBarang = 0;
            string query = "SELECT COUNT(*) FROM barang";

            using (SqlConnection connection = koneksi.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    jumlahBarang = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return jumlahBarang;
        } 
    }
}
