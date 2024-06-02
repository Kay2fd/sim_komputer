using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sim_komputer
{
    public partial class Kasir : Form
    {
        private int currentKasirId;
        private string namaKasir;

        public Kasir(int kasirId, string namaKasir)
        {
            InitializeComponent();
            this.currentKasirId = kasirId;
            this.namaKasir = namaKasir;

            if (label8 != null)
            {
                label8.Text = namaKasir;
            }

            btDashboard.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btDashboard.Width, btDashboard.Height, 5, 5));
            btOrder.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btOrder.Width, btOrder.Height, 5, 5));
            btLogout.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btLogout.Width, btLogout.Height, 7, 7));

            UpdateJumlahBarang();
            UpdateJumlahPenjualanProduk();
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
                    label4.Text = jumlahPenjualan.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void UpdateJumlahBarang()
        {
            try
            {
                int jumlahBarang = GetJumlahBarang();
                if (label6 != null)
                {
                    label6.Text = jumlahBarang.ToString();
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
        public void SetKasirId(int kasirId)
        {
            currentKasirId = kasirId;
        }
        public void ShowUserControl<T>(Action<T> initializer = null) where T : UserControl, new()
        {
            T userControl = this.Controls.OfType<T>().FirstOrDefault();
            if (userControl == null)
            {
                userControl = new T();
                if (typeof(T) == typeof(order_kasir))
                {
                    ((order_kasir)(object)userControl).SetKasirId(currentKasirId);
                }
                if (typeof(T) == typeof(payment_kasir))
                {
                    ((payment_kasir)(object)userControl).SetKasirId(currentKasirId);
                }
                initializer?.Invoke(userControl);
                userControl.Dock = DockStyle.Fill;
                this.Controls.Add(userControl);
            }
            else
            {
                initializer?.Invoke(userControl);
            }
            userControl.BringToFront();
        }

        private void btDashboard_Click(object sender, EventArgs e)
        {
            ShowUserControl<Dashboard_kasir>(uc => uc.SetNamaKasir(namaKasir));
        }

        private void btOrder_Click(object sender, EventArgs e)
        {
            ShowUserControl<order_kasir>();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            login loginForm = new login();
            loginForm.Show();
        }
    }
}
