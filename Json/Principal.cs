using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Portal x = new Frm_Portal();
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();
        }

        private void cargaAmexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Json x = new Frm_Json();
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();
        }

        private void bitacoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Bitacora x = new Frm_Bitacora();
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Lbl_Version.Text = "Versión: 2.1";
        }
    }
}
