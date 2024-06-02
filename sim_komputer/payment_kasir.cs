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
using System.Drawing.Printing;

namespace sim_komputer
{
    public partial class payment_kasir : UserControl
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private decimal totalAfterDiscount;
        private decimal change;
        private decimal paymentAmount;
        private decimal discount;
        private int kasirId;
        private int noBon;
        private DataTable cartTableForPrint = new DataTable();

        public payment_kasir()
        {
            InitializeComponent();
            noBon = GenerateNewTransactionId();

            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            button1.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 7, 7));
            bTbyr.Region = System.Drawing.Region.FromHrgn(style.CreateRoundRectRgn(0, 0, bTbyr.Width, bTbyr.Height, 7, 7));
        }
        public void SetKasirId(int kasirId)
        {
            this.kasirId = kasirId;
        }
        public void SetTotalAndDiscount(decimal total, decimal discount, DataTable orderDetails)
        {
            this.discount = discount;
            totalAfterDiscount = total - discount;

            tBprice.Text = "Rp " + total.ToString("N0");
            tBdiscount.Text = "Rp " + discount.ToString("N0");
            tBttl.Text = "Rp " + totalAfterDiscount.ToString("N0");
            cartTableForPrint = orderDetails;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tBprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBdiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBcharge_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void bTCharge_Click(object sender, EventArgs e)
        {

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
        private void bTbyr_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tBcharge.Text, out paymentAmount))
            {
                change = paymentAmount - totalAfterDiscount;

                if (change < 0)
                {
                    MessageBox.Show("Jumlah uang yang dibayarkan tidak mencukupi.");
                    return;
                }

                SaveTransaction(paymentAmount, change);

                ResetForm();

                // Tampilkan print preview
                printPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Masukkan jumlah uang yang valid.");
            }

        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 12);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;

            // Header nota
            graphics.DrawString($"No Bon : {noBon}", font, new SolidBrush(Color.Black), startX, startY);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Nama Kasir: {GetKasirName()}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Tanggal & Waktu: {DateTime.Now.ToString("dd/MM/yyyy")}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 20;

            // Judul detail transaksi
            graphics.DrawString("Nama Barang          Jumlah Beli          Subtotal", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;

            // Perulangan untuk menampilkan detail barang
            foreach (DataRow row in cartTableForPrint.Rows)
            {
                string productName = row["Nama Barang"].ToString();
                int quantity = Convert.ToInt32(row["Jumlah Dibeli"]);
                decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                graphics.DrawString(productName, font, new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(quantity.ToString(), font, new SolidBrush(Color.Black), startX + 200, startY + offset);
                offset += (int)fontHeight + 5;

                string quantityAndPrice = $"{quantity} x Rp {subtotal / quantity:N0}";
                string totalLine = subtotal.ToString("N0").PadLeft(30); // Ubah format subtotal
                graphics.DrawString(quantityAndPrice, font, new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(totalLine, font, new SolidBrush(Color.Black), startX + 200, startY + offset);
                offset += (int)fontHeight + 20;
            }

            // Total, Diskon, Jumlah Bayar, Kembalian
            graphics.DrawString($"Total: Rp {totalAfterDiscount:N0}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Diskon: Rp {discount:N0}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Jumlah Bayar: Rp {paymentAmount:N0}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Kembalian: Rp {change:N0}", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 20;

            // Footer
            graphics.DrawString("TERIMAKASIH", font, new SolidBrush(Color.Black), startX, startY + offset);
        }


        private string GetKasirName()
        {
            using (SqlConnection connection = koneksi.GetConnection())
            {
                connection.Open();
                string sql = "SELECT nama_kasir FROM kasir WHERE id_kasir = @id_kasir";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_kasir", kasirId);
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "Unknown";
                }
            }
        }


        private void SaveTransaction(decimal paymentAmount, decimal change)
        {
            using (SqlConnection connection = koneksi.GetConnection())
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO transaksi (id_kasir, total_bayar, discount, kembalian, tgl_pembelian, waktu_pembelian) VALUES (@id_kasir, @total_bayar, @discount, @kembalian, @tgl_pembelian, @waktu_pembelian)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_kasir", kasirId);
                        command.Parameters.AddWithValue("@total_bayar", paymentAmount);
                        command.Parameters.AddWithValue("@discount", discount);
                        command.Parameters.AddWithValue("@kembalian", change);
                        command.Parameters.AddWithValue("@tgl_pembelian", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@waktu_pembelian", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving transaction: " + ex.Message);
                }
            }
        }
        private int GenerateNewTransactionId()
        {
            using (SqlConnection connection = koneksi.GetConnection())
            {
                connection.Open();
                string sql = "SELECT MAX(no_bon) FROM transaksi";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) + 1 : 1;
                }
            }
        }
        private void ResetForm()
        {
            tBcharge.Text = string.Empty;
            tBprice.Text = string.Empty;
            tBdiscount.Text = string.Empty;
            tBttl.Text = string.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowUserControl<order_kasir>();
        }
    }
}
