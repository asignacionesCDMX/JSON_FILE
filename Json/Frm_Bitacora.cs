using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json
{
    public partial class Frm_Bitacora : Form
    {
        public Frm_Bitacora()
        {
            InitializeComponent();
        }

        private void Frm_Bitacora_Load(object sender, EventArgs e)
        {
            
            Dtp_Inicio.Text = DateTime.Now.AddDays(-1).ToString();
            

            IList<spSelectAmexBitacora_Result> Bitacora = new List<spSelectAmexBitacora_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                Bitacora = DB.spSelectAmexBitacora(Convert.ToDateTime(Dtp_Inicio.Value).ToString("dd/MM/yyyy"), Convert.ToDateTime(Dtp_Fin.Value).ToString("dd/MM/yyyy")).ToList();
            }
            DataTable Result = new DataTable();
            Result.Columns.Add("ID");
            Result.Columns.Add("CUENTA");
            Result.Columns.Add("REPORTADO");
            Result.Columns.Add("RECIBIDO");
            Result.Columns.Add("FECHA");
            Result.Columns.Add("ARCHIVO");
            if (Bitacora.Count > 0)
            {
                for (int i = 0; i < Bitacora.Count; i++)
                {
                    object[] objeto = new object[6];
                    objeto[0] = Bitacora[i].CTAXBAID;
                    objeto[1] = Bitacora[i].CTAXBACUENTA;
                    objeto[2] = Bitacora[i].CTAXBAREPORTADO;
                    objeto[3] = Bitacora[i].CTAXBARECIBIDO;
                    objeto[4] = Bitacora[i].CTAXBAFECHA;
                    objeto[5] = Bitacora[i].CTAXBAARCHIVO;
                    Result.Rows.Add(objeto);
                }
                Dgv_Resultado.DataSource = Result;
            }
    }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Txt_Cuenta.Text!=string.Empty)
            {
                IList<spSelectAmexBitacoraCuenta_Result> Bitacora = new List<spSelectAmexBitacoraCuenta_Result>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    Bitacora = DB.spSelectAmexBitacoraCuenta(Txt_Cuenta.Text).ToList();
                }
                DataTable Result = new DataTable();
                Result.Columns.Add("ID");
                Result.Columns.Add("CUENTA");
                Result.Columns.Add("REPORTADO");
                Result.Columns.Add("RECIBIDO");
                Result.Columns.Add("FECHA");
                Result.Columns.Add("ARCHIVO");
                if (Bitacora.Count > 0)
                {
                    Dgv_Resultado.DataSource = null;
                    for (int i = 0; i < Bitacora.Count; i++)
                    {
                        object[] objeto = new object[6];
                        objeto[0] = Bitacora[i].CTAXBAID;
                        objeto[1] = Bitacora[i].CTAXBACUENTA;
                        objeto[2] = Bitacora[i].CTAXBAREPORTADO;
                        objeto[3] = Bitacora[i].CTAXBARECIBIDO;
                        objeto[4] = Bitacora[i].CTAXBAFECHA;
                        objeto[5] = Bitacora[i].CTAXBAARCHIVO;
                        Result.Rows.Add(objeto);
                    }
                    Dgv_Resultado.DataSource = Result;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            IList<spSelectAmexBitacora_Result> Bitacora = new List<spSelectAmexBitacora_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                Bitacora = DB.spSelectAmexBitacora(Convert.ToDateTime(Dtp_Inicio.Value).ToString("dd/MM/yyyy"), Convert.ToDateTime(Dtp_Fin.Value).ToString("dd/MM/yyyy")).ToList();
            }
            DataTable Result = new DataTable();
            Result.Columns.Add("ID");
            Result.Columns.Add("CUENTA");
            Result.Columns.Add("REPORTADO");
            Result.Columns.Add("RECIBIDO");
            Result.Columns.Add("FECHA");
            Result.Columns.Add("ARCHIVO");
            if (Bitacora.Count > 0)
            {
                for (int i = 0; i < Bitacora.Count; i++)
                {
                    object[] objeto = new object[6];
                    objeto[0] = Bitacora[i].CTAXBAID;
                    objeto[1] = Bitacora[i].CTAXBACUENTA;
                    objeto[2] = Bitacora[i].CTAXBAREPORTADO;
                    objeto[3] = Bitacora[i].CTAXBARECIBIDO;
                    objeto[4] = Bitacora[i].CTAXBAFECHA;
                    objeto[5] = Bitacora[i].CTAXBAARCHIVO;
                    Result.Rows.Add(objeto);
                }
                Dgv_Resultado.DataSource = Result;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {            
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Hoja1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Delete();
            worksheet = workbook.Sheets["Hoja2"];
            worksheet = workbook.ActiveSheet;
            worksheet.Delete();

            worksheet = workbook.Sheets["Hoja3"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "BITACORA";
            // storing header part in Excel  
            for (int i = 1; i < Dgv_Resultado.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = Dgv_Resultado.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < Dgv_Resultado.Rows.Count - 1; i++)
            {
                for (int j = 0; j < Dgv_Resultado.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].NumberFormat = "@";
                    worksheet.Cells[i + 2, j + 1] = Dgv_Resultado.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("c:\\Bitacora_Amex"+DateTime.Now.ToString("ddMMyyyyHmmss")+".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Pbx_Cuenta.BorderStyle = BorderStyle.None;
            Pbx_Cuenta.Image = new Bitmap(Json.Properties.Resources.Btn_Cuenta);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Pbx_Cuenta.BorderStyle = BorderStyle.Fixed3D;
            float opacityvalue = float.Parse("70") / 100;
            Pbx_Cuenta.Image = ChangeOpacity(Pbx_Cuenta.Image, opacityvalue);
        }

        private void Pbx_Buscar_MouseLeave(object sender, EventArgs e)
        {
            Pbx_Buscar.BorderStyle = BorderStyle.None;
            Pbx_Buscar.Image = new Bitmap(Json.Properties.Resources.Btn_Buscar);
        }

        private void Pbx_Buscar_MouseHover(object sender, EventArgs e)
        {
            Pbx_Buscar.BorderStyle = BorderStyle.Fixed3D;
            float opacityvalue = float.Parse("70") / 100;
            Pbx_Buscar.Image = ChangeOpacity(Pbx_Buscar.Image, opacityvalue);
        }

        private void Pbx_Exportar_MouseLeave(object sender, EventArgs e)
        {
            Pbx_Exportar.BorderStyle = BorderStyle.None;
            Pbx_Exportar.Image = new Bitmap(Json.Properties.Resources.Btn_Excel);
        }

        private void Pbx_Exportar_MouseHover(object sender, EventArgs e)
        {
            Pbx_Exportar.BorderStyle = BorderStyle.Fixed3D;
            float opacityvalue = float.Parse("70") / 100;
            Pbx_Exportar.Image = ChangeOpacity(Pbx_Exportar.Image, opacityvalue);

        }
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }
    }
}
