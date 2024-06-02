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
    public partial class Dashboard_kasir : UserControl
    {
        public string NamaKasir { get; set; }
        public Dashboard_kasir()
        {
            InitializeComponent();
            UpdateJumlahBarang();
            UpdateJumlahPenjualanProduk();
        }
        public void SetNamaKasir(string namaKasir)
        {
            NamaKasir = namaKasir;
            label1.Text = NamaKasir;
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
        private int GetJumlahPenjualanProduk()
        {
            int jumlahPenjualan = 0;
            string query = "SELECT SUM(jumlah_dibeli) FROM pemesanan_detail";

            using (SqlConnection connection = koneksi.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        jumlahPenjualan = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error mengambil jumlah penjualan produk: " + ex.Message);
                }
            }
            return jumlahPenjualan;
        }

        private void UpdateJumlahPenjualanProduk()
        {
            try
            {
                int jumlahPenjualan = GetJumlahPenjualanProduk();
                if (label4 != null)
                {
                    label4.Text =jumlahPenjualan.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
