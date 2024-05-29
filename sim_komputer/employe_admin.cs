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
    public partial class employe_admin : UserControl
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        public employe_admin()
        {
            InitializeComponent();
            connection = koneksi.GetConnection();
            ShowData();
            button1.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 7, 7));
            bTedit.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, bTedit.Width, bTedit.Height, 7, 7));
            btRemove.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btRemove.Width, btRemove.Height, 7, 7));
        }
        private void ShowData()
        {
            try
            {
                string sql = @"
                    SELECT 
                        l.id_login, 
                        l.level, 
                        l.username,
                        l.password,
                        k.id_kasir, 
                        k.nama_kasir 
                    FROM 
                        dbo.login l
                    LEFT JOIN 
                        dbo.kasir k ON l.id_login = k.id_login";

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();

                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private bool IsPasswordUnique(string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM login WHERE password = @password";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa password: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tBusn.Text;
                string password = tBpw.Text;
                string namaKasir = tBname.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(namaKasir))
                {
                    MessageBox.Show("Harap isi semua kolom.");
                    return;
                }

                if (!IsPasswordUnique(password))
                {
                    MessageBox.Show("Password sudah digunakan, harap gunakan password lain.");
                    return;
                }

                string insertLoginQuery = @"INSERT INTO login (username, password, level) VALUES (@username, @password, 'kasir'); SELECT SCOPE_IDENTITY() AS id_login;";
                command = new SqlCommand(insertLoginQuery, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int newLoginId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                string insertKasirQuery = @"INSERT INTO kasir (id_login, nama_kasir) VALUES (@id_login, @nama_kasir)";
                command = new SqlCommand(insertKasirQuery, connection);
                command.Parameters.AddWithValue("@id_login", newLoginId);
                command.Parameters.AddWithValue("@nama_kasir", namaKasir);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                ShowData();

                MessageBox.Show("Kasir berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void bTedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string username = tBusn.Text;
                    string password = tBpw.Text;
                    string namaKasir = tBname.Text;

                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(namaKasir))
                    {
                        MessageBox.Show("Harap isi semua kolom.");
                        return;
                    }

                    if (!IsPasswordUnique(password))
                    {
                        MessageBox.Show("Password sudah digunakan, harap gunakan password lain.");
                        return;
                    }

                    int idLogin = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_login"].Value);

                    string updateLoginQuery = @"UPDATE login SET username = @username, password = @password WHERE id_login = @id_login";
                    command = new SqlCommand(updateLoginQuery, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@id_login", idLogin);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string updateKasirQuery = @"UPDATE kasir SET nama_kasir = @nama_kasir WHERE id_login = @id_login";
                    command = new SqlCommand(updateKasirQuery, connection);
                    command.Parameters.AddWithValue("@nama_kasir", namaKasir);
                    command.Parameters.AddWithValue("@id_login", idLogin);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    ShowData();

                    MessageBox.Show("Data kasir berhasil diperbarui.");
                }
                else
                {
                    MessageBox.Show("Silakan pilih baris terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int idLogin = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_login"].Value);

                    string deleteKasirQuery = @"DELETE FROM kasir WHERE id_login = @id_login";
                    command = new SqlCommand(deleteKasirQuery, connection);
                    command.Parameters.AddWithValue("@id_login", idLogin);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    string deleteLoginQuery = @"DELETE FROM login WHERE id_login = @id_login";
                    command = new SqlCommand(deleteLoginQuery, connection);
                    command.Parameters.AddWithValue("@id_login", idLogin);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    ShowData();

                    MessageBox.Show("Data kasir berhasil dihapus.");
                }
                else
                {
                    MessageBox.Show("Silakan pilih baris terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
