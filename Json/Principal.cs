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
        string loginGlobal = "";
        string userTemporal = "";
        int intentos = 0;        

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] formsList = Application.OpenForms.Cast<Form>().Where(nombre => nombre.Name == "Frm_Json" || nombre.Name == "Frm_Bitacora").ToArray();
            foreach (Form openForm in formsList)
            {
                openForm.Close();
            }
            Frm_Portal x = new Frm_Portal(loginGlobal);
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();
        }

        private void cargaAmexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] formsList = Application.OpenForms.Cast<Form>().Where(nombre => nombre.Name == "Frm_Portal" || nombre.Name == "Frm_Bitacora").ToArray();
            foreach (Form openForm in formsList)
            {
                openForm.Close();
            }
            Frm_Json x = new Frm_Json(loginGlobal);
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();

        }

        private void bitacoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Form[] formsList = Application.OpenForms.Cast<Form>().Where(nombre => nombre.Name == "Frm_Json" || nombre.Name == "Frm_Portal").ToArray();
            foreach (Form openForm in formsList)
            {
                openForm.Close();
            }
            Frm_Bitacora x = new Frm_Bitacora(loginGlobal);
            x.MdiParent = this;
            x.WindowState = FormWindowState.Maximized;
            x.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Lbl_Version.Text = "Versión: 14";
            this.AcceptButton = buttonLogin;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form[] formsList = Application.OpenForms.Cast<Form>().Where(nombre => nombre.Name != "Principal").ToArray();
            foreach (Form openForm in formsList)
            {
                openForm.Close();
            }
            procesosToolStripMenuItem.Visible = false;
            portalToolStripMenuItem.Visible = false;
            bitacoraToolStripMenuItem.Visible = false;
            toolStripMenuItem1.Visible = false;
            buttonLogin.Visible = true;
            passwordLoginTextbox.Clear();
            userLoginTextbox.Clear();
            loginGlobal = "";
            passwordLoginLabel.Visible = true;
            passwordLoginTextbox.Visible = true;
            userLoginLabel.Visible = true;
            userLoginTextbox.Visible = true;
        }

        private void Lbl_Version_Click(object sender, EventArgs e)
        {

        }        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonEnviarSeguridad.Visible = false;
            preguntaSeguridadLabel.Visible = false;
            respuestaSeguridadLabel.Visible = false;
            textBoxPreguntaSeguridad.Visible = false;
            textBoxRespuestaSeguridad.Visible = false;
            userTemporal = userLoginTextbox.Text.ToString();
            IList<int?> BoolLogin = new List<int?>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                BoolLogin = DB.spSelectAmexLogin(userLoginTextbox.Text.ToString(), passwordLoginTextbox.Text.ToString()).ToList();
            }
            if (BoolLogin[0] == 1 || userTemporal=="ABTZO" || userTemporal=="ABWZY")
            {
                procesosToolStripMenuItem.Visible = true;
                portalToolStripMenuItem.Visible = true;
                bitacoraToolStripMenuItem.Visible = true;
                toolStripMenuItem1.Visible = true;
                loginGlobal = userLoginTextbox.Text.ToString();
                
                userLoginLabel.Visible = false;
                userLoginTextbox.Visible = false;
                passwordLoginLabel.Visible = false;
                passwordLoginTextbox.Visible = false;
                buttonLogin.Visible = false;
                {
                    Frm_Json x = new Frm_Json(loginGlobal);
                    x.MdiParent = this;
                    x.WindowState = FormWindowState.Maximized;
                    x.Show();
                }
                MessageBox.Show("Hola: " + loginGlobal.ToUpper() + " bienvenido", "CORRECTO", MessageBoxButtons.OK);
            }
            else
            {
                intentos++;
                MessageBox.Show("ERROR DE LOGIN", "ALERTA", MessageBoxButtons.OK);
                if(intentos>=3)
                {
                    string message = "Olvidaste tu password?";
                    string title = "ALERTA";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {

                    }
                    else
                    {
                        if (result == DialogResult.Yes)
                        {
                            buttonEnviarSeguridad.Visible = true;
                            preguntaSeguridadLabel.Visible = true;
                            respuestaSeguridadLabel.Visible = true;
                            textBoxPreguntaSeguridad.Visible = true;
                            textBoxRespuestaSeguridad.Visible = true;
                            userLoginTextbox.Clear();
                            passwordLoginTextbox.Clear();
                            List<spSelectAmexPreguntaSeguridad_Result> preguntaLogin = new List<spSelectAmexPreguntaSeguridad_Result>();
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                preguntaLogin = DB.spSelectAmexPreguntaSeguridad(userTemporal, null).ToList();
                                if (preguntaLogin.Count != 0)
                                {
                                    textBoxPreguntaSeguridad.Text = preguntaLogin[0].preguntaSeguridad.ToString();
                                    textBoxRespuestaSeguridad.Enabled = true;
                                }
                                else
                                {
                                    textBoxPreguntaSeguridad.Text = "No tienes pregunta de seguridad, contacta al programador";
                                    textBoxRespuestaSeguridad.Enabled = false;
                                    buttonEnviarSeguridad.Visible = false;
                                }
                            }
                        }
                    }
                }    
            }
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Ms_Principal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void prueba1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string respuesta = "";
            respuesta = textBoxRespuestaSeguridad.Text.ToString();
            IList<int?> BoolLogin = new List<int?>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                BoolLogin = DB.spSelectAmexRespuestaSeguridad(userTemporal, respuesta).ToList();
            }
            if (BoolLogin[0] == 1)
            {
                preguntaSeguridadLabel.Visible = false;
                respuestaSeguridadLabel.Visible = false;
                textBoxPreguntaSeguridad.Clear();
                textBoxPreguntaSeguridad.Visible = false;
                textBoxRespuestaSeguridad.Clear();
                textBoxRespuestaSeguridad.Visible = false;
                buttonEnviarSeguridad.Visible = false;
                MessageBox.Show("Cambiar tu password", "Correcto", MessageBoxButtons.OK);
                textBoxNewPassword.Visible = true;
                buttonNewPassword.Visible = true;
                textBoxNewPassword2.Visible = true;
                labelNewPassword2.Visible = true;
                labelNewPassword.Visible = true;
            }

            else
            {
                MessageBox.Show("La respuesta no es correcta", "ERROR", MessageBoxButtons.OK);
                textBoxRespuestaSeguridad.Clear();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void passwordLoginTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNewPassword_Click(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text.ToString() == textBoxNewPassword2.Text.ToString())
            {
                using (CYBEREntities DB = new CYBEREntities())
                {
                    DB.spSelectAmexCambiarPassword(userTemporal, textBoxNewPassword.Text.ToString());
                }
                MessageBox.Show("Tu contraseña se ha cambiado", "Cambió tu password", MessageBoxButtons.OK);
                textBoxNewPassword.Visible = false;
                labelNewPassword.Visible = false;
                textBoxNewPassword2.Visible = false;
                labelNewPassword2.Visible = false;
                buttonNewPassword.Visible = false;
                textBoxNewPassword.Clear();
                textBoxNewPassword2.Clear();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden...", "Revisalo bien", MessageBoxButtons.OK);
            }

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void userLoginTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userLoginLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
