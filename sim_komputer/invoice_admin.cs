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
    public partial class invoice_admin : UserControl
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable transaksiTable;
        public invoice_admin()
        {
            InitializeComponent();
            connection = koneksi.GetConnection();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();
                string sql = @"SELECT t.no_bon, t.id_kasir, t.tgl_pembelian, t.total_bayar 
                               FROM transaksi t";
                adapter = new SqlDataAdapter(sql, connection);
                transaksiTable = new DataTable();
                adapter.Fill(transaksiTable);
                dataGridView1.DataSource = transaksiTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void Search(string searchTerm)
        {
            try
            {
                connection.Open();

                string sql = @"SELECT t.no_bon, t.id_kasir, t.tgl_pembelian, t.total_bayar 
                       FROM transaksi t";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    sql += " WHERE t.no_bon = @searchTerm";
                    adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", searchTerm);
                }
                else
                {
                    adapter = new SqlDataAdapter(sql, connection);
                }

                transaksiTable = new DataTable();
                adapter.Fill(transaksiTable);

                dataGridView1.DataSource = transaksiTable;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(textBox1.Text);
        }
    }
    }
