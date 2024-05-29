using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sim_komputer
{
    public partial class order_kasir : UserControl
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable barangTable;
        private DataTable cartTable;
        private int selectedCartRowIndex = -1;
        private int currentKasirId;
        private int currentPemesananId = -1;
        private DataTable cartTableForPrint = new DataTable();

        public order_kasir()
        {
            InitializeComponent();
            connection = koneksi.GetConnection();
            InitializeData();
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
        }
        public void SetKasirId(int kasirId)
        {
            currentKasirId = kasirId;
        }
        private void InitializeData()
        {
            LoadBarangData();
            InitializeCartTable();
            FillComboBox();
        }
        private void LoadBarangData()
        {
            try
            {
                connection.Open();
                string sql = "SELECT id_barang, nama_barang, harga, stok FROM barang";
                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                barangTable = new DataTable();
                adapter.Fill(barangTable);

                dataGridView1.DataSource = barangTable;
                dataGridView1.Columns["id_barang"].HeaderText = "ID";
                dataGridView1.Columns["nama_barang"].HeaderText = "Nama Barang";
                dataGridView1.Columns["harga"].HeaderText = "Harga";
                dataGridView1.Columns["stok"].HeaderText = "Stok";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading barang data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ID Barang", typeof(int));
            cartTable.Columns.Add("Nama Barang", typeof(string));
            cartTable.Columns.Add("Jumlah", typeof(int));
            cartTable.Columns.Add("Harga", typeof(decimal));
            cartTable.Columns.Add("Total", typeof(decimal));

            // Tambahkan kolom untuk tampilan Print Preview
            cartTableForPrint.Columns.Add("Nama Barang", typeof(string));
            cartTableForPrint.Columns.Add("Jumlah Dibeli", typeof(int));
            cartTableForPrint.Columns.Add("Subtotal", typeof(decimal));

            dataGridView2.DataSource = cartTable;
        }


        private void FillComboBox()
        {
            comboBox1.DataSource = barangTable;
            comboBox1.DisplayMember = "nama_barang";
            comboBox1.ValueMember = "id_barang";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tBqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(tBqty.Text, out int qty) && qty > 0)
            {
                DataRow selectedRow = barangTable.Rows[comboBox1.SelectedIndex];
                int id_barang = (int)selectedRow["id_barang"];
                string nama_barang = selectedRow["nama_barang"].ToString();
                decimal harga = Convert.ToDecimal(selectedRow["harga"]);
                decimal total = harga * qty;
                int stok = (int)selectedRow["stok"];

                if (qty > stok)
                {
                    MessageBox.Show("Stok tidak mencukupi!");
                    return;
                }

                try
                {
                    connection.Open();

                    if (currentPemesananId == -1)
                    {
                        // Create a new pemesanan
                        string insertPemesananSql = "INSERT INTO pemesanan (id_kasir, tgl_pemesanan, waktu_pemesanan) OUTPUT INSERTED.id_pemesanan VALUES (@id_kasir, @tgl_pemesanan, @waktu_pemesanan)";
                        command = new SqlCommand(insertPemesananSql, connection);
                        command.Parameters.AddWithValue("@id_kasir", currentKasirId);
                        command.Parameters.AddWithValue("@tgl_pemesanan", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@waktu_pemesanan", DateTime.Now);
                        currentPemesananId = (int)command.ExecuteScalar();
                    }

                    string updateSql = "UPDATE barang SET stok = stok - @qty WHERE id_barang = @id_barang";
                    command = new SqlCommand(updateSql, connection);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@id_barang", id_barang);
                    command.ExecuteNonQuery();

                    selectedRow["stok"] = stok - qty;

                    DataRow newRow = cartTable.NewRow();
                    newRow["ID Barang"] = id_barang;
                    newRow["Nama Barang"] = nama_barang;
                    newRow["Jumlah"] = qty;
                    newRow["Harga"] = harga;
                    newRow["Total"] = total;

                    cartTable.Rows.Add(newRow);

                    UpdateTotalPriceLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding to cart: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a valid product and enter a valid quantity.");
            }
        }

       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCartRowIndex = e.RowIndex;
                DataRow selectedRow = cartTable.Rows[selectedCartRowIndex];
                tBqty2.Text = selectedRow["Jumlah"].ToString();
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bTupdate_Click(object sender, EventArgs e)
        {
            if (selectedCartRowIndex >= 0 && int.TryParse(tBqty2.Text, out int newQty) && newQty > 0)
            {
                DataRow selectedRow = cartTable.Rows[selectedCartRowIndex];
                int id_barang = (int)selectedRow["ID Barang"];
                int oldQty = (int)selectedRow["Jumlah"];
                decimal harga = (decimal)selectedRow["Harga"];
                DataRow barangRow = barangTable.Select($"id_barang = {id_barang}")[0];
                int stok = (int)barangRow["stok"];

                if (newQty > oldQty + stok)
                {
                    MessageBox.Show("Stok tidak mencukupi!");
                    return;
                }

                try
                {
                    connection.Open();
                    string updateSql = "UPDATE barang SET stok = stok + @oldQty - @newQty WHERE id_barang = @id_barang";
                    command = new SqlCommand(updateSql, connection);
                    command.Parameters.AddWithValue("@oldQty", oldQty);
                    command.Parameters.AddWithValue("@newQty", newQty);
                    command.Parameters.AddWithValue("@id_barang", id_barang);
                    command.ExecuteNonQuery();

                    barangRow["stok"] = (int)barangRow["stok"] + oldQty - newQty;

                    selectedRow["Jumlah"] = newQty;
                    selectedRow["Total"] = harga * newQty;
                    UpdateTotalPriceLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating cart: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a valid quantity.");
            }
        }

        private void bTremove_Click(object sender, EventArgs e)
        {
            if (selectedCartRowIndex >= 0)
            {
                DataRow selectedRow = cartTable.Rows[selectedCartRowIndex];
                int id_barang = (int)selectedRow["ID Barang"];
                int qty = (int)selectedRow["Jumlah"];

                try
                {
                    connection.Open();
                    string updateSql = "UPDATE barang SET stok = stok + @qty WHERE id_barang = @id_barang";
                    command = new SqlCommand(updateSql, connection);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@id_barang", id_barang);
                    command.ExecuteNonQuery();

                    DataRow barangRow = barangTable.Select($"id_barang = {id_barang}")[0];
                    barangRow["stok"] = (int)barangRow["stok"] + qty;

                    cartTable.Rows.Remove(selectedRow);
                    selectedCartRowIndex = -1;
                    tBqty2.Clear();
                    UpdateTotalPriceLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing from cart: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void UpdateTotalPriceLabel()
        {
            decimal totalPrice = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                totalPrice += Convert.ToDecimal(row["Total"]);
            }
            label5.Text = "Total Harga: Rp " + totalPrice.ToString("N0");
        }
        private void tBqty2_TextChanged(object sender, EventArgs e)
        {
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                totalPrice += Convert.ToDecimal(row["Total"]);
            }
            return totalPrice;
        }

        private decimal CalculateDiscount(decimal totalPrice)
        {
            decimal discount = 0;
            if (totalPrice > 25000000)
            {
                discount = totalPrice * 0.05m;
            }
            else if (totalPrice > 15000000)
            {
                discount = totalPrice * 0.02m;
            }
            return discount;
        }
        public void ShowUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void bTcharge_Click(object sender, EventArgs e)
        {
            decimal totalPrice = CalculateTotalPrice();
            decimal discount = CalculateDiscount(totalPrice);
            decimal totalPriceAfterDiscount = totalPrice - discount;

            // Simpan detail pesanan sebelum menampilkan tampilan Print Preview
            SaveOrderDetailsToDatabase();

            payment_kasir paymentPage = new payment_kasir();
            paymentPage.SetTotalAndDiscount(totalPrice, discount, cartTableForPrint);
            paymentPage.SetKasirId(currentKasirId);

            ShowUserControl(paymentPage);
        }

        private void SaveOrderDetailsToDatabase()
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                foreach (DataRow row in cartTable.Rows)
                {
                    DataRow newRow = cartTableForPrint.NewRow();
                    newRow["Nama Barang"] = row["Nama Barang"];
                    newRow["Jumlah Dibeli"] = row["Jumlah"];
                    newRow["Subtotal"] = row["Total"];
                    cartTableForPrint.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order details to temporary table: " + ex.Message);
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
