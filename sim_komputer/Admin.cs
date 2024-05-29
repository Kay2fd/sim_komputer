using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sim_komputer
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
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
    }
}
