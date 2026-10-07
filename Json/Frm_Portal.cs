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
    public partial class Frm_Portal : Form
    {
        string loginGlobal = "";
        public Frm_Portal(string tokenLogin)
        {
            InitializeComponent();
            loginGlobal = tokenLogin;
            //MessageBox.Show("Hola: " + loginGlobal + " Bienvenido al Frm_Portal", "Frm_Portal", MessageBoxButtons.OK);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Frm_Portal_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://fsgateway.aexp.com/ftp-web/app");

            var dbEnc = Encoding.UTF8;
            var uniEnc = Encoding.Unicode;
            byte[] dbBytes = dbEnc.GetBytes("h%L9A 9++[/C*u~+snLb2M");
            byte[] uniBytes = Encoding.Convert(dbEnc, uniEnc, dbBytes);
            string mensajeAPasarAlDr = uniEnc.GetString(uniBytes);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt_Pass_Click(object sender, EventArgs e)
        {
            Txt_Pass.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void Btn_Iexplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            proc.EnableRaisingEvents = false;

            //Here you can also specify a html page on local machine

            //such as C:\Test\default.html

            proc.StartInfo.FileName = "https://fsgateway.aexp.com/ftp-web/app";

            proc.Start();
        }

        private void Pbx_Iexplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            proc.EnableRaisingEvents = false;

            //Here you can also specify a html page on local machine

            //such as C:\Test\default.html

            proc.StartInfo.FileName = "https://fsgateway.aexp.com/ftp-web/app";

            proc.Start();
        }

        private void Pbx_Iexplorer_MouseLeave(object sender, EventArgs e)
        {
            
            Pbx_Iexplorer.BorderStyle = BorderStyle.None;

        }

        private void Pbx_Iexplorer_MouseHover(object sender, EventArgs e)
        {
            
            Pbx_Iexplorer.BorderStyle = BorderStyle.Fixed3D;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt_Pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
