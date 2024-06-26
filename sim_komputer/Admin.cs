﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sim_komputer
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            btDashboard.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btDashboard.Width, btDashboard.Height, 7, 7));
            btInven.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btInven.Width, btInven.Height, 7, 7));
            btInvoice.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btInvoice.Width, btInvoice.Height, 7, 7));
            btEmploy.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btEmploy.Width, btEmploy.Height, 7, 7));
            btLogout.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btLogout.Width, btLogout.Height, 7, 7));

            UpdateJumlahBarang();
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

        public void ShowUserControl<T>() where T : UserControl, new()
        {
            T userControl = this.Controls.OfType<T>().FirstOrDefault();
            if (userControl == null)
            {
                userControl = new T();
                userControl.Dock = DockStyle.Fill;
                this.Controls.Add(userControl);
            }
            userControl.BringToFront();
        }
        private void btEmploy_Click(object sender, EventArgs e)
        {
            ShowUserControl<employe_admin>();
        }

        private void btDashboard_Click(object sender, EventArgs e)
        {
            ShowUserControl<Dashboard_admin>();
        }

        private void btInven_Click(object sender, EventArgs e)
        {
            ShowUserControl<inventory_admin>();
        }

        private void btInvoice_Click(object sender, EventArgs e)
        {
            ShowUserControl<invoice_admin>();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            login loginForm = new login();
            loginForm.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
