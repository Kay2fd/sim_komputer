using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }
        public void SetNamaKasir(string namaKasir)
        {
            NamaKasir = namaKasir;
            label1.Text = NamaKasir;
        }
    }
}
