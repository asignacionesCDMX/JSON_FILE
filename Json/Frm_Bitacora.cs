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
        string loginGlobal = "Sin_User";
        public Frm_Bitacora(string tokenLogin)
        {
            InitializeComponent();
            loginGlobal = tokenLogin;
            //MessageBox.Show("Hola: " + loginGlobal + " Bienvenido al Frm_Bitacora", "Frm_Bitacora", MessageBoxButtons.OK);
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

            if (loginGlobal.ToUpper() == "ABTDN" || loginGlobal.ToUpper() == "AANAY" || loginGlobal.ToUpper() == "AAHTQ" || loginGlobal.ToUpper() == "ABPGN")
            {
                Bnt_Concentrado.Visible = true;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Txt_Cuenta.Text != string.Empty)
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
            workbook.SaveAs("c:\\Bitacora_Amex" + DateTime.Now.ToString("ddMMyyyyHmmss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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

        private void Bnt_Concentrado_Click(object sender, EventArgs e)
        {
            DateTime horaInicio = DateTime.Now;
            IList<spSelectAmexUpdateCONCE_Result> Concentrado = new List<spSelectAmexUpdateCONCE_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                Concentrado = DB.spSelectAmexUpdateCONCE(DateTime.Now).ToList();
            }
            DataSet ds = new DataSet();

            DataTable ResultPLACEMENT = new DataTable();
            ResultPLACEMENT.Columns.Add("UPDATEDATE");
            ResultPLACEMENT.Columns.Add("ACCOUNTNUMBER");
            ResultPLACEMENT.Columns.Add("CURRENTBALANCE");
            ResultPLACEMENT.Columns.Add("AGENCYID");
            ResultPLACEMENT.Columns.Add("BALANCINGSEQNO");
            ResultPLACEMENT.Columns.Add("TIPO");
            ResultPLACEMENT.TableName = "ANGIEREYNA";
            ds.Tables.Add(ResultPLACEMENT);

            /*
             * CON AUTORIZACION DE LA SEÑORITA JEFA :D
             * SE REALIZÓ UN CAMBIO EN EL CÓDIGO, EL DIA 24 DE SEPTIEMBRE A LAS.... 1 ..2 PM MAS O MENOS.
             * Y LO HICE YO. RICARDO CERVANTES.
             * 
             * ESTAS LINEAS SE QUITARON, PARA DEJAR TODA LA INFO. EN UNA SOLA TABLA PARA DESPUÉS HACER UN EXCEL CON ESA INFORMACIÓN.
            DataTable ResultTOTAL = new DataTable();
            ResultTOTAL.Columns.Add("UPDATEDATE");
            ResultTOTAL.Columns.Add("ACCOUNTNUMBER");
            ResultTOTAL.Columns.Add("CURRENTBALANCE");
            ResultTOTAL.Columns.Add("AGENCYID");
            ResultTOTAL.Columns.Add("BALANCINGSEQNO");
            ResultTOTAL.Columns.Add("TIPO");
            ResultTOTAL.TableName = "TOTAL";
            ds.Tables.Add(ResultTOTAL);

            DataTable ResultUPDATE = new DataTable();
            ResultUPDATE.Columns.Add("UPDATEDATE");
            ResultUPDATE.Columns.Add("ACCOUNTNUMBER");
            ResultUPDATE.Columns.Add("CURRENTBALANCE");
            ResultUPDATE.Columns.Add("AGENCYID");
            ResultUPDATE.Columns.Add("BALANCINGSEQNO");
            ResultUPDATE.Columns.Add("TIPO");
            ResultUPDATE.TableName = "UPDATESOB";
            ds.Tables.Add(ResultUPDATE);
            */

            if (Concentrado.Count > 0)
            {
                //Y AQUI SE AÑADIÓ UN WHILE Y 2 IFS, PARA TOMAR SOLO EL ULTIMO DATO DE CADA CUENTA.
                //YA QUE, ESTAN ORDENADAS POR FECHA DE LA MAS VIEJA A LA MÁS NUEVA, Y ESA ÚLTIMA ES LA QUE NOS INTERESA.
                for (int i = 0; i < Concentrado.Count; i++)
                {
                    object[] objeto = new object[6];
                    if (i < Concentrado.Count - 1)
                    {
                        while (Concentrado[i].TBAXATACCOUNTNUMBER == Concentrado[i + 1].TBAXATACCOUNTNUMBER && i < Concentrado.Count)
                        {
                            i++;
                            if (i == Concentrado.Count - 1) break;
                        }
                    }
                    objeto[0] = Concentrado[i].TBAXATUPDATEDATE;
                    objeto[1] = Concentrado[i].TBAXATACCOUNTNUMBER;
                    objeto[2] = Concentrado[i].TBAXATCURRENTBALANCE;
                    objeto[3] = Concentrado[i].TBAXATCURRENTAGENCYID;
                    objeto[4] = Concentrado[i].TBAXHRBALANCINGSEQNO;
                    objeto[5] = Concentrado[i].TIPO;
                    //ESTO SE REMOVIO, POR QUE NO TIENE CASO USAR EL SWITCH. YA QUE TODO IRA EN UNA MISMA HOJA.
                    //switch (Concentrado[i].TIPO)
                    //{
                    //case "PLACEMENT":
                    ResultPLACEMENT.Rows.Add(objeto);
                    /*break;
                case "TOTAL":
                    ResultTOTAL.Rows.Add(objeto);
                    break;
                case "UPDATEOB":
                    ResultUPDATE.Rows.Add(objeto);
                    break;
                default:
                    break;
            }*/
                }
                Ent_Excel EXCEL = new Ent_Excel();
                bool SET = EXCEL.CreateExcelDocument(ds, @"c:\\CONCENTRADO" + DateTime.Now.ToString("ddMMyyyyHmmss") + ".xlsx");
                MessageBox.Show("Archivo excel Generado", "COMPLETO", MessageBoxButtons.OK);
                MessageBox.Show("GENERANDO BITACORAS....", "ESPERA", MessageBoxButtons.OK);
            }
            #region BITACORA-CUENTAS
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Obtiene la ruta especial del Escritorio para concatearla mas adelante.
            string archivo = Ruta + "\\JSON\\" + "BITACORAS" + "\\" + DateTime.Now.ToString("dd-MM-yyyy");
            string nombreArchivoRuta = archivo + "\\BITACORAS CUENTAS" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
            if (!Directory.Exists(archivo)) //Si el directorio no existe lo crea.
            {
                Directory.CreateDirectory(archivo);
            } //si ya existe, se salta este paso.
            File.WriteAllText(nombreArchivoRuta, "");

            string FECHA_PROCEDIMIENTO = "FECHA_PROCEDIMIENTO".PadRight(30);
            string TIPO = "TIPO".PadRight(20);
            string SECUENCIAL = "SECUENCIAL".PadRight(15);
            string CUENTAS_HEADER = "CUENTAS_HEADER".PadRight(20);
            string CUENTAS_PROCESADAS = "CUENTAS_PROCESADAS".PadRight(20);
            string CUENTAS_UNICAS = "CUENTAS_UNICAS".PadRight(20);

            StringBuilder BITACORA_ = new StringBuilder();
            BITACORA_.AppendLine(FECHA_PROCEDIMIENTO + TIPO + SECUENCIAL + CUENTAS_HEADER + CUENTAS_PROCESADAS + CUENTAS_UNICAS);
            List<spSelectSertecBitacoraGlobal_Result> resultBitacora = new List<spSelectSertecBitacoraGlobal_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                resultBitacora = DB.spSelectSertecBitacoraGlobal().ToList();
            }
            if (resultBitacora.Count != 0)
            {
                for (int i = 0; i < resultBitacora.Count; i++)
                {
                    while (true)
                    {
                        if (i == 0)
                            break;
                        BITACORA_.AppendLine(
                        resultBitacora[i].Fechacreacion.ToString().Substring(0, 10).PadRight(30)
                        +
                        resultBitacora[i].TipoAsignacion.ToString().PadRight(20)
                        +
                        resultBitacora[i].SeqNo.ToString().PadRight(15)
                        +
                        resultBitacora[i].CuentasHeader.ToString().PadRight(20)
                        +
                        resultBitacora[i].CuentasCreadas.ToString().PadRight(20)
                        +
                        resultBitacora[i].CuentasUnicas.ToString().PadRight(20)
                        );
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("OLVIDALO, NO HABÍA NADA QUE BITACOREAR", "NEVERMIND", MessageBoxButtons.OK);
            }
            File.AppendAllText(nombreArchivoRuta, BITACORA_.ToString());
            MessageBox.Show("BITACORA DE CUENTAS GENERADA", "DONE AND DONE", MessageBoxButtons.OK);
            #endregion BITACORA-CUENTAS
            #region BITACORA PAGOS
            string Ruta2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Obtiene la ruta especial del Escritorio para concatearla mas adelante.
            string archivo2 = Ruta2 + "\\JSON\\" + "BITACORAS" + "\\" + DateTime.Now.ToString("dd-MM-yyyy");
            string nombreArchivoRuta2 = archivo2 + "\\BITACORA PAGOS" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
            if (!Directory.Exists(archivo2)) //Si el directorio no existe lo crea.
            {
                Directory.CreateDirectory(archivo2);
            } //si ya existe, se salta este paso.
            File.WriteAllText(nombreArchivoRuta2, "");

            string FECHA_PROCEDIMIENTO2 = "FECHA_PROCEDIMIENTO".PadRight(30);
            string SECUENCIAL2 = "SECUENCIAL".PadRight(30);
            string TRANSACTIONTYPECODE = "TRANSACTIONTYPECODE".PadRight(30);
            string TIPO2 = "TIPO".PadRight(30);
            string REPETICIONES = "REPETICIONES".PadRight(30);
            string MONTO_TOTAL = "MONTO_TOTAL".PadRight(30);

            StringBuilder BITACORA_2 = new StringBuilder();
            BITACORA_2.AppendLine(FECHA_PROCEDIMIENTO2 + SECUENCIAL2 + TRANSACTIONTYPECODE + TIPO2 + REPETICIONES + MONTO_TOTAL);
            List<spSelectSertecBitacoraPagosGlobal2_Result> resultBitacora2 = new List<spSelectSertecBitacoraPagosGlobal2_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                resultBitacora2 = DB.spSelectSertecBitacoraPagosGlobal2().ToList();
            }
            if (resultBitacora2.Count != 0)
            {
                for (int i = 0; i < resultBitacora2.Count; i++)
                {
                    while (true)
                    {
                        if (i == 0)
                            break;
                        BITACORA_2.AppendLine(
                        resultBitacora2[i].fechaInsercion.ToString().Substring(0, 10).PadRight(30)
                        +
                        resultBitacora2[i].secuencial.ToString().PadRight(30)
                        +
                        resultBitacora2[i].tipo.ToString().PadRight(30)
                        +
                        resultBitacora2[i].transactionTypeCode.ToString().PadRight(30)
                        +
                        resultBitacora2[i].repeticiones.ToString().PadRight(30)
                        +
                        resultBitacora2[i].montoTotal.ToString().PadRight(30)
                        );
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("OLVIDALO, NO HABÍA NADA QUE BITACOREAR", "NEVERMIND", MessageBoxButtons.OK);
            }
            File.AppendAllText(nombreArchivoRuta2, BITACORA_2.ToString());
            MessageBox.Show("BITACORA DE PAGOS GENERADA", "DONE AND DONE", MessageBoxButtons.OK);
            #endregion BITACORA PAGOS
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.spInsertSecuencialAmexJSON("CONCENTRADO", "-", "CONCENTRADO", loginGlobal, null, horaInicio, DateTime.Now);//Se agregó nuevo SP para almacenar el secuencial en una base histórica. 10-Ene-2020
            }
        }

        private void Dgv_Resultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
