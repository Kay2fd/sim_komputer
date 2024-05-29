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
    public partial class login : Form
    {
        private SqlConnection connection;
        private int loggedInKasirId;

        public int LoggedInKasirId
        {
            get { return loggedInKasirId; }
            set { loggedInKasirId = value; }
        }
        public login()
        {
            InitializeComponent();
            connection = koneksi.GetConnection();
            button1.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 10, 10));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string loginsql = @"
            SELECT L.*, K.id_kasir, K.nama_kasir, A.id_admin, A.nama_admin 
            FROM Login L 
            LEFT JOIN Admin A ON L.username = A.nama_admin 
            LEFT JOIN kasir K ON L.id_login = K.id_login 
            WHERE L.username = @username AND L.password = @password";

                using (SqlCommand command = new SqlCommand(loginsql, connection))
                {
                    command.Parameters.AddWithValue("@username", tUsn.Text);
                    command.Parameters.AddWithValue("@password", tPw.Text);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string level = reader["level"].ToString();

                            if (level == "admin")
                            {
                                Admin dashboardAdmin = new Admin();
                                dashboardAdmin.Show();
                                this.Hide();
                            }
                            else if (level == "kasir")
                            {
                                int idKasir = reader["id_kasir"] != DBNull.Value ? Convert.ToInt32(reader["id_kasir"]) : -1;
                                string namaKasir = reader["nama_kasir"].ToString();

                                LoggedInKasirId = idKasir;

                                Kasir kasirPage = new Kasir(idKasir, namaKasir);
                                kasirPage.SetKasirId(idKasir);
                                kasirPage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Role: You do not have access to this page.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login: Incorrect username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
