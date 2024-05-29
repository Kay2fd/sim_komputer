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
    public partial class inventory_admin : UserControl
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataTable tabel;
        public SqlDataReader reader;
        public int id_barang;
        public int id_admin;
        public string sql;
        public inventory_admin()
        {
            InitializeComponent();
            connection = koneksi.GetConnection();
            showData();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            tSearch.TextChanged += new EventHandler(tSearch_TextChanged);
            btRemove.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btRemove.Width, btRemove.Height, 7, 7));
            btAdd.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btAdd.Width, btAdd.Height, 7, 7));
            btEdit.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, btEdit.Width, btEdit.Height, 7, 7));
        }
        public void showData()
        {
            try
            {
                connection.Close();
                connection.Open();

                string sql = "SELECT id_barang, nama_barang, harga, stok, brand, id_admin FROM barang";
                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                tabel = new DataTable();
                adapter.Fill(tabel);

                dataGridView1.DataSource = tabel;
                dataGridView1.Columns["id_barang"].HeaderText = "Code Product";
                dataGridView1.Columns["nama_barang"].HeaderText = "Product Name";
                dataGridView1.Columns["harga"].HeaderText = "Price";
                dataGridView1.Columns["stok"].HeaderText = "Product Stock";
                dataGridView1.Columns["brand"].HeaderText = "Brand";
                dataGridView1.Columns["id_admin"].Visible = true;

                dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at: " + ex);
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["harga"].Index && e.Value != null)
            {
                string hargaString = e.Value.ToString();
                if (int.TryParse(hargaString, out int harga))
                {
                    e.Value = "Rp " + harga.ToString("N0");
                }
            }
        }
        public void insertData()
        {
            if (!string.IsNullOrEmpty(tName.Text)
        && !string.IsNullOrEmpty(tBrand.Text) && !string.IsNullOrEmpty(tPrice.Text)
           && !string.IsNullOrEmpty(tQuantity.Text))
            {
                int idAdmin = 1;

                if (!IsAdminIdValid(idAdmin))
                {
                    MessageBox.Show("Invalid Admin ID. Please provide a valid Admin ID.");
                    return;
                }

                sql = "INSERT INTO barang (nama_barang, harga, stok, brand, id_admin) " +
                    "VALUES (@namabarang, @harga, @stok, @brand, @idadmin) ";

                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@namabarang", tName.Text);
                command.Parameters.AddWithValue("@harga", tPrice.Text);
                command.Parameters.AddWithValue("@stok", tQuantity.Text);
                command.Parameters.AddWithValue("@brand", tBrand.Text);
                command.Parameters.AddWithValue("@idadmin", idAdmin);

                try
                {
                    connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Succesfully inserted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    showData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all data before insert!");
            }
        }

        private bool IsAdminIdValid(int adminId)
        {
            bool isValid = false;

            try
            {
                connection.Close();
                connection.Open();

                string query = "SELECT COUNT(*) FROM admin WHERE id_admin = @adminId";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@adminId", adminId);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating Admin ID: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isValid;
        }
        public void clear()
        {
            tName.Text = "";
            tBrand.Text = "";
            tPrice.Text = "";
            tQuantity.Text = "";
            //   tAdmin.Text = "";
        }
        public void updateData()
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Selected)
            {
                if (!string.IsNullOrEmpty(tName.Text) && !string.IsNullOrEmpty(tPrice.Text)
                    && !string.IsNullOrEmpty(tQuantity.Text) && !string.IsNullOrEmpty(tBrand.Text))
                {
                    DialogResult result = MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string sql = "UPDATE barang SET nama_barang = @namabarang, harga = @harga, stok = @quantity, brand = @brand " +
                                "WHERE id_barang = @id";

                            connection.Open();
                            command = new SqlCommand(sql, connection);
                            command.Parameters.AddWithValue("@namabarang", tName.Text);
                            command.Parameters.AddWithValue("@harga", tPrice.Text);
                            command.Parameters.AddWithValue("@quantity", tQuantity.Text);
                            command.Parameters.AddWithValue("@brand", tBrand.Text);
                            command.Parameters.AddWithValue("@id", id_barang);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Succesfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear(); // Kosongkan input setelah update
                            showData(); // Tampilkan data terbaru setelah update
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating data: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all data before update!");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update!");
            }
        }

        public void deleteData()
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Selected)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "DELETE FROM barang WHERE id_barang = @id";
                        command = new SqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@id", id_barang);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Succesfully deleted", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear(); // Kosongkan input setelah delete
                        showData(); // Tampilkan data terbaru setelah delete
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting data: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            id_barang = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            id_admin = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);

            tName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tQuantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tBrand.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id_barang = Convert.ToInt32(row.Cells["id_barang"].Value);
                id_admin = Convert.ToInt32(row.Cells["id_admin"].Value);

                tName.Text = row.Cells["nama_barang"].Value.ToString();
                tPrice.Text = row.Cells["harga"].Value.ToString();
                tQuantity.Text = row.Cells["stok"].Value.ToString();
                tBrand.Text = row.Cells["brand"].Value.ToString();
            }
        }
        public void searchData()
        {

            if (!string.IsNullOrEmpty(tSearch.Text))
            {
                try
                {
                    sql = "SELECT * FROM barang WHERE nama_barang LIKE '%' + @search + '%'";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@search", tSearch.Text);

                    adapter = new SqlDataAdapter(command);
                    tabel = new DataTable();
                    adapter.Fill(tabel);

                    if (tabel.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = tabel;
                    }
                    else
                    {
                        MessageBox.Show("No data found for the search keyword: " + tSearch.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a search keyword!");
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showData();
        }
        public void searchData(string keyword)
        {
            try
            {
                connection.Close();
                connection.Open();

                string sql = "SELECT id_barang, nama_barang, harga, stok, brand, id_admin FROM barang WHERE nama_barang LIKE @keyword";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                adapter = new SqlDataAdapter(command);
                tabel = new DataTable();
                adapter.Fill(tabel);

                dataGridView1.DataSource = tabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(tSearch.Text);
        }
    }
}
