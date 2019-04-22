using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Json.Ent_Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Newtonsoft.Json.Converters;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
//using Oracle.ManagedDataAccess.Client;

namespace Json
{
    public partial class Frm_Json : Form
    {
        DataTable PRUEBA;
        Ent_Json.RootObject resultsPlacement;
        Ent_Json_Recall.RootObject resultsRecall;
        Ent_Json_Update.RootObject resultsUpdate;
        Ent_Json_Action.RootObject resultsAction;
        DataTable DsRetorno;
        public Frm_Json()
        {
           
            InitializeComponent();
        }

        private async void Btn_Archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            //archivo.Filter = "Archivos JSON (*.json)|*.json"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
            archivo.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            if (archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Txt_Archivo.Text = archivo.FileName;
                pictureBox1.Visible = true;
                await EjecutarAsyn();
                //Dgv_Informacion.DataSource = PRUEBA.DefaultView;
                Dgv_Informacion.Show();
                pictureBox1.Visible = false;
                Lbl_Total.Visible = true;
                Lbl_Total.Text = "Total : " + (Dgv_Informacion.Rows.Count - 1);

            }
        }


        public XRecord validacionXPO(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "PO";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.care != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.care.minimumDueAmount != null)
                            {
                                xrecord.Numeric1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.care.minimumDueAmount.ToString()).Replace(".", "").PadRight(40);
                            }

                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXPJ(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "PJ";
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                int prueba = 0;
                                if (int.TryParse(resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().Trim(),out prueba))
                                {
                                    xrecord.Alpha1 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                                }
                                else
                                    xrecord.Alpha1 = "".PadRight(40);
                            }
                        }
                    }

                }

                xrecord.FormatCode = "B";
            }
            if (resultsPlacement.caseInfoList[i].accountInfoList != null)
            {
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                    {
                        xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                    }
                }
            }

            return xrecord;
        }
        public XRecord validacionXPI(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "PI";
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha1 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha2 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha3 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha4 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha5 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha6 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha7 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha8 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number != null)
                            {
                                xrecord.Alpha10 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[0].number.ToString().PadRight(40);
                            }
                        }
                    }
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXPH(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "PH";
                List<Telefonos> telefonos;
                telefonos = new List<Telefonos>();

                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number != null)
                                {
                                    Telefonos Tel = new Telefonos();
                                    Tel.telefono = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Trim();
                                    Tel.fecha = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].lastContactDate).ToString("yyyyMMdd");
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode != null)
                                    {
                                        Tel.type = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode.ToString().Trim();
                                    }
                                    else
                                    {
                                        Tel.type = " ";
                                    }

                                    telefonos.Add(Tel);
                                }
                            }
                        }
                    }
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 0)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[0].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha1 = telefonos[0].type.Substring(0, 1).PadRight(5) + telefonos[0].telefono.PadRight(23) + telefonos[0].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha1 = "".PadRight(40);
                                
                            }
                        }
                    }
                }


                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 1)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[1].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha2 = telefonos[1].type.Substring(0, 1).PadRight(5) + telefonos[1].telefono.PadRight(23) + telefonos[1].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha2 = "".PadRight(40);
                                
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 2)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[2].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha3 = telefonos[2].type.Substring(0, 1).PadRight(5) + telefonos[2].telefono.PadRight(23) + telefonos[2].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha3 = "".PadRight(40);
                                
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 3)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[3].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha4 = telefonos[3].type.Substring(0, 1).PadRight(5) + telefonos[3].telefono.PadRight(23) + telefonos[3].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha4 = "".PadRight(40); 
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 4)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[4].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha5 = telefonos[4].type.Substring(0, 1).PadRight(5) + telefonos[4].telefono.PadRight(23) + telefonos[4].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha5 = "".PadRight(40);                                
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 5)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[5].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha6 = telefonos[5].type.Substring(0, 1).PadRight(5) + telefonos[5].telefono.PadRight(23) + telefonos[5].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha6 = "".PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 6)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[6].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha7 = telefonos[6].type.Substring(0, 1).PadRight(5) + telefonos[6].telefono.PadRight(23) + telefonos[6].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha7 = "".PadRight(40);
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 7)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[7].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha8 = telefonos[7].type.Substring(0, 1).PadRight(5) + telefonos[7].telefono.PadRight(23) + telefonos[7].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha8 = "".PadRight(40);
                               
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 8)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[8].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha9 = telefonos[8].type.Substring(0, 1).PadRight(5) + telefonos[8].telefono.PadRight(23) + telefonos[8].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha9 = "".PadRight(40);                              
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            if (telefonos.Count > 9)
                            {
                                int prueba = 0;
                                if (int.TryParse(telefonos[9].telefono.ToString().Trim(), out prueba))
                                {
                                    xrecord.Alpha10 = telefonos[9].type.Substring(0, 1).PadRight(5) + telefonos[9].telefono.PadRight(23) + telefonos[9].fecha.PadRight(12);
                                }
                                else
                                    xrecord.Alpha10 = "".PadRight(40);                               
                            }
                        }
                    }
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXBC(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "BC";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.fullProductDescription != null)
                        {
                            xrecord.Alpha8 = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.fullProductDescription.ToString().PadRight(40);
                        }

                    }
                }
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.canadaRecoveryScore != null)
                //        {
                //            xrecord.Numeric10 = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.canadaRecoveryScore.ToString().PadLeft(13, '0');
                //        }

                //    }
                //}
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXBB(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "BB";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].lastUpdatedDate != null)
                                {
                                    xrecord.Alpha1 = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].lastUpdatedDate).ToString("yyyyMMdd").PadRight(40);

                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].name != null)
                                {
                                    xrecord.Alpha2 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].name.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].phone != null)
                                {
                                    //if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].phone.number != null)
                                    //{
                                    xrecord.Alpha3 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].phone.ToString().PadRight(40);
                                    //}
                                }

                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].type != null)
                                {
                                    xrecord.Alpha4 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].type.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].bankAccountNumber != null)
                                {
                                    xrecord.Alpha5 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].bankAccountNumber.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].abaNumber != null)
                                {
                                    xrecord.Alpha6 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].abaNumber.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].dateAccountOpened != null)
                                {
                                    xrecord.Alpha7 = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[1].dateAccountOpened).ToString("yyyyMMdd").PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.returnMailIndicator != null)
                        {
                            xrecord.Alpha10 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.returnMailIndicator.ToString().PadRight(40);
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXBA(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "BA";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].lastUpdatedDate != null)
                                {
                                    xrecord.Alpha1 = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].lastUpdatedDate).ToString("yyyyMMdd").PadRight(40);

                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].name != null)
                                {
                                    xrecord.Alpha2 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].name.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].phone != null)
                                {
                                    //if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].phone.number != null)
                                    //{
                                    xrecord.Alpha3 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].phone.ToString().PadRight(40);
                                    //}
                                }

                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].type != null)
                                {
                                    xrecord.Alpha4 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].type.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].bankAccountNumber != null)
                                {
                                    xrecord.Alpha5 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].bankAccountNumber.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].abaNumber != null)
                                {
                                    xrecord.Alpha6 = resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].abaNumber.ToString().PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks.Count > 1)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].dateAccountOpened != null)
                                {
                                    xrecord.Alpha7 = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].bankList.banks[0].dateAccountOpened).ToString("yyyyMMdd").PadRight(40);
                                }
                            }
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.companyName != null)
                        {
                            xrecord.Alpha8 = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.companyName.ToString().PadRight(40);
                        }

                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDueCcsg != null)
                        {
                            xrecord.Alpha9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDueCcsg.ToString()).Replace(".", "").PadRight(40);
                        }

                    }
                }
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer!= null)
                //        {
                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.applicationGeoScramNumber != null)
                //            {
                //                xrecord.Alpha10 = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.applicationGeoScramNumber.ToString().PadRight(40);
                //            }
                //        }

                //    }
                //}
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDueOpen != null)
                        {
                            xrecord.Alpha10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDueOpen.ToString()).Replace(".", "").PadRight(40);
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDue != null)
                        {
                            xrecord.Numeric3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCustomerLevelMinDue.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXAE(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "AE";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest30Days != null)
                        {
                            xrecord.Numeric4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest30Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest60Days != null)
                        {
                            xrecord.Numeric5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest60Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest90Days != null)
                        {
                            xrecord.Numeric6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest90Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest120Days != null)
                        {
                            xrecord.Numeric7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest120Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest150Days != null)
                        {
                            xrecord.Numeric8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest150Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest180Days != null)
                        {
                            xrecord.Numeric9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.combinedFeesWithInterest180Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.oldestAgeMinDueBucket != null)
                        {
                            xrecord.Numeric10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.oldestAgeMinDueBucket.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public XRecord validacionXAC(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "AC";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCourtCostsReimbursedToPreviousAgency != null)
                        {
                            xrecord.Numeric1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.totalCourtCostsReimbursedToPreviousAgency.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }
            return xrecord;
        }
        public XRecord validacionXAB(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "AB";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.minimumAmountDue != null)
                        {
                            xrecord.Numeric1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.minimumAmountDue.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.unbilledAmountDue != null)
                        {
                            xrecord.Numeric2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.unbilledAmountDue.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.currentAmountDue != null)
                        {
                            xrecord.Numeric3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.currentAmountDue.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue30Days != null)
                        {
                            xrecord.Numeric4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue30Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue60Days != null)
                        {
                            xrecord.Numeric5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue60Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue90Days != null)
                        {
                            xrecord.Numeric6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue90Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue120Days != null)
                        {
                            xrecord.Numeric7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue120Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue150Days != null)
                        {
                            xrecord.Numeric8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue150Days.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);
                        }
                    }
                }
                xrecord.FormatCode = "B";
            }

            return xrecord;
        }

        public static string DoFormat(string myNumber)
        {
            if (myNumber.Contains("."))
            {
                string[] x = myNumber.ToString().Split('.');
                if (x[1].Length == 2)
                {
                    return myNumber;
                }
                else
                {
                    myNumber = myNumber + "0";
                }
            }
            else
            {
                myNumber = myNumber + "00";
            }

            return myNumber;

        }
        public XRecord validacionXAA(int i)
        {
            XRecord xrecord = new XRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                xrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            xrecord.AccountNumber = "                    ";
                    }
                    else
                        xrecord.AccountNumber = "                    ";
                }
                else
                    xrecord.AccountNumber = "                    ";
                xrecord.RecordType = "X";
                xrecord.SequenceNumber = "00";
                xrecord.UserDefinedCode = "AA";
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalAmountDueInUSD != null)
                        {
                            xrecord.Numeric1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalAmountDueInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.unbilledAmountDueInUSD != null)
                        {
                            xrecord.Numeric2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.unbilledAmountDueInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.currentAmountDueInUSD != null)
                        {
                            xrecord.Numeric3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.currentAmountDueInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue30DaysInUSD != null)
                        {
                            xrecord.Numeric4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue30DaysInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue60DaysInUSD != null)
                        {
                            xrecord.Numeric5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue60DaysInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue90DaysInUSD != null)
                        {
                            xrecord.Numeric6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue90DaysInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue120DaysInUSD != null)
                        {
                            xrecord.Numeric7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue120DaysInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue150DaysInUSD != null)
                        {
                            xrecord.Numeric8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.amountDue150DaysInUSD.ToString()).Replace(".", "").PadLeft(13, '0');
                        }
                    }
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            xrecord.AgencyCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.Substring(2, 4);

                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                DB.spInsertAmexBitacora(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber, "","SEGMENTO: "+ resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId, DateTime.Now, resultsRecall.header.balancingSeqNo.ToString().PadLeft(4, '0') + " PLACEMENT", 1);
                            }
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                DB.spInsertAmexBitacora(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber, "", resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId, DateTime.Now, resultsRecall.header.balancingSeqNo.ToString().PadLeft(4, '0') + " PLACEMENT", 3);
                            }
                        }
                    }
                }



                xrecord.FormatCode = "B";
            }

            return xrecord;
        }
        public class XRecord
        {
            public string AccountNumber = "                    ";
            public string RecordType = " ";
            public string SequenceNumber = "  ";
            public string UserDefinedCode = "  ";
            public string Alpha1 = "                                        ";
            public string Alpha2 = "                                        ";
            public string Alpha3 = "                                        ";
            public string Alpha4 = "                                        ";
            public string Alpha5 = "                                        ";
            public string Alpha6 = "                                        ";
            public string Alpha7 = "                                        ";
            public string Alpha8 = "                                        ";
            public string Alpha9 = "                                        ";
            public string Alpha10 = "                                        ";
            public string Numeric1 = "0000000000000";
            public string Numeric2 = "0000000000000";
            public string Numeric3 = "0000000000000";
            public string Numeric4 = "0000000000000";
            public string Numeric5 = "0000000000000";
            public string Numeric6 = "0000000000000";
            public string Numeric7 = "0000000000000";
            public string Numeric8 = "0000000000000";
            public string Numeric9 = "0000000000000";
            public string Numeric10 = "0000000000000";
            public string Date1 = "        ";
            public string Date2 = "        ";
            public string Date3 = "        ";
            public string Date4 = "        ";
            public string Date5 = "        ";
            public string Date6 = "        ";
            public string Date7 = "        ";
            public string Date8 = "        ";
            public string Date9 = "        ";
            public string Date10 = "        ";
            public string Filler1 = "                                                       B";
            public string Filler2 = "    ";
            public string AgencyCode = "    ";
            public string FormatCode = " ";
        }
        public UserRecord validacionUserRecord(int i)
        {
            UserRecord userrecord = new UserRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                userrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                userrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            userrecord.AccountNumber = "                    ";
                    }
                    else
                        userrecord.AccountNumber = "                    ";
                }
                else
                    userrecord.AccountNumber = "                    ";
                //////////////////////////RECORDTYPE
                userrecord.RecordType = "U";
                //////////////////////////SEQUENCENUMBER
                userrecord.SequenceNumber = "00";
                ////////////////////////SOCIALSECURITYNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].nationalId != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].nationalId[0].nationalIdNumber != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].nationalId[0].nationalIdNumber.ToString().Length < 40)
                                        userrecord.SocialSecurityNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].nationalId[0].nationalIdNumber.ToString().PadRight(40);
                                    else
                                        userrecord.SocialSecurityNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].nationalId[0].nationalIdNumber.ToString().Substring(0, 40);
                                }
                                else
                                    userrecord.SocialSecurityNumber = "                                        ";
                            }
                            else
                                userrecord.SocialSecurityNumber = "                                        ";
                        }
                        else
                            userrecord.SocialSecurityNumber = "                                        ";
                    }
                    else
                        userrecord.SocialSecurityNumber = "                                        ";
                }
                else
                    userrecord.SocialSecurityNumber = "                                        ";
                //////////////////////////FULLPRODCUTDESCRIPTION
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.productType != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.productType.ToString().Length < 40)
                                userrecord.FullProductDescription = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.productType.ToString().PadRight(40);
                            else
                                userrecord.FullProductDescription = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.productType.ToString().Substring(0, 40);

                        }
                        else
                            userrecord.FullProductDescription = "                                        ";
                    }
                    else
                        userrecord.FullProductDescription = "                                        ";
                }
                else
                    userrecord.FullProductDescription = "                                        ";
                //////////////////////////FILMREQUEST
                userrecord.FilmRequest = "                                        ";
                //////////////////////////AGENCYBRANCH
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyBranchName != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyBranchName.ToString().Length < 40)
                                userrecord.AgencyBranch = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyBranchName.ToString().PadRight(40);
                            else
                                userrecord.AgencyBranch = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyBranchName.ToString().Substring(0, 40);

                        }
                        else
                            userrecord.AgencyBranch = "                                        ";
                    }
                    else
                        userrecord.AgencyBranch = "                                        ";
                }
                else
                    userrecord.AgencyBranch = "                                        ";
                //////////////////////////STRATEGYINDICATOR
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1 = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2 = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3 = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4 = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas = 0;
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas.ToString().Length < 1)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas.ToString().PadRight(1));

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas.ToString().Substring(0, 1));
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas = 0;
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas.ToString().Length < 1)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas.ToString().PadRight(1));

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas.ToString().Substring(0, 1));
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1 = " ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1.ToString().Length < 1)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1.ToString().PadRight(1);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1.ToString().Substring(0, 1);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2 = "     ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2.ToString().Length < 5)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2.ToString().PadRight(5);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2.ToString().Substring(0, 5);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3 = "     ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3.ToString().Length < 5)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3.ToString().PadRight(5);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3.ToString().Substring(0, 5);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4 == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4 = "         ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4.ToString().Length < 9)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4.ToString().PadRight(9);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4.ToString().Substring(0, 9);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas = 0;
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas.ToString().Length < 1)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas.ToString().PadRight(1));

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas = Convert.ToInt32(resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas.ToString().Substring(0, 1));
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator.ToString().Length < 2)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator.ToString().PadRight(2);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator.ToString().Substring(0, 2);
                        }
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge == null)
                            resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge = "  ";
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge.ToString().Length < 1)
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge.ToString().PadRight(1);

                            else
                                resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge.ToString().Substring(0, 1);
                        }

                        userrecord.StrategyIndicator = @"" + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId4.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator.ToString()
                                                                   + resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge.ToString();
                    }
                    else
                        userrecord.StrategyIndicator = "                                        ";
                }
                else
                    userrecord.StrategyIndicator = "                                        ";
                //////////////////////////CORPORATEIDNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.corporateId != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.corporateId.ToString().Length < 40)
                                userrecord.CorporateIDNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.corporateId.ToString().PadRight(40);
                            else
                                userrecord.CorporateIDNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.corporateId.ToString().Substring(0, 40);

                        }
                        else
                            userrecord.CorporateIDNumber = "                                        ";
                    }
                    else
                        userrecord.CorporateIDNumber = "                                        ";
                }
                else
                    userrecord.CorporateIDNumber = "                                        ";
                //////////////////////////NEMBERSHIP
                userrecord.MembershipRewards = "                                        ";
                //////////////////////////CADVISION
                userrecord.CADVISION = "                                        ";
                //////////////////////////CREDITBALANCE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.creditBalance != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.creditBalance.ToString().Length < 10)
                                userrecord.CreditBalance = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.creditBalance.ToString()).Replace(".", "").PadRight(10);
                            else
                                userrecord.CreditBalance = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.creditBalance.ToString()).Replace(".", "").Substring(0, 10);

                        }
                        else
                            userrecord.CreditBalance = "          ";
                    }
                    else
                        userrecord.CreditBalance = "          ";
                }
                else
                    userrecord.CreditBalance = "          ";
                //////////////////////////MEXICOREINSTATEMENT
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptance != null)
                //        {

                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptance.ToString().Length < 10)
                //                userrecord.MexicoReinstatement = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptance.ToString().PadRight(10);
                //            else
                //                userrecord.MexicoReinstatement = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptance.ToString().Substring(0, 10);

                //        }
                //        else
                //            userrecord.MexicoReinstatement = "          ";
                //    }
                //    else
                //        userrecord.MexicoReinstatement = "          ";
                //}
                //else
                //    userrecord.MexicoReinstatement = "          ";
                userrecord.MexicoReinstatement = "          ";/////////////se agrego fijo
                //////////////////////////SETTLEMENTAMOUNT
                userrecord.SettlementAmount = "          ";
                //////////////////////////RECOVERYSCOREFORQUADS
                userrecord.RecoveryScoreforQuads = "          ";
                //////////////////////////WRITEOFFAMOUNT
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffAmount != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffAmount.ToString().Length < 10)
                                userrecord.WriteOffAmount = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffAmount.ToString()).Replace(".", "").PadRight(10);
                            else
                                userrecord.WriteOffAmount = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffAmount.ToString()).Replace(".", "").Substring(0, 10);

                        }
                        else
                            userrecord.WriteOffAmount = "          ";
                    }
                    else
                        userrecord.WriteOffAmount = "          ";
                }
                else
                    userrecord.WriteOffAmount = "          ";
                //////////////////////////FICOSCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.ficoScore != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.ficoScore.ToString().Length < 10)
                                userrecord.FICOScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.ficoScore.ToString().PadRight(10);
                            else
                                userrecord.FICOScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.ficoScore.ToString().Substring(0, 10);

                        }
                        else
                            userrecord.FICOScore = "          ";
                    }
                    else
                        userrecord.FICOScore = "          ";
                }
                else
                    userrecord.FICOScore = "          ";
                //////////////////////////OLDRECOVERYSCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.recoveryScore != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.recoveryScore.ToString().Length < 10)
                                userrecord.OldRecoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.recoveryScore.ToString().PadRight(10);
                            else
                                userrecord.OldRecoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.recoveryScore.ToString().Substring(0, 10);

                        }
                        else
                            userrecord.OldRecoveryScore = "          ";
                    }
                    else
                        userrecord.OldRecoveryScore = "          ";
                }
                else
                    userrecord.OldRecoveryScore = "          ";
                //////////////////////////NEWRECOVERYSCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.bankruptcyScore != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.bankruptcyScore.ToString().Length < 10)
                                userrecord.NewRecoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.bankruptcyScore.ToString().PadRight(10);
                            else
                                userrecord.NewRecoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.bankruptcyScore.ToString().Substring(0, 10);

                        }
                        else
                            userrecord.NewRecoveryScore = "          ";
                    }
                    else
                        userrecord.NewRecoveryScore = "          ";
                }
                else
                    userrecord.NewRecoveryScore = "          ";
                //////////////////////////COLLECTIONRECEIVABLE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.crDate != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.crDate.ToString().Length < 8)
                                userrecord.CollectionReceivableDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.crDate.ToString().PadRight(8);
                            else

                                userrecord.CollectionReceivableDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.crDate).ToString("yyyyMMdd").PadRight(8);


                        }
                        else
                            userrecord.CollectionReceivableDate = "        ";
                    }
                    else
                        userrecord.CollectionReceivableDate = "        ";
                }
                else
                    userrecord.CollectionReceivableDate = "        ";
                //////////////////////////CANCELLATION
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancellationDate != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancellationDate.ToString().Length < 8)
                                userrecord.CancellationDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancellationDate.ToString().PadRight(8);
                            else
                                userrecord.CancellationDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancellationDate).ToString("yyyyMMdd").PadRight(8);


                        }
                        else
                            userrecord.CancellationDate = "        ";
                    }
                    else
                        userrecord.CancellationDate = "        ";
                }
                else
                    userrecord.CancellationDate = "        ";
                //////////////////////////CARDANNIVERSARY
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cardOpenDate != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cardOpenDate.ToString().Length < 8)
                                userrecord.CardAnniversaryDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cardOpenDate.ToString().PadRight(8);
                            else
                                userrecord.CardAnniversaryDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cardOpenDate).ToString("yyyyMMdd").PadRight(8);


                        }
                        else
                            userrecord.CardAnniversaryDate = "        ";
                    }
                    else
                        userrecord.CardAnniversaryDate = "        ";
                }
                else
                    userrecord.CardAnniversaryDate = "        ";
                //////////////////////////WRITEOFFDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffDate != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffDate.ToString().Length < 8)
                                userrecord.WriteOffDate = resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffDate.ToString().PadRight(8);
                            else
                                userrecord.WriteOffDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].account.writeOffDate).ToString("yyyyMMdd").PadRight(8);

                        }
                        else
                            userrecord.WriteOffDate = "        ";
                    }
                    else
                        userrecord.WriteOffDate = "        ";
                }
                else
                    userrecord.WriteOffDate = "        ";
                //////////////////////////LASTCHARGE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.lastChargeActivity != null)
                        {

                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.lastChargeActivity.ToString().Length < 8)
                                userrecord.LastChargeDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.lastChargeActivity.ToString().PadRight(8);
                            else
                                userrecord.LastChargeDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.lastChargeActivity).ToString("yyyyMMdd").PadRight(8);

                        }
                        else
                            userrecord.LastChargeDate = "        ";
                    }
                    else
                        userrecord.LastChargeDate = "        ";
                }
                else
                    userrecord.LastChargeDate = "        ";
                //////////////////////////HOMEPURCHASE
                userrecord.HomePurchaseDate = "        ";
                //////////////////////////CUSTOMERLASTPAYMET
                userrecord.CustomerLastPaymentDate = "        ";
                //////////////////////////REINSTATEMENT
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptDate != null)
                //        {

                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptDate.ToString().Length < 8)
                //                userrecord.ReinstatementAcceptDate = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptDate.ToString().PadRight(8);
                //            else
                //            {
                //                try
                //                {
                //                    userrecord.ReinstatementAcceptDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptDate.ToString().Substring(1, 8)).ToString("yyyyMMdd").PadRight(8);
                //                }
                //                catch(Exception)
                //                {
                //                    userrecord.ReinstatementAcceptDate = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.reinstatementAcceptDate.ToString().Substring(1, 8);
                //                }
                //                }

                //        }
                //        else
                //            userrecord.ReinstatementAcceptDate = "        ";
                //    }
                //    else
                //        userrecord.ReinstatementAcceptDate = "        ";
                //}
                //else
                //    userrecord.ReinstatementAcceptDate = "        ";

                userrecord.ReinstatementAcceptDate = "        ";////////////// se agrego fijo
                //////////////////////////FILLER1
                userrecord.Filler1 = "                                                                                                                                                                                                            ";
                //////////////////////////PARENTORGCODE
                userrecord.ParentOrgCode = "    ";
                //////////////////////////AGENCYCODE
                userrecord.AgencyCode = "    ";
                //////////////////////////FORMATCODE
                userrecord.FormatCode = "B";
            }

            return userrecord;
        }
        public class UserRecord
        {
            public string AccountNumber;
            public string RecordType;
            public string SequenceNumber;
            public string SocialSecurityNumber;
            public string FullProductDescription;
            public string FilmRequest;
            public string AgencyBranch;
            public string StrategyIndicator;
            public string CorporateIDNumber;
            public string MembershipRewards;
            public string CADVISION;
            public string CreditBalance;
            public string MexicoReinstatement;
            public string SettlementAmount;
            public string RecoveryScoreforQuads;
            public string WriteOffAmount;
            public string FICOScore;
            public string OldRecoveryScore;
            public string NewRecoveryScore;
            public string CollectionReceivableDate;
            public string CancellationDate;
            public string CardAnniversaryDate;
            public string WriteOffDate;
            public string LastChargeDate;
            public string HomePurchaseDate;
            public string CustomerLastPaymentDate;
            public string ReinstatementAcceptDate;
            public string Filler1;
            public string ParentOrgCode;
            public string AgencyCode;
            public string FormatCode;

        }
        public MasterRecord validacionMasterRecord(int i)
        {
            MasterRecord masterrecord = new MasterRecord();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                masterrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                masterrecord.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.AccountNumber = "                    ";
                    }
                    else
                        masterrecord.AccountNumber = "                    ";
                }
                else
                    masterrecord.AccountNumber = "                    ";
                /////////////////////////////RECORDTYPE
                masterrecord.RecordType = "M";
                /////////////////////////////SEQUENCENUMBER
                masterrecord.SequenceNumber = "00";

                /////////////////////////////SUITREASON
                masterrecord.SuitReason = "                              ";
                /////////////////////////////JUGMENTDATE
                masterrecord.JudgmentDate = "        ";
                /////////////////////////////CASENUMBER
                masterrecord.CaseNumber = "                    ";
                /////////////////////////////COURTNAME
                masterrecord.CourtName = "                              ";
                /////////////////////////////JUGMENTRECORDED
                masterrecord.JudgmentRecorded = "        ";
                /////////////////////////////JUDGMENTBOOK
                masterrecord.JudgmentBook = "        ";
                /////////////////////////////ACPROGRAM
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram != null)
                //        {
                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().Length < 8)
                //                masterrecord.ACProgram = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().PadRight(8);
                //            else
                //                masterrecord.ACProgram = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().Substring(0, 8);
                //        }
                //        else
                //            masterrecord.ACProgram = "        ";
                //    }
                //    else
                //        masterrecord.ACProgram = "        ";
                //}
                //else
                //    masterrecord.ACProgram = "        ";
                masterrecord.ACProgram = "        ";////////// se agrego fijo

                /////////////////////////////FILLER1
                masterrecord.Filler1 = "        ";
                /////////////////////////////FILLER2
                masterrecord.Filler2 = "               ";
                /////////////////////////////FILLER3
                masterrecord.Filler3 = "        ";

                /////////////////////////////BARDATE
                masterrecord.BarDate = "        ";
                /////////////////////////////DISMISSALDATE
                masterrecord.DismissalDate = "        ";
                /////////////////////////////DISCHARGEDATE
                masterrecord.DischargeDate = "        ";
                /////////////////////////////REAFFIRMATIONDATE
                masterrecord.ReaffirmationDate = "        ";
                /////////////////////////////STAYLIFTEDDATE
                masterrecord.StayLiftedDate = "        ";
                /////////////////////////////BANKRUPTCY
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.assetIndicator != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.assetIndicator.ToString().Length < 20)
                                masterrecord.BankruptcyAssetIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.assetIndicator.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAssetIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.assetIndicator.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAssetIndicator = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAssetIndicator = "                    ";
                }
                else
                    masterrecord.BankruptcyAssetIndicator = "                    ";
                /////////////////////////////STOPDUNNREQUEST
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeAmount != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeAmount.ToString().Length < 20)
                            {
                                masterrecord.StopDunnRequest = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeAmount.ToString()).Replace(".", "").PadRight(20);
                            }
                            else
                            {
                                masterrecord.StopDunnRequest = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeAmount.ToString()).Replace(".", "").Substring(0, 20);
                            }
                        }
                        else
                            masterrecord.StopDunnRequest = "                    ";
                        //if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeDate != null)
                        //{
                        //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeDate.ToString().Length < 5)
                        //    {
                        //        masterrecord.StopDunnRequest = resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeDate.ToString().PadRight(5);
                        //    }
                        //    else
                        //    {
                        //        masterrecord.StopDunnRequest = resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeDate.ToString().Substring(0, 5);
                        //    }
                        //}
                        //else
                        //    masterrecord.StopDunnRequest = "                    ";
                        //if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeType != null)
                        //{
                        //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeType.ToString().Length < 5)
                        //    {
                        //        masterrecord.StopDunnRequest = resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeType.ToString().PadRight(5);
                        //    }
                        //    else
                        //    {
                        //        masterrecord.StopDunnRequest = resultsPlacement.caseInfoList[i].accountInfoList[0].disputeDetails.disputeType.ToString().Substring(0, 5);
                        //    }
                        //}
                        //else
                        //    masterrecord.StopDunnRequest = "                    ";
                    }
                    else
                        masterrecord.StopDunnRequest = "                    ";
                }
                else
                    masterrecord.StopDunnRequest = "                    ";
                /////////////////////////////FDCPACOMPLAINTS
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer != null)
                //        {
                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.offer!=null)
                //            {
                //                if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.ToString().Length < 20)
                //                    masterrecord.FDCPAComplaints = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.offer.ToString().PadRight(20);
                //                else
                //                    masterrecord.FDCPAComplaints = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.oasisoffer.offer.ToString().Substring(0, 20);
                //            }

                //        }
                //        else
                //            masterrecord.FDCPAComplaints = "                    ";
                //    }
                //    else
                //        masterrecord.FDCPAComplaints = "                    ";
                //}
                //else
                //    masterrecord.FDCPAComplaints = "                    ";
                masterrecord.FDCPAComplaints = "                    "; //////se agrego fijo
                /////////////////////////////MINDUEINDICATOR
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.minDueIndicator != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.minDueIndicator.ToString().Length < 11)
                                masterrecord.Mindueindicator = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.minDueIndicator.ToString().PadRight(11);
                            else
                                masterrecord.Mindueindicator = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.minDueIndicator.ToString().Substring(0, 11);
                        }
                        else
                            masterrecord.Mindueindicator = "           ";
                    }
                    else
                        masterrecord.Mindueindicator = "           ";
                }
                else
                    masterrecord.Mindueindicator = "           ";
                /////////////////////////////PROBC
                masterrecord.ProbC = "           ";
                /////////////////////////////OLDLEDINGSCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.lendingPayToCurrrentScore != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.lendingPayToCurrrentScore.ToString().Length < 11)
                                masterrecord.OldLendingScore = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.lendingPayToCurrrentScore.ToString()).Replace(".", "").PadRight(11);
                            else
                                masterrecord.OldLendingScore = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.lendingPayToCurrrentScore.ToString()).Replace(".", "").Substring(0, 11);
                        }
                        else
                            masterrecord.OldLendingScore = "           ";
                    }
                    else
                        masterrecord.OldLendingScore = "           ";
                }
                else
                    masterrecord.OldLendingScore = "           ";
                /////////////////////////////BANCKRUPTCYFILLINGDATE
                masterrecord.BankruptcyFilingDate = "        ";
                /////////////////////////////STATUSOFLIMITATIONS
                masterrecord.StatuteofLimitationsExpirationDate = "        ";
                /////////////////////////////BANKRUPTCY
                masterrecord.BANKRUPTCYUSERDATE3 = "        ";
                /////////////////////////////RETURNMETRIC
                masterrecord.ReturnMetricScore = "           ";
                /////////////////////////////ESTATECLAIM
                masterrecord.EstateClaimFiledFlag = "           ";
                /////////////////////////////TOTALEXPOSURE
                masterrecord.TotalExposure = "           ";
                /////////////////////////////SELINKAGEFLAGS
                masterrecord.SELinkageFlags = "           ";
                /////////////////////////////SPEEDTOPAYMODEL
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().Length < 11)
                                masterrecord.SpeedtoPayModel = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().PadRight(11);
                            else
                                masterrecord.SpeedtoPayModel = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().Substring(0, 11);
                        }
                        else
                            masterrecord.SpeedtoPayModel = "           ";
                    }
                    else
                        masterrecord.SpeedtoPayModel = "           ";
                }
                else
                    masterrecord.SpeedtoPayModel = "           ";
                /////////////////////////////HOMEMOARKETVALUE
                masterrecord.HomeMarketValue = "           ";
                /////////////////////////////HOMEEQUITY
                masterrecord.HomeEquity = "           ";
                /////////////////////////////OLDCHARGESCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalExposure != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalExposure.ToString().Length < 11)
                                masterrecord.OldChargeScore = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalExposure.ToString()).Replace(".", "").PadRight(11);
                            else
                                masterrecord.OldChargeScore = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalExposure.ToString()).Replace(".", "").Substring(0, 11);
                        }
                        else
                            masterrecord.OldChargeScore = "           ";
                    }
                    else
                        masterrecord.OldChargeScore = "           ";
                }
                else
                    masterrecord.OldChargeScore = "           ";
                /////////////////////////////BANKRUPCYATTORNEYNAME
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyNameorExecutorName = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyNameorExecutorName = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyNameorExecutorName = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyNameorExecutorName = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyNameorExecutorName = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYESTATEADDRESS1
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyorEstateAddress1 = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyorEstateAddress1 = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyorEstateAddress1 = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyorEstateAddress1 = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyorEstateAddress1 = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYESTATEADDRES2
                masterrecord.BankruptcyAttorneyorEstateAddress2 = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYESTATECITY
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyorEstateCity = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyorEstateCity = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyorEstateCity = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyorEstateCity = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyorEstateCity = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYESTATESTATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorState != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorState.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyorEstateState = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorState.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyorEstateState = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorState.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyorEstateState = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyorEstateState = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyorEstateState = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYESTATEZIP
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyorEstateZip = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyorEstateZip = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyorEstateZip = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyorEstateZip = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyorEstateZip = "                    ";
                /////////////////////////////BANKRUPCYATTORNEYEXECUTORPHONE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone.ToString().Length < 20)
                                masterrecord.BankruptcyAttorneyorExecutorPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone.ToString().PadRight(20);
                            else
                                masterrecord.BankruptcyAttorneyorExecutorPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.BankruptcyAttorneyorExecutorPhone = "                    ";
                    }
                    else
                        masterrecord.BankruptcyAttorneyorExecutorPhone = "                    ";
                }
                else
                    masterrecord.BankruptcyAttorneyorExecutorPhone = "                    ";
                /////////////////////////////CREDITBALANCEREASON
                masterrecord.CreditBalanceReason = "                    ";
                /////////////////////////////TYPEOFBANK
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.bankruptcyChapter != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.bankruptcyChapter.ToString().Length < 20)
                                masterrecord.TypeofBankruptcyfiling = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.bankruptcyChapter.ToString().PadRight(20);
                            else
                                masterrecord.TypeofBankruptcyfiling = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.bankruptcyChapter.ToString().Substring(0, 20);
                        }
                        else
                            masterrecord.TypeofBankruptcyfiling = "                    ";
                    }
                    else
                        masterrecord.TypeofBankruptcyfiling = "                    ";
                }
                else
                    masterrecord.TypeofBankruptcyfiling = "                    ";
                /////////////////////////////GRMSVARIABLES

                masterrecord.GRMSvariables = "                    ";
                /////////////////////////////DECEASEDDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.deceasedDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.deceasedDate.ToString().Length < 8)
                                masterrecord.DeceasedDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.deceasedDate.ToString().PadRight(8);
                            else
                            {
                                //string px = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.deceasedDate.ToString("MMddyyyy");
                                masterrecord.DeceasedDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.deceasedDate).ToString("yyyyMMdd");
                            }
                        }
                        else
                            masterrecord.DeceasedDate = "        ";
                    }
                    else
                        masterrecord.DeceasedDate = "        ";
                }
                else
                    masterrecord.DeceasedDate = "        ";
                /////////////////////////////DATEOFLEGAL
                masterrecord.DateofLegalFiling = "        ";
                /////////////////////////////LEGALPROCEEDING
                masterrecord.LegalProceedingCourtDate = "        ";
                /////////////////////////////ESTATECLAIMDATE
                masterrecord.EstateClaimDate = "        ";
                /////////////////////////////REINSTATEMENTOFFER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().Length < 8)
                                masterrecord.Reinstatementoffer = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().PadRight(8);
                            else
                                masterrecord.Reinstatementoffer = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel.ToString().Substring(0, 8);
                        }
                        else
                            masterrecord.Reinstatementoffer = "        ";
                    }
                    else
                        masterrecord.Reinstatementoffer = "        ";
                }
                else
                    masterrecord.Reinstatementoffer = "        ";
                /////////////////////////////RECALLWARNINGDATE
                masterrecord.RecallWarningDate = "        ";
                /////////////////////////////BANKRUPTCYCHAPTER
                masterrecord.BankruptcyChapter = "  ";
                /////////////////////////////FILLER4
                masterrecord.Filler4 = "  ";
                /////////////////////////////PARENTORGCODE
                masterrecord.ParentOrgCode = "    ";
                /////////////////////////////AGENCYCODE
                masterrecord.AgencyCode = "    ";
                /////////////////////////////FORMATCODE
                masterrecord.FormatCode = "B";


            }
            return masterrecord;
        }
        public class MasterRecord
        {
            public string AccountNumber;
            public string RecordType;
            public string SequenceNumber;
            public string SuitReason;
            public string JudgmentDate;
            public string CaseNumber;
            public string CourtName;
            public string JudgmentRecorded;
            public string JudgmentBook;
            public string ACProgram;
            public string Filler1;
            public string Filler2;
            public string Filler3;
            public string BarDate;
            public string DismissalDate;
            public string DischargeDate;
            public string ReaffirmationDate;
            public string StayLiftedDate;
            public string BankruptcyAssetIndicator;
            public string StopDunnRequest;
            public string FDCPAComplaints;
            public string Mindueindicator;
            public string ProbC;
            public string OldLendingScore;
            public string BankruptcyFilingDate;
            public string StatuteofLimitationsExpirationDate;
            public string BANKRUPTCYUSERDATE3;
            public string ReturnMetricScore;
            public string EstateClaimFiledFlag;
            public string TotalExposure;
            public string SELinkageFlags;
            public string SpeedtoPayModel;
            public string HomeMarketValue;
            public string HomeEquity;
            public string OldChargeScore;
            public string BankruptcyAttorneyNameorExecutorName;
            public string BankruptcyAttorneyorEstateAddress1;
            public string BankruptcyAttorneyorEstateAddress2;
            public string BankruptcyAttorneyorEstateCity;
            public string BankruptcyAttorneyorEstateState;
            public string BankruptcyAttorneyorEstateZip;
            public string BankruptcyAttorneyorExecutorPhone;
            public string CreditBalanceReason;
            public string TypeofBankruptcyfiling;
            public string GRMSvariables;
            public string DeceasedDate;
            public string DateofLegalFiling;
            public string LegalProceedingCourtDate;
            public string EstateClaimDate;
            public string Reinstatementoffer;
            public string RecallWarningDate;
            public string BankruptcyChapter;
            public string Filler4;
            public string ParentOrgCode;
            public string AgencyCode;
            public string FormatCode;
        }
        public CreditHistory validacionCreditHistory(int i)
        {
            CreditHistory credithistory = new CreditHistory();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                credithistory.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                credithistory.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            credithistory.AccountNumber = "                    ";
                    }
                    else
                        credithistory.AccountNumber = "                    ";
                }
                else
                    credithistory.AccountNumber = "                    ";
                ///////////////////////////RECORDTYPE       
                credithistory.RecordType = "D";
                //////////////////////////SEQUENCENUMBER
                credithistory.SequenceNumber = "00";
                //////////////////////////CYCLECUTDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.cycleCutDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.cycleCutDate.ToString().Length < 8)
                                credithistory.CycleCutDate = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.cycleCutDate.ToString().PadRight(8);
                            else
                            {
                                credithistory.CycleCutDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.cycleCutDate).ToString("yyyyMMdd");
                            }
                        }
                        else
                            credithistory.CycleCutDate = "        ";
                    }
                    else
                        credithistory.CycleCutDate = "        ";
                }
                else
                    credithistory.CycleCutDate = "        ";
                ////////////////////////DUEDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.dueDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.dueDate.ToString().Length < 8)
                                credithistory.DueDate = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.dueDate.ToString().PadRight(8);
                            else
                            {
                                credithistory.DueDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.dueDate).ToString("yyyyMMdd");
                            }
                        }
                        else
                            credithistory.DueDate = "        ";
                    }
                    else
                        credithistory.DueDate = "        ";
                }
                else
                    credithistory.DueDate = "        ";
                ///////////////////////ACCTAGINGINMONTH01
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month01.ToString().Length < 2)
                                    credithistory.AcctAginginmonth01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month01.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month01.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth01 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth01 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth01 = "00";
                }
                else
                    credithistory.AcctAginginmonth01 = "00";

                ///////////////////////ACCTAGINGINMONTH02
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month02 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month02.ToString().Length < 2)
                                    credithistory.AcctAginginmonth02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month02.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month02.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth02 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth02 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth02 = "00";
                }
                else
                    credithistory.AcctAginginmonth02 = "00";
                ///////////////////////ACCTAGINGINMONTH03
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month03 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month03.ToString().Length < 2)
                                    credithistory.AcctAginginmonth03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month03.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month03.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth03 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth03 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth03 = "00";
                }
                else
                    credithistory.AcctAginginmonth03 = "00";

                ///////////////////////ACCTAGINGINMONTH04
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month04 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month04.ToString().Length < 2)
                                    credithistory.AcctAginginmonth04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month04.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month04.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth04 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth04 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth04 = "00";
                }
                else
                    credithistory.AcctAginginmonth04 = "00";

                ///////////////////////ACCTAGINGINMONTH05
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month05 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month05.ToString().Length < 2)
                                    credithistory.AcctAginginmonth05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month05.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month05.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth05 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth05 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth05 = "00";
                }
                else
                    credithistory.AcctAginginmonth05 = "00";

                ///////////////////////ACCTAGINGINMONTH06
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month06 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month06.ToString().Length < 2)
                                    credithistory.AcctAginginmonth06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month06.ToString().PadRight(2, '0');
                                else
                                    credithistory.AcctAginginmonth06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month06.ToString().Substring(0, 2);
                            }
                            else
                                credithistory.AcctAginginmonth06 = "00";
                        }
                        else
                            credithistory.AcctAginginmonth06 = "00";
                    }
                    else
                        credithistory.AcctAginginmonth06 = "00";
                }
                else
                    credithistory.AcctAginginmonth06 = "00";

                credithistory.Filler1 = "00";
                credithistory.Filler2 = "00";
                credithistory.Filler3 = "00";
                credithistory.Filler4 = "00";
                //////////////////////////FILLER5
                //if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                //{
                //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                //    {
                //        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram != null)
                //        {
                //            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().Length < 2)
                //                credithistory.Filler5 = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().PadRight(2,'0');
                //            else
                //                credithistory.Filler5 = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.accountCreditProgram.ToString().Substring(0, 2);
                //        }
                //        else
                //            credithistory.Filler5 = "00";
                //    }
                //    else
                //        credithistory.Filler5 = "00";
                //}
                //else
                //    credithistory.Filler5 = "00";
                credithistory.Filler5 = "00"; ////se agrego fijo
                credithistory.Ability = "00";
                //////////////////////////SUMMARYMONTH1.
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month01.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month01.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month01.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth1 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth1 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth1 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth1 = "0000000000000";
                //////////////////////////SUMMARYMONTh2
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month02 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month02.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month02.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month02.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth2 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth2 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth2 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth2 = "0000000000000";
                //////////////////////////SUMMARYMONTh3
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month03 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month03.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month03.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month03.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth3 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth3 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth3 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth3 = "0000000000000";
                //////////////////////////SUMMARYMONTh4
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month04 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month04.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month04.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month04.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth4 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth4 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth4 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth4 = "0000000000000";
                //////////////////////////SUMMARYMONTh5
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month05 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month05.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month05.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month05.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth5 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth5 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth5 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth5 = "0000000000000";
                //////////////////////////SUMMARYMONTh6
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month06 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month06.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month06.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month06.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth6 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth6 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth6 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth6 = "0000000000000";
                //////////////////////////SUMMARYMONTh7
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month07 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month07.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month07.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month07.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth7 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth7 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth7 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth7 = "0000000000000";
                //////////////////////////SUMMARYMONTh8
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month08 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month08.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month08.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month08.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth8 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth8 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth8 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth8 = "0000000000000";
                //////////////////////////SUMMARYMONTh9
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month09 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month09.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month09.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month09.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth9 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth9 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth9 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth9 = "0000000000000";
                //////////////////////////SUMMARYMONTh10
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month10 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month10.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month10.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month10.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth10 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth10 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth10 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth10 = "0000000000000";
                //////////////////////////SUMMARYMONTh11
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month11 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month11.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth11 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month11.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth11 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month11.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth11 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth11 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth11 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth11 = "0000000000000";
                //////////////////////////SUMMARYMONTh12
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month12 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month12.ToString().Length < 13)
                                    credithistory.Summarycreditinmonth12 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month12.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarycreditinmonth12 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month12.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarycreditinmonth12 = "0000000000000";
                        }
                        else
                            credithistory.Summarycreditinmonth12 = "0000000000000";
                    }
                    else
                        credithistory.Summarycreditinmonth12 = "0000000000000";
                }
                else
                    credithistory.Summarycreditinmonth12 = "0000000000000";

                //////////////////////////BALANCEMONTH01
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month01.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth01 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month01.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth01 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month01.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth01 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth01 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth01 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth01 = "0000000000000";
                //////////////////////////BALANCEMONTH2
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month02 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month02.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth02 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month02.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth02 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month02.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth02 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth02 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth02 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth02 = "0000000000000";
                //////////////////////////BALANCEMONTH3
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month03 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month03.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth03 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month03.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth03 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month03.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth03 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth03 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth03 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth03 = "0000000000000";
                //////////////////////////BALANCEMONTH4
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month04 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month04.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth04 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month04.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth04 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month04.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth04 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth04 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth04 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth04 = "0000000000000";
                //////////////////////////BALANCEMONTH5
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month05 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month05.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth05 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month05.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth05 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month05.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth05 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth05 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth05 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth05 = "0000000000000";
                //////////////////////////BALANCEMONTH6
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month06 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month06.ToString().Length < 13)
                                    credithistory.AcctBalanceinmonth06 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month06.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AcctBalanceinmonth06 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month06.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AcctBalanceinmonth06 = "0000000000000";
                        }
                        else
                            credithistory.AcctBalanceinmonth06 = "0000000000000";
                    }
                    else
                        credithistory.AcctBalanceinmonth06 = "0000000000000";
                }
                else
                    credithistory.AcctBalanceinmonth06 = "0000000000000";
                //////////////////////////ASSESSEDLASTMONTH1
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString().Length < 13)
                                    credithistory.AssessedLastMonth = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.AssessedLastMonth = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.AssessedLastMonth = "0000000000000";
                        }
                        else
                            credithistory.AssessedLastMonth = "0000000000000";
                    }
                    else
                        credithistory.AssessedLastMonth = "0000000000000";
                }
                else
                    credithistory.AssessedLastMonth = "0000000000000";
                //////////////////////////ASSESSEDLASTMONTH2
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month02 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month02.ToString().Length < 13)
                                    credithistory.Assessed2MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month02.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Assessed2MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month02.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Assessed2MonthsAgo = "0000000000000";
                        }
                        else
                            credithistory.Assessed2MonthsAgo = "0000000000000";
                    }
                    else
                        credithistory.Assessed2MonthsAgo = "0000000000000";
                }
                else
                    credithistory.Assessed2MonthsAgo = "0000000000000";
                //////////////////////////ASSESSEDLASTMONTH3
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month03 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month03.ToString().Length < 13)
                                    credithistory.Assessed3MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month03.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Assessed3MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month03.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Assessed3MonthsAgo = "0000000000000";
                        }
                        else
                            credithistory.Assessed3MonthsAgo = "0000000000000";
                    }
                    else
                        credithistory.Assessed3MonthsAgo = "0000000000000";
                }
                else
                    credithistory.Assessed3MonthsAgo = "0000000000000";
                //////////////////////////ASSESSEDLASTMONTH4
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString().Length < 13)
                                    credithistory.Assessed4MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Assessed4MonthsAgo = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.interestAccessedByMonth.Month01.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Assessed4MonthsAgo = "0000000000000";
                        }
                        else
                            credithistory.Assessed4MonthsAgo = "0000000000000";
                    }
                    else
                        credithistory.Assessed4MonthsAgo = "0000000000000";
                }
                else
                    credithistory.Assessed4MonthsAgo = "0000000000000";

                credithistory.Filler6 = "0000000000000";
                credithistory.Filler7 = "0000000000000";

                //////////////////////////DEBITMONTH1
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month01 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month01.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month01.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth1 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month01.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth1 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth1 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth1 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth1 = "0000000000000";
                //////////////////////////DEBITMONTH2
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month02 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month02.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month02.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth2 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month02.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth2 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth2 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth2 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth2 = "0000000000000";
                //////////////////////////DEBITMONTH3
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month03 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month03.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month03.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth3 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month03.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth3 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth3 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth3 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth3 = "0000000000000";
                //////////////////////////DEBITMONTH4
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month04 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month04.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month04.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth4 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month04.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth4 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth4 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth4 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth4 = "0000000000000";
                //////////////////////////DEBITMONTH5
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month05 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month05.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month05.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth5 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month05.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth5 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth5 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth5 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth5 = "0000000000000";

                //////////////////////////DEBITMONTH6
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month06 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month06.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month06.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth6 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month06.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth6 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth6 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth6 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth6 = "0000000000000";
                //////////////////////////DEBITMONTH7
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month07 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month07.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month07.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth7 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month07.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth7 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth7 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth7 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth7 = "0000000000000";
                //////////////////////////DEBITMONTH8
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month08 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month08.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month08.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth8 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month08.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth8 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth8 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth8 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth8 = "0000000000000";
                //////////////////////////DEBITMONTH9
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month09 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month09.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month09.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth9 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month09.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth9 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth9 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth9 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth9 = "0000000000000";
                //////////////////////////DEBITMONTH10
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month10 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month10.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month10.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth10 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month10.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth10 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth10 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth10 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth10 = "0000000000000";
                //////////////////////////DEBITMONTH11
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month11 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month11.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth11 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month11.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth11 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month11.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth11 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth11 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth11 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth11 = "0000000000000";
                //////////////////////////DEBITMONTH12
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month12 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month12.ToString().Length < 13)
                                    credithistory.Summarydebitsinmonth12 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month12.ToString()).Replace(".", "").PadRight(13, '0');
                                else
                                    credithistory.Summarydebitsinmonth12 = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month12.ToString()).Replace(".", "").Substring(0, 13);
                            }
                            else
                                credithistory.Summarydebitsinmonth12 = "0000000000000";
                        }
                        else
                            credithistory.Summarydebitsinmonth12 = "0000000000000";
                    }
                    else
                        credithistory.Summarydebitsinmonth12 = "0000000000000";
                }
                else
                    credithistory.Summarydebitsinmonth12 = "0000000000000";


                //////////////////////////CREDITORFIELD
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.bankType != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.bankType.ToString().Length < 2)
                                credithistory.CreditorField = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.bankType.ToString().PadRight(2, '0');
                            else
                                credithistory.CreditorField = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.bankType.ToString().Substring(0, 2);
                        }
                        else
                            credithistory.CreditorField = "00";
                    }
                    else
                        credithistory.CreditorField = "00";
                }
                else
                    credithistory.CreditorField = "00";

                credithistory.FutureUse_CreditLimit = "0000000000000";

                //////////////////////////CREDITORFIELD
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.waiverOrGuaranteed != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.waiverOrGuaranteed.ToString().Length < 2)
                                credithistory.WAIVERORGUARANTEED = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.waiverOrGuaranteed.ToString().PadRight(2, '0');
                            else
                                credithistory.WAIVERORGUARANTEED = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.waiverOrGuaranteed.ToString().Substring(0, 2);
                        }
                        else
                            credithistory.WAIVERORGUARANTEED = "00";
                    }
                    else
                        credithistory.WAIVERORGUARANTEED = "00";
                }
                else
                    credithistory.WAIVERORGUARANTEED = "00";

                credithistory.LifeInsuranceIndicator = "00";

                //////////////////////////LIABILITY
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.liability != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.liability.ToString().Length < 2)
                                credithistory.Liability = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.liability.ToString().PadRight(2, '0');
                            else
                                credithistory.Liability = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.liability.ToString().Substring(0, 2);
                        }
                        else
                            credithistory.Liability = "00";
                    }
                    else
                        credithistory.Liability = "00";
                }
                else
                    credithistory.Liability = "00";
                //////////////////////////LARGEORMIDDLE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.largeOrMiddleMarket != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.largeOrMiddleMarket.ToString().Length < 2)
                                credithistory.LargeorMiddlemarket = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.largeOrMiddleMarket.ToString().PadRight(2, '0');
                            else
                                credithistory.LargeorMiddlemarket = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.largeOrMiddleMarket.ToString().Substring(0, 2);
                        }
                        else
                            credithistory.LargeorMiddlemarket = "00";
                    }
                    else
                        credithistory.LargeorMiddlemarket = "00";
                }
                else
                    credithistory.LargeorMiddlemarket = "00";
                //////////////////////////CYCLECUT
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.cycleCut != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.cycleCut.ToString().Length < 2)
                                credithistory.CycleCut = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.cycleCut.ToString().PadRight(2, '0');
                            else
                                credithistory.CycleCut = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.cycleCut.ToString().Substring(0, 2);
                        }
                        else
                            credithistory.CycleCut = "00";
                    }
                    else
                        credithistory.CycleCut = "00";
                }
                else
                    credithistory.CycleCut = "00";

                credithistory.Exposure_CCSG = "0000000000000";
                credithistory.Exposure_OPEN = "0000000000000";
                credithistory.TotalExposure = "0000000000000";
                credithistory.Filler8 = "0000000000000";
                credithistory.Filler9 = "0000000000000";
                credithistory.Filler10 = "00000000000";
                credithistory.DebttoValueRatio = "00000000000";
                credithistory.Filler11 = "        ";
                credithistory.Filler12 = "        ";
                credithistory.Filler13 = "   ";
                credithistory.Filler14 = "           ";
                credithistory.Filler15 = "        ";
                credithistory.Filler16 = "          ";
                credithistory.Parent_OrgCode = "    ";
                credithistory.AgencyCode = "    ";
                credithistory.FormatCode = "B";
            }
            return credithistory;
        }
        public class CreditHistory
        {
            public string AccountNumber;
            public string RecordType;
            public string SequenceNumber;
            public string CycleCutDate;
            public string DueDate;
            public string AcctAginginmonth01;
            public string AcctAginginmonth02;
            public string AcctAginginmonth03;
            public string AcctAginginmonth04;
            public string AcctAginginmonth05;
            public string AcctAginginmonth06;
            public string Filler1;
            public string Filler2;
            public string Filler3;
            public string Filler4;
            public string Filler5;
            public string Ability;
            public string Summarycreditinmonth1;
            public string Summarycreditinmonth2;
            public string Summarycreditinmonth3;
            public string Summarycreditinmonth4;
            public string Summarycreditinmonth5;
            public string Summarycreditinmonth6;
            public string Summarycreditinmonth7;
            public string Summarycreditinmonth8;
            public string Summarycreditinmonth9;
            public string Summarycreditinmonth10;
            public string Summarycreditinmonth11;
            public string Summarycreditinmonth12;
            public string AcctBalanceinmonth01;
            public string AcctBalanceinmonth02;
            public string AcctBalanceinmonth03;
            public string AcctBalanceinmonth04;
            public string AcctBalanceinmonth05;
            public string AcctBalanceinmonth06;
            public string AssessedLastMonth;
            public string Assessed2MonthsAgo;
            public string Assessed3MonthsAgo;
            public string Assessed4MonthsAgo;
            public string Filler6;
            public string Filler7;
            public string Summarydebitsinmonth1;
            public string Summarydebitsinmonth2;
            public string Summarydebitsinmonth3;
            public string Summarydebitsinmonth4;
            public string Summarydebitsinmonth5;
            public string Summarydebitsinmonth6;
            public string Summarydebitsinmonth7;
            public string Summarydebitsinmonth8;
            public string Summarydebitsinmonth9;
            public string Summarydebitsinmonth10;
            public string Summarydebitsinmonth11;
            public string Summarydebitsinmonth12;
            public string CreditorField;
            public string FutureUse_CreditLimit;
            public string WAIVERORGUARANTEED;
            public string LifeInsuranceIndicator;
            public string Liability;
            public string LargeorMiddlemarket;
            public string CycleCut;
            public string Exposure_CCSG;
            public string Exposure_OPEN;
            public string TotalExposure;
            public string Filler8;
            public string Filler9;
            public string Filler10;
            public string DebttoValueRatio;
            public string Filler11;
            public string Filler12;
            public string Filler13;
            public string Filler14;
            public string Filler15;
            public string Filler16;
            public string Parent_OrgCode;
            public string AgencyCode;
            public string FormatCode;
        }
        public History ValidacionHistory(int i)
        {
            History history = new History();
            if (resultsPlacement.caseInfoList != null)
            {
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                history.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                history.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            history.AccountNumber = "                    ";
                    }
                    else
                        history.AccountNumber = "                    ";
                }
                else
                    history.AccountNumber = "                    ";
                history.RecordType = "H";
                history.SequenceNumber = "00";
                for (int ii = 0; ii < 13; ii++)
                {
                    string date = DateTime.Now.ToString("yyyyMMdd");
                    string note = "                                        ";
                    history.Date_NoteLine = history.Date_NoteLine + date + note;
                }

                history.Filler = "                                                ";
                history.AgencyCode = "    ";
                history.FormatCode = "B";
            }

            return history;
        }
        public class History
        {
            public string AccountNumber;
            public string RecordType;
            public string SequenceNumber;
            public string Date_NoteLine;
            public string Filler;
            public string AgencyCode;
            public string FormatCode;
        }
        public AccountMaster ValidacionAccountMaster(int i)
        {
            AccountMaster accountMaster = new AccountMaster();
            if (resultsPlacement.caseInfoList != null)
            {
                //////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                accountMaster.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                accountMaster.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                        else
                            accountMaster.AccountNumber = "                    ";
                    }
                    else
                        accountMaster.AccountNumber = "                    ";
                }
                else
                    accountMaster.AccountNumber = "                    ";

                //////RECORDTYPE
                accountMaster.RecordType = "A";
                //////////////////SEQUENCENUMBER
                accountMaster.SequenceNumber = "00";
                //////////////////TITLE
                accountMaster.Title = "    ";
                //////////////////CUSTOMERTYPE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.cardMemberType != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.cardMemberType.ToString().Length < 1)
                                accountMaster.CustomerType = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.cardMemberType.ToString().PadRight(1);
                            else
                                accountMaster.CustomerType = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.cardMemberType.ToString().Substring(0, 1);
                        }
                        else
                            accountMaster.CustomerType = " ";
                    }
                    else
                        accountMaster.CustomerType = " ";
                }
                else
                    accountMaster.CustomerType = " ";
                //////////////////NAME
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().Length < 25)
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().PadRight(25);
                                else
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().Substring(0, 25);
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().Length < 15)
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().PadRight(15);
                                else
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().Substring(0, 15);
                                accountMaster.Name = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName + resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName;
                            }
                            else
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().Length < 25)
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().PadRight(25);
                                else
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().Substring(0, 25);
                                accountMaster.Name = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName + "               ";
                            }

                        }
                        else
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().Length < 15)
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().PadRight(15);
                                else
                                    resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().Substring(0, 15);
                                accountMaster.Name = resultsPlacement.caseInfoList[i].accountInfoList[0].relatedPerson.relatedPersonDetailsList[0].lastName + "                         ";
                            }
                            else
                            {
                                accountMaster.Name = "                                        ";
                            }
                        }
                    }
                    else
                    {
                        accountMaster.Name = "                                        ";
                    }
                }
                else
                {
                    accountMaster.Name = "                                        ";
                }

                //////////////////ACCOUNTADDRESS1
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine1 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine1.ToString().Length < 25)
                                    accountMaster.AccountAddress1 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine1.ToString().PadRight(25);
                                else
                                    accountMaster.AccountAddress1 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine1.ToString().Substring(0, 25);
                            }
                            else
                                accountMaster.AccountAddress1 = "                         ";
                        }
                        else
                            accountMaster.AccountAddress1 = "                         ";
                    }
                    else
                        accountMaster.AccountAddress1 = "                         ";
                }
                else
                    accountMaster.AccountAddress1 = "                         ";

                //////////////////ACCOUNTADDRESS2
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine2 != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine2.ToString().Length < 25)
                                    accountMaster.AccountAddress2 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine2.ToString().PadRight(25);
                                else
                                    accountMaster.AccountAddress2 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].addressLine2.ToString().Substring(0, 25);
                            }
                            else
                                accountMaster.AccountAddress2 = "                         ";
                        }
                        else
                            accountMaster.AccountAddress2 = "                         ";
                    }
                    else
                        accountMaster.AccountAddress2 = "                         ";
                }
                else
                    accountMaster.AccountAddress2 = "                         ";

                //////////////////CITY
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].city != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].city.ToString().Length < 20)
                                    accountMaster.City = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].city.ToString().PadRight(20);
                                else
                                    accountMaster.City = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].city.ToString().Substring(0, 20);
                            }
                            else
                                accountMaster.City = "                    ";
                        }
                        else
                            accountMaster.City = "                    ";
                    }
                    else
                        accountMaster.City = "                    ";
                }
                else
                    accountMaster.City = "                    ";

                //////////////////COUNTY
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].country != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].country.ToString().Length < 15)
                                    accountMaster.County = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].country.ToString().PadRight(15);
                                else
                                    accountMaster.County = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].country.ToString().Substring(0, 15);
                            }
                            else
                                accountMaster.County = "               ";
                        }
                        else
                            accountMaster.County = "               ";
                    }
                    else
                        accountMaster.County = "               ";
                }
                else
                    accountMaster.County = "               ";


                //////////////////STATE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].state != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].state.ToString().Length < 2)
                                    accountMaster.State = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].state.ToString().PadRight(2);
                                else
                                    accountMaster.State = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].state.ToString().Substring(0, 2);
                            }
                            else
                                accountMaster.State = "  ";
                        }
                        else
                            accountMaster.State = "  ";
                    }
                    else
                        accountMaster.State = "  ";
                }
                else
                    accountMaster.State = "  ";


                //////////////////ZIPCODE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].zipCode != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].zipCode.ToString().Length < 10)
                                    accountMaster.ZipCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].zipCode.ToString().PadRight(10);
                                else
                                    accountMaster.ZipCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[0].zipCode.ToString().Substring(0, 10);
                            }
                            else
                                accountMaster.ZipCode = "          ";
                        }
                        else
                            accountMaster.ZipCode = "          ";
                    }
                    else
                        accountMaster.ZipCode = "          ";
                }
                else
                    accountMaster.ZipCode = "          ";


                //////////////////HOMEPHONE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            int valor = 0;
                            for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode == "H-Home")
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number != null)
                                    {
                                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Length < 16)
                                        {
                                            accountMaster.HomePhone = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().PadRight(16);
                                        }
                                        else
                                            accountMaster.HomePhone = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Substring(0, 16);
                                        valor = 1;
                                    }
                                }
                            }
                            if (valor == 0)
                            {
                                accountMaster.HomePhone = "                ";
                            }


                        }
                        else
                            accountMaster.HomePhone = "                ";
                    }
                    else
                        accountMaster.HomePhone = "                ";
                }
                else
                    accountMaster.HomePhone = "                ";

                //////////////////WORKPHONE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                        {
                            int valor = 0;
                            for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode == "B-BUS")
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number != null)
                                    {
                                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Length < 16)
                                        {
                                            accountMaster.WorkPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().PadRight(16);
                                        }
                                        else
                                            accountMaster.WorkPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Substring(0, 16);
                                        valor = 1;
                                    }
                                }
                            }
                            if (valor == 0)
                            {
                                accountMaster.WorkPhone = "                ";
                            }
                        }
                        else
                            accountMaster.WorkPhone = "                ";
                    }
                    else
                        accountMaster.WorkPhone = "                ";
                }
                else
                    accountMaster.WorkPhone = "                ";

                //////////////////BIRTHDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.birthDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.birthDate.ToString().Length < 8)
                                accountMaster.BirthDate = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.birthDate.ToString().PadRight(8);
                            else
                                accountMaster.BirthDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.birthDate).ToString("yyyyMMdd");
                        }
                        else
                            accountMaster.BirthDate = "        ";

                    }
                    else
                        accountMaster.BirthDate = "        ";
                }
                else
                    accountMaster.BirthDate = "        ";

                //////////////////EMPLOYERNAME
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer.name != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer.name.ToString().Length < 40)
                                accountMaster.EmployerName = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.name.ToString().PadRight(40);
                            else
                                accountMaster.EmployerName = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.name.ToString().Substring(0, 40);
                        }
                        else
                            accountMaster.EmployerName = "                                        ";
                    }
                    else
                        accountMaster.EmployerName = "                                        ";

                }
                else
                    accountMaster.EmployerName = "                                        ";

                //////////////////EMPLOYERADDRESS
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer != null)
                    {


                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address.ToString().Length < 40)
                                accountMaster.EmployerAddress = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address.ToString().PadRight(40);
                            else
                                accountMaster.EmployerAddress = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address.ToString().Substring(0, 40);
                        }
                        else
                            accountMaster.EmployerAddress = "                                        ";

                    }
                    else
                        accountMaster.EmployerAddress = "                                        ";
                }
                else
                    accountMaster.EmployerAddress = "                                        ";

                //////////////////PRODUCTCODE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().Length < 4)
                                accountMaster.ProductCode = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().PadRight(4);
                            else
                                accountMaster.ProductCode = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().Substring(0, 4);
                        }
                        else
                            accountMaster.ProductCode = "    ";

                    }
                    else
                        accountMaster.ProductCode = "    ";
                }
                else
                    accountMaster.ProductCode = "    ";

                //////////////////OFFICERCODE
                if (resultsPlacement.caseInfoList[i].accountInfoList[0] != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.amexPortfolioOrLendingOfficerCode != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.amexPortfolioOrLendingOfficerCode.ToString().Length < 6)
                                accountMaster.OfficerCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.amexPortfolioOrLendingOfficerCode.ToString().PadRight(6);
                            else
                                accountMaster.OfficerCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.amexPortfolioOrLendingOfficerCode.ToString().Substring(0, 6);
                        }
                        else
                            accountMaster.OfficerCode = "      ";

                    }
                    else
                        accountMaster.OfficerCode = "      ";
                }
                else
                    accountMaster.OfficerCode = "      ";

                //////////////////DEFINEDCODE2
                accountMaster.DefinedCode2 = "          ";
                //////////////////RECOVERERCODE

                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId != null)
                        {
                            accountMaster.RecovererCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId.ToString().Substring(2, 4);
                        }
                    }
                }
                //accountMaster.RecovererCode = "    ";/////////////
                //////////////////PHONEFLAG
                accountMaster.PHONEflag = "                ";
                //////////////////REASONCODE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.chargeOffReasonCode != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.chargeOffReasonCode.ToString().Length < 4)
                                accountMaster.ReasonCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.chargeOffReasonCode.ToString().PadRight(4);
                            else
                                accountMaster.ReasonCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.chargeOffReasonCode.ToString().Substring(0, 4);
                        }
                        else
                            accountMaster.ReasonCode = "    ";

                    }
                    else
                        accountMaster.ReasonCode = "    ";
                }
                else
                    accountMaster.ReasonCode = "    ";

                //////////////////ACCOUNTSTATUS
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().Length < 3)
                                accountMaster.AccountStatus = resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().PadRight(3);
                            else
                                accountMaster.AccountStatus = resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().Substring(0, 3);
                        }
                        else
                            accountMaster.AccountStatus = "   ";

                    }
                    else
                        accountMaster.AccountStatus = "   ";
                }
                else
                    accountMaster.AccountStatus = "   ";

                //////////////////INTERESTRATE
                accountMaster.InterestRate = "    ";
                //////////////////SOURCECODE
                accountMaster.SourceCode = "A";
                //////////////////RECEIPTDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().Length < 8)
                                accountMaster.ReceiptDate = resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().PadRight(8);
                            else
                                accountMaster.ReceiptDate = resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.casePurpose.ToString().Substring(0, 8);
                        }
                        else
                            accountMaster.ReceiptDate = "        ";

                    }
                    else
                        accountMaster.ReceiptDate = "        ";
                }
                else
                    accountMaster.ReceiptDate = "        ";

                //////////////////CONTRACTDATE
                accountMaster.ContractDate = "        ";
                //////////////////CHARGEDATE
                accountMaster.ChargeDate = "        ";
                //////////////////LASTPAYMENTDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.lastPaymentDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.lastPaymentDate.ToString().Length < 8)
                                accountMaster.LastPaymentDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.lastPaymentDate.ToString().PadRight(8);
                            else
                                accountMaster.LastPaymentDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.lastPaymentDate).ToString("yyyyMMdd").PadRight(8);
                        }
                        else
                            accountMaster.LastPaymentDate = "        ";

                    }
                    else
                        accountMaster.LastPaymentDate = "        ";
                }
                else
                    accountMaster.LastPaymentDate = "        ";

                //////////////////CHARGEAMOUNT
                accountMaster.ChargeAmount = "          ";
                //////////////////ASSOCIATEDCOSTS
                accountMaster.AssociatedCosts = "         ";
                //////////////////ACCRUEDINTEREST
                accountMaster.AccruedInterest = "         ";
                //////////////////CURRENTBALANCE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentBalance != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentBalance.ToString().Length < 10)
                                accountMaster.CurrentBalance = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentBalance.ToString()).Replace(".", "").PadRight(10);
                            else
                                accountMaster.CurrentBalance = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentBalance.ToString()).Replace(".", "").Substring(0, 10);
                        }
                        else
                            accountMaster.CurrentBalance = "          ";

                    }
                    else
                        accountMaster.CurrentBalance = "          ";
                }
                else
                    accountMaster.CurrentBalance = "          ";


                //accountMaster.CurrentBalance = "          ";
                //////////////////NETPRINCIPAL
                accountMaster.NetPrincipal = "         ";
                //////////////////NETASSOCIATEDCOSTS
                accountMaster.NetAssociatedCosts = "         ";
                //////////////////NETINTEREST
                accountMaster.NetInterest = "         ";
                //////////////////LASTCOMMENTLINE1
                accountMaster.LastCommentLine1 = "                                        ";
                //////////////////LASTCOMMENTLINE2
                accountMaster.LastCommentLine2 = "                                        ";
                //////////////////LASTCOMMENTLINE3
                accountMaster.LastCommentLine3 = "                                        ";
                //////////////////LASTCOMMENTDATE
                accountMaster.LastCommentDate = "        ";
                //////////////////SECONDNAMELASTNAME
                accountMaster.SecondNameLastName = "                         ";
                //////////////////SECONDNAMESFIRSTNAME
                accountMaster.SecondNamesFirstName = "               ";
                //////////////////MONTHLYINCOME
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.monthlyIncome != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.monthlyIncome.ToString().Length < 9)
                                accountMaster.MonthlyIncome = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.monthlyIncome.ToString()).Replace(".", "").PadRight(9);
                            else
                                accountMaster.MonthlyIncome = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.monthlyIncome.ToString()).Replace(".", "").Substring(0, 9);
                        }
                        else
                            accountMaster.MonthlyIncome = "         ";

                    }
                    else
                        accountMaster.MonthlyIncome = "         ";
                }
                else
                    accountMaster.MonthlyIncome = "         ";

                //////////////////OTHERINCOME
                accountMaster.OtherIncome = "         ";
                //////////////////MONTHLYPAYMENT
                accountMaster.MonthlyPayment = "         ";
                //////////////////OTHEROBLIGATIONS
                accountMaster.OtherObligations = "         ";
                //////////////////OWNRENTCODE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.rentOrOwn != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.rentOrOwn.ToString().Length < 1)
                                accountMaster.OwnRentCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.rentOrOwn.ToString().PadRight(1);
                            else
                                accountMaster.OwnRentCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.rentOrOwn.ToString().Substring(0, 1);
                        }
                        else
                            accountMaster.OwnRentCode = " ";

                    }
                    else
                        accountMaster.OwnRentCode = " ";
                }
                else
                    accountMaster.OwnRentCode = " ";

                //////////////////RETURNMETRICSCORE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.collectibilityScore != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.collectibilityScore.ToString().Length < 4)
                                accountMaster.ReturnMetricScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.collectibilityScore.ToString().PadRight(4);
                            else
                                accountMaster.ReturnMetricScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.collectibilityScore.ToString().Substring(0, 4);
                        }
                        else
                            accountMaster.ReturnMetricScore = "    ";

                    }
                    else
                        accountMaster.ReturnMetricScore = "    ";
                }
                else
                    accountMaster.ReturnMetricScore = "    ";

                //////////////////NEXTPAYMENTDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.nextPaymentDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.nextPaymentDate.ToString().Length < 8)
                                accountMaster.NextPaymentDate = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.nextPaymentDate.ToString().PadRight(8);
                            else
                                accountMaster.NextPaymentDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.nextPaymentDate).ToString("yyyyMMdd");
                        }
                        else
                            accountMaster.NextPaymentDate = "        ";

                    }
                    else
                        accountMaster.NextPaymentDate = "        ";
                }
                else
                    accountMaster.NextPaymentDate = "        ";

                //////////////////LASTINTERESTDATE
                accountMaster.LastInterestDate = "        ";
                //////////////////LASTCONTACTDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.lastReviewedDate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.lastReviewedDate.ToString().Length < 8)
                                accountMaster.LastContactDate = resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.lastReviewedDate.ToString().PadRight(8);
                            else
                                accountMaster.LastContactDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].acornCase.lastReviewedDate).ToString("yyyyMMdd");
                        }
                        else
                            accountMaster.LastContactDate = "        ";

                    }
                    else
                        accountMaster.LastContactDate = "        ";
                }
                else
                    accountMaster.LastContactDate = "        ";

                //////////////////COMMISSIONRATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.commissionRate != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].account.commissionRate.ToString().Length < 4)
                                accountMaster.CommissionRate = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.commissionRate.ToString()).Replace(".", "").PadRight(4);
                            else
                                accountMaster.CommissionRate = DoFormat(resultsPlacement.caseInfoList[i].accountInfoList[0].account.commissionRate.ToString()).Replace(".", "").Substring(0, 4);
                        }
                        else
                            accountMaster.CommissionRate = "    ";

                    }
                    else
                        accountMaster.CommissionRate = "    ";
                }
                else
                    accountMaster.CommissionRate = "    ";

                //////////////////FILLER1
                accountMaster.Filler1 = " ";
                //////////////////FILLER2
                accountMaster.Filler2 = " ";
                //////////////////FILLER3
                accountMaster.Filler3 = " ";
                //////////////////CUSTOMERID
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {

                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.customerId != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.customerId.ToString().Length < 16)
                                accountMaster.CustomerID = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.customerId.ToString().PadRight(16);
                            else
                                accountMaster.CustomerID = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.customerId.ToString().Substring(0, 16);
                        }
                        else
                            accountMaster.CustomerID = "                ";

                    }
                    else
                        accountMaster.CustomerID = "                ";
                }
                else
                    accountMaster.CustomerID = "                ";

                //////////////////FILLER4
                accountMaster.Filler4 = "     ";
                //////////////////AGENCYCODE
                accountMaster.AgencyCode = "    ";
                //////////////////FORMATCODE
                accountMaster.FormatCode = "B";

            }

            return accountMaster;
        }
        public class ArchivoMTFIinancial
        {
            public string DATE = "        ";
            public string TIME = "    ";
            public string ACCOUNTNUMBER = "                    ";
            public string TRANSACTION_CODE = "  ";
            public string TRANSACTION_AMOUNT = "          ";
            public string FLAG = " ";
            public string SELF = " ";
            public string DESCRIPCION = "                    ";
            public string PAYMENT = "          ";
            public string PERCENT = "    ";
            public string FLAG_INT_EXT = " ";            
            public string RECOVERER_CODE = "    ";
            public string RECOVERER_ID = "        ";
            public string LOAN_CODE = "    ";
            public string FILL = "   ";

        }
        public class ArchivoRecall
        {
            public string DATE = "        ";
            public string TIME = "    ";
            public string ACCOUNTNUMBER = "                    ";
            public string TRANSACTION_CODE = "AR";
            public string FIELD_CODE = "RECALL";
            public string FILL = "                                        ";
            public string FLAG = " ";
            public string RECOVERER_CODE = "    "; 
            public string RECOVERER_ID = "RMSAMX  ";
            public string LOAN_CODE = "    ";
            public string FILLER = "   ";

        }
        public class ArchivoMT
        {
            public string DATE = "        ";
            public string TIME = "    ";
            public string ACCOUNTNUMBER = "                    ";
            public string TRANSACTION_CODE = "  ";
            public string FIELD_CODE = "      ";
            public string NEW_VALUE = "                                        ";
            public string FLAG = " ";
            public string RECOVERER_CODE = "    ";
            public string RECOVERER_ID = "        ";
            public string LOAN_CODE = "    ";
            public string FILL = "   ";

        }
        public class AccountMaster
        {
            public string AccountNumber;
            public string RecordType;
            public string SequenceNumber;
            public string Title;
            public string CustomerType;
            public string Name;
            public string AccountAddress1;
            public string AccountAddress2;
            public string City;
            public string County;
            public string State;
            public string ZipCode;
            public string HomePhone;
            public string WorkPhone;
            public string BirthDate;
            public string EmployerName;
            public string EmployerAddress;
            public string ProductCode;
            public string OfficerCode;
            public string DefinedCode2;
            public string RecovererCode;
            public string PHONEflag;
            public string ReasonCode;
            public string AccountStatus;
            public string InterestRate;
            public string SourceCode;
            public string ReceiptDate;
            public string ContractDate;
            public string ChargeDate;
            public string LastPaymentDate;
            public string ChargeAmount;
            public string AssociatedCosts;
            public string AccruedInterest;
            public string CurrentBalance;
            public string NetPrincipal;
            public string NetAssociatedCosts;
            public string NetInterest;
            public string LastCommentLine1;
            public string LastCommentLine2;
            public string LastCommentLine3;
            public string LastCommentDate;
            public string SecondNameLastName;
            public string SecondNamesFirstName;
            public string MonthlyIncome;
            public string OtherIncome;
            public string MonthlyPayment;
            public string OtherObligations;
            public string OwnRentCode;
            public string ReturnMetricScore;
            public string NextPaymentDate;
            public string LastInterestDate;
            public string LastContactDate;
            public string CommissionRate;
            public string Filler1;
            public string Filler2;
            public string Filler3;
            public string CustomerID;
            public string Filler4;
            public string AgencyCode;
            public string FormatCode;

        }
        public Comaker ValidacionComaker(int i, int ii)
        {
            Comaker comaker = new Comaker();
            if (resultsPlacement.caseInfoList != null)
            {
                ////////////////////////////////////////////ACCOUNTNUMBER////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.accountNumber.ToString().Length < 20)
                                comaker.AccountNumber = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.accountNumber.ToString().PadRight(20);
                        }
                    }
                }
                ////////////////////////////////////////////SEQUENCENUMBER////////////////////////////////
                comaker.SequenceNumber = (ii + 1).ToString().PadLeft(2, '0');
                ////////////////////////////////////////////CARDMEMBERTYPE////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].customerAdditionalDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].customerAdditionalDetails.cardMemberType != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].customerAdditionalDetails.cardMemberType.ToString().Length < 1)
                                comaker.CustomerType = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerAdditionalDetails.cardMemberType.ToString().PadRight(1);
                            else
                                comaker.CustomerType = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerAdditionalDetails.cardMemberType.ToString().Substring(0, 1);
                        }
                    }
                }
                ////////////////////////////////////////////LASTNAME+FIRSTNAME////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().Length < 20)
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().PadRight(20);
                                    else
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().Substring(0, 20);
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().Length < 20)
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().PadRight(20);
                                    else
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().Substring(0, 20);
                                    comaker.Name = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName + resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName;
                                }
                                else
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().Length < 20)
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().PadRight(20);
                                    else
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName.ToString().Substring(0, 20);
                                    comaker.Name = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName + "                    ";
                                }

                            }
                            else
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().Length < 20)
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().PadRight(20);
                                    else
                                        resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName.ToString().Substring(0, 20);
                                    comaker.Name = "                    " + resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].lastName + resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].firstName;
                                }
                            }
                        }
                    }
                }
                ////////////////////////////////////////////ADDRESSLINE1////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine1 != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine1.ToString().Length < 25)
                                        comaker.Address1 = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine1.ToString().PadRight(25);
                                    else
                                        comaker.Address1 = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine1.ToString().Substring(0, 25);
                                }
                            }
                        }
                    }
                }

                ////////////////////////////////////////////ADDRESSLINE2////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine2 != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine2.ToString().Length < 25)
                                        comaker.Address2 = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine2.ToString().PadRight(25);
                                    else
                                        comaker.Address2 = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.addressLine2.ToString().Substring(0, 25);
                                }
                            }
                        }
                    }
                }
                ////////////////////////////////////////////CITY////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.city != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.city.ToString().Length < 20)
                                        comaker.City = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.city.ToString().PadRight(20);
                                    else
                                        comaker.City = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.city.ToString().Substring(0, 20);
                                }
                            }
                        }
                    }
                }

                ////////////////////////////////////////////ADDRESS////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.country != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.country.ToString().Length < 15)
                                        comaker.County = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.country.ToString().PadRight(15);
                                    else
                                        comaker.County = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.country.ToString().Substring(0, 15);
                                }
                            }
                        }
                    }
                }
                ////////////////////////////////////////////COUNTRY////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.state != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.state.ToString().Length < 2)
                                        comaker.State = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.state.ToString().PadRight(2);
                                    else
                                        comaker.State = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.state.ToString().Substring(0, 2);
                                }
                            }
                        }
                    }
                }

                ////////////////////////////////////////////ZIPCODE////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.zipCode != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.zipCode.ToString().Length < 10)
                                        comaker.ZipCode = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.zipCode.ToString().PadRight(10);
                                    else
                                        comaker.ZipCode = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].address.zipCode.ToString().Substring(0, 10);
                                }
                            }
                        }
                    }
                }
                ////////////////////////////////////////////HOMEPHONE////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[0].number != null)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[0].number.ToString().Length < 16)
                                        comaker.HomePhone = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[0].number.ToString().PadRight(16);
                                    else
                                        comaker.HomePhone = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[0].number.ToString().Substring(0, 16);
                                }
                            }
                        }
                    }
                }
                ////////////////////////////////////////////WORKPHONE////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList != null)
                            {
                                int valor = 0;
                                for (int iii = 0; iii < resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList.Count; iii++)
                                {
                                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[iii].typeCode == "B-BUS")
                                    {
                                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[iii].number != null)
                                        {
                                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[iii].number.ToString().Length < 16)
                                            {
                                                comaker.WorkPhone = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[iii].number.ToString().PadRight(16);
                                            }
                                            else
                                                comaker.WorkPhone = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].phoneList[iii].number.ToString().Substring(0, 16);
                                            valor = 1;
                                        }
                                    }
                                }
                                if (valor == 0)
                                {
                                    comaker.WorkPhone = "                ";
                                }


                            }
                        }
                    }
                }
                ////////////////////////////////////////////BIRTHDATE////////////////////////////////
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].birthDate != null)
                            {
                                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].birthDate.ToString().Length < 8)
                                    comaker.BirthDate = resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].birthDate.ToString().PadRight(8);
                                else
                                    comaker.BirthDate = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[ii].relatedPerson.relatedPersonDetailsList[0].birthDate).ToString("MMddyyyy");
                            }
                        }
                    }
                }
            }

            return comaker;
        }
        public class Comaker
        {
            public string AccountNumber = "                    ";
            public string RecordType = "C";
            public string SequenceNumber = "00";
            public string Title = "    ";
            public string CustomerType = " ";
            public string Name = "                                        ";
            public string Address1 = "                         ";
            public string Address2 = "                         ";
            public string City = "                    ";
            public string County = "               ";
            public string State = "  ";
            public string ZipCode = "          ";
            public string HomePhone = "                ";
            public string WorkPhone = "                ";
            public string BirthDate = "        ";
            public string EmployersName = "                                        ";
            public string SocialSecurity = "                                        ";
            public string Filler1 = "                                                                                                                                                                                                                                                                                                                                                                                                     ";
            public string CustomerID = "                ";
            public string Filler2 = "     ";
            public string AgencyCode = "    ";
            public string FormatCode = "B";
        }
        public void GenerarRecall(string RutaCompleta, string archivo, Ent_Json_Recall.RootObject resultsRecall)
        {
            ArchivoRecall archivoRecall;
            string archivoSB_ = Path.GetDirectoryName(RutaCompleta);
            string ruta_ = archivo + "\\MT " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
            File.WriteAllText(ruta_, "");
            if (resultsRecall != null)
            {
                if (resultsRecall.accountRecallInfoList != null)
                {
                    for (int i = 0; i < resultsRecall.accountRecallInfoList.Count; i++)
                    {
                        
                        StringBuilder SB_ = new StringBuilder();
                        archivoRecall = new ArchivoRecall();
                        archivoRecall = ValidacionArchivoRecall(i, resultsRecall.accountRecallInfoList[i]);
                        string cade = Cadena(9, null, null, null, null, null, null, null, null, null, archivoRecall);
                        SB_.AppendLine(cade);
                        File.AppendAllText(ruta_, SB_.ToString());
                        using (CYBEREntities DB = new CYBEREntities())
                        {
                            DB.spInsertAmexBitacora(resultsRecall.accountRecallInfoList[i].accountNumber, "", "RECALL", DateTime.Now, resultsRecall.header.balancingSeqNo.ToString().PadLeft(4, '0') + " RECALL", 1);
                        }

                    }
                }
            }
        

        }

        public ArchivoRecall ValidacionArchivoRecall(int i, Ent_Json_Recall.AccountRecallInfoList resultsRecall)
        {
            ArchivoRecall archivoRecall =  new ArchivoRecall();
            archivoRecall.DATE = Convert.ToDateTime(resultsRecall.agencyRecallDate).ToString("yyyyMMdd");
            archivoRecall.TIME = Convert.ToDateTime(resultsRecall.agencyRecallDate).ToString("hhmm");
            archivoRecall.ACCOUNTNUMBER = resultsRecall.accountNumber.ToString().PadRight(20);
            //archivoRecall.RECOVERER_CODE = "";
            //archivoRecall.RECOVERER_ID = "";
            //archivoRecall.LOAN_CODE = "";

            List<spSelectProducto_Result> Resultado = new List<spSelectProducto_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                Resultado = DB.spSelectProducto(resultsRecall.accountNumber).ToList();
            }
            archivoRecall.RECOVERER_CODE = Resultado[0].TBAXATCURRENTAGENCYID.Substring(2, 4);
            archivoRecall.LOAN_CODE = Resultado[0].TBAXATPRODUCTCODE.ToString().PadRight(4);

            return archivoRecall;
        }

        public void GenerarMT(string RutaCompleta, string archivo, Ent_Json_Update.RootObject resultsUpdate)
        {
            ArchivoMTFIinancial archivoMT;
            string archivoSB_ = Path.GetDirectoryName(RutaCompleta);
            string ruta_ = archivo + "\\MT " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
            File.WriteAllText(ruta_, "");
            if (resultsUpdate.accountList != null)
            {
                for (int i = 0; i < resultsUpdate.accountList.Count; i++)
                {
                    if (resultsUpdate.accountList[i].currentAgencyId != null)
                    {
                        using (CYBEREntities DB = new CYBEREntities())
                        {
                            DB.spInsertAmexBitacora(resultsUpdate.accountList[i].accountNumber, resultsUpdate.accountList[i].currentAgencyId, "", DateTime.Now, resultsUpdate.header.balancingSeqNo.ToString().PadLeft(4, '0') + " UPDATESOB", 3);
                        }
                    }
                }
                
            }

            if (resultsUpdate.financialTransactionDetailsList != null)
            {
                IList<string> Unicos = new List<string>();
                for (int i = 0; i < resultsUpdate.financialTransactionDetailsList.Count; i++)
                {


                    if (resultsUpdate.financialTransactionDetailsList[i].transactions != null)
                    {
                        for (int ii = 0; ii < resultsUpdate.financialTransactionDetailsList[i].transactions.Count; ii++)
                        {



                            IList<int?> Valor = new List<int?>();
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                Valor = DB.spSelectAmexTablaTrans(resultsUpdate.financialTransactionDetailsList[i].transactions[ii].transactionDate, Convert.ToDecimal(resultsUpdate.financialTransactionDetailsList[i].transactions[ii].transactionAmount), resultsUpdate.financialTransactionDetailsList[i].transactions[ii].accountNumber).ToList();
                            }
                            if (Valor[0] == 0)
                            {
                                StringBuilder SB_ = new StringBuilder();
                                archivoMT = new ArchivoMTFIinancial();
                                archivoMT = ValidacionArchivoMT_(i, ii, resultsUpdate);
                                if (resultsUpdate.financialTransactionDetailsList[i].transactions[ii].transactionCode != "99")
                                {
                                    string cade = Cadena(8, null, null, null, null, null, null, null, archivoMT, null,null);

                                    if (!Unicos.Contains(cade))
                                    {
                                        Unicos.Add(cade);
                                        SB_.AppendLine(cade);
                                        File.AppendAllText(ruta_, SB_.ToString());
                                        using (CYBEREntities DB = new CYBEREntities())
                                        {
                                            DB.spInsertAmexBitacora(archivoMT.ACCOUNTNUMBER.Trim(), "", archivoMT.TRANSACTION_CODE.Trim()+" "+archivoMT.DESCRIPCION, DateTime.Now, resultsUpdate.header.balancingSeqNo.ToString().PadLeft(4, '0') + " UPDATESOB", 1);
                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }
        }
        public void GenerarHashPruebas(string[] Dividido, string RutaCompleta)
        {
            string ReportID = "".PadRight(15);
            string Number = "".PadRight(8);
            string Hash = "".PadRight(64);
            Number = Dividido[7].Substring(0,4).PadLeft(8, '0');
            string contents = File.ReadAllText(RutaCompleta);
            string a2 = SHA256_.sha256(contents);
            string archivo = "";
            string NombreJson = Path.GetFileName(RutaCompleta);
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            NombreJson = Dividido[0] + "."+ Dividido[1] + "."+ Dividido[3] + "." + "UNITECH" + "." + Dividido[4] + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            switch (Dividido[4].ToString())
            {
                case "PLCMNT":
                    ReportID = "ACORNSTPLCMNT".PadRight(15);
                    archivo = Ruta + "\\JSON\\PLACEMENT\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "RECALL":
                    ReportID = "ACORNSTRECALL".PadRight(15);
                    archivo = Ruta + "\\JSON\\RECALL\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "UPDATESOB":
                    ReportID = "ACORNSTUPDOB".PadRight(15);
                    archivo = Ruta + "\\JSON\\UPDATESOB\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "ACTIONHISTOB":
                    ReportID = "ACORNOAHISTOB".PadRight(15);
                    archivo = Ruta + "\\JSON\\ACTION\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
            }
            string totalText = ReportID + Number + a2;
            string nueva = archivo + "\\" + Path.GetFileName(RutaCompleta);
            System.IO.File.Copy(RutaCompleta, nueva, true);
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);


        }
        public void GenerarHash(string [] Dividido, string RutaCompleta)
        {
            string ReportID = "".PadRight(15);
            string Number = "".PadRight(8);
            string Hash = "".PadRight(64);
            Number = Dividido[6].Substring(0,4).PadLeft(8, '0');
            string contents = File.ReadAllText(RutaCompleta);
            string a2 = SHA256_.sha256(contents);
            string archivo = "";
            string NombreJson = Path.GetFileName(RutaCompleta);
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            NombreJson = Dividido[0] + "." + Dividido[2] + "." + "UNITECH" + "." + Dividido[3] + "." + Dividido[4] + "." + Dividido[5] + "." + Dividido[6];
            switch (Dividido[3].ToString())
            {
                case "PLCMNT":
                    ReportID = "ACORNSTPLCMNT".PadRight(15);
                    archivo = Ruta + "\\JSON\\PLACEMENT\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "RECALL":
                    ReportID = "ACORNSTRECALL".PadRight(15);
                    archivo = Ruta + "\\JSON\\RECALL\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "UPDATESOB":
                    ReportID = "ACORNSTUPDOB".PadRight(15);
                    archivo = Ruta + "\\JSON\\UPDATESOB\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
                case "ACTIONHISTOB":
                    ReportID = "ACORNOAHISTOB".PadRight(15);
                    archivo = Ruta + "\\JSON\\ACTION\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(archivo))
                    {
                        Directory.CreateDirectory(archivo);
                    }
                    break;
            }
            string totalText = ReportID + Number + a2;
            string nueva = archivo + "\\" + Path.GetFileName(RutaCompleta);
            System.IO.File.Copy(RutaCompleta, nueva, true);
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);


        }
        public Task<DataTable> EjecutarAsynJsonTotal()
        {
            return Task.Run(() =>
            {
                PRUEBA = new DataTable();
                string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string RutaCompleta = Path.GetDirectoryName(Txt_Archivo.Text) + "\\" + Path.GetFileName(Txt_Archivo.Text);
                string NombreJson = Path.GetFileName(RutaCompleta);
                string[] Dividido = NombreJson.Split('.');
                StreamReader streamReader = new StreamReader(RutaCompleta);
                JsonTextReader reader = new JsonTextReader(streamReader);
                var serializer = new JsonSerializer();
                string archivo = "";
                switch (Dividido[3].ToString())
                {
                    case "PLCMNT":
                        GenerarHash(Dividido, RutaCompleta);                       
                        resultsPlacement = new RootObject();
                        while (reader.Read())
                        {
                            resultsPlacement = serializer.Deserialize<RootObject>(reader);
                        }
                        PRUEBA = new DataTable();
                        GenerarColumnas();
                        int mx = PRUEBA.Rows.Count;
                        AccountMaster accountMaster;
                        Comaker comaker;
                        CreditHistory credithistory;
                        History history;
                        MasterRecord masterrecord;
                        UserRecord userrecord;
                        XRecord xrecord;
                        archivo = Ruta + "\\JSON\\PLACEMENT\\" + DateTime.Now.ToString("dd-MM-yyyy");
                        string ruta = archivo + "\\DL " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
                        File.WriteAllText(ruta, "");

                        StringBuilder SB = new StringBuilder();

                        for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
                        {
                            if (i == 0)
                                SB.AppendLine("RMSHDR");
                            else
                                SB = new StringBuilder();
                            accountMaster = new AccountMaster();
                            accountMaster = ValidacionAccountMaster(i);
                            SB.AppendLine(Cadena(1, accountMaster, null, null, null, null, null, null, null, null,null));
                            for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList.Count; ii++)
                            {
                                comaker = new Comaker();
                                comaker = ValidacionComaker(i, ii);
                                SB.AppendLine(Cadena(2, null, comaker, null, null, null, null, null, null, null, null));
                            }
                            credithistory = new CreditHistory();
                            credithistory = validacionCreditHistory(i);
                            SB.AppendLine(Cadena(3, null, null, credithistory, null, null, null, null, null, null, null));
                            history = new History();
                            history = ValidacionHistory(i);
                            SB.AppendLine(Cadena(4, null, null, null, history, null, null, null, null, null, null));
                            masterrecord = new MasterRecord();
                            masterrecord = validacionMasterRecord(i);
                            SB.AppendLine(Cadena(5, null, null, null, null, masterrecord, null, null, null, null, null));
                            userrecord = new UserRecord();
                            userrecord = validacionUserRecord(i);
                            SB.AppendLine(Cadena(6, null, null, null, null, null, userrecord, null, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXAA(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXAB(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXAC(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXAE(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXBA(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXBB(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXBC(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXPH(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXPI(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXPJ(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            xrecord = new XRecord();
                            xrecord = validacionXPO(i);
                            SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                            File.AppendAllText(ruta, SB.ToString());
                        }
                        Ent_Guardar_Json GuardarJson = new Ent_Guardar_Json();
                        GuardarJson.Json(resultsPlacement);
                        break;

                    case "RECALL":
                        GenerarHash(Dividido, RutaCompleta);                        
                        resultsRecall = new Ent_Json_Recall.RootObject();
                        while (reader.Read())
                        {
                            resultsRecall = serializer.Deserialize<Ent_Json_Recall.RootObject>(reader);
                        }
                        archivo = Ruta + "\\JSON\\RECALL\\" + DateTime.Now.ToString("dd-MM-yyyy");
                        GenerarRecall(RutaCompleta, archivo, resultsRecall);
                        Ent_Guardar_Json GuardarRecall = new Ent_Guardar_Json();
                        GuardarRecall.Recall(resultsRecall);

                        break;

                    case "UPDATESOB":
                        GenerarHash(Dividido, RutaCompleta);
                        resultsUpdate = new Ent_Json_Update.RootObject();
                        while (reader.Read())
                        {
                            resultsUpdate = serializer.Deserialize<Ent_Json_Update.RootObject>(reader);
                        }

                        archivo = Ruta + "\\JSON\\UPDATESOB\\" + DateTime.Now.ToString("dd-MM-yyyy");
                        GenerarMT(RutaCompleta, archivo, resultsUpdate);
                        DataTable Saldos = new DataTable();
                       
                        Ent_Guardar_Json Guardar = new Ent_Guardar_Json();
                        Guardar.Update(resultsUpdate);
                        Saldos = GenerarSaldos(archivo);
                        MessageBox.Show("Archivo HASH Generado", "COMPLETO", MessageBoxButtons.OK);
                        break;
                    case "ACTIONHISTOB":
                        GenerarHash(Dividido, RutaCompleta);
                        resultsAction = new Ent_Json_Action.RootObject();
                        while (reader.Read())
                        {
                            resultsAction = serializer.Deserialize<Ent_Json_Action.RootObject>(reader);
                        }
                        archivo = Ruta + "\\JSON\\ACTION\\" + DateTime.Now.ToString("dd-MM-yyyy");                        
                        Ent_Guardar_Json GuardarAction = new Ent_Guardar_Json();
                        GuardarAction.Actions(resultsAction);

                        break;
                    default:
                        break;
                }
                if (Dividido[4].ToString()== "ACTIONHISTOB")
                {
                    GenerarHashPruebas(Dividido, RutaCompleta);
                    resultsAction = new Ent_Json_Action.RootObject();
                    while (reader.Read())
                    {
                        resultsAction = serializer.Deserialize<Ent_Json_Action.RootObject>(reader);
                    }
                    archivo = Ruta + "\\JSON\\ACTION\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    Ent_Guardar_Json GuardarAction = new Ent_Guardar_Json();
                    GuardarAction.Actions(resultsAction);
                }    
                return PRUEBA;
            });
        }

        public Task<DataTable> EjecutarAsyn()
        {
            return Task.Run(() =>
            {
                string archivo = Path.GetDirectoryName(Txt_Archivo.Text);
                string Number = "".PadRight(8);
                string Hash = "".PadRight(64);
                string y = Path.GetDirectoryName(Txt_Archivo.Text) + "\\" + Path.GetFileName(Txt_Archivo.Text);
                string NombreJson = Path.GetFileName(y);
                string[] Dividido = NombreJson.Split('.');
                string xx = JsonConvert.SerializeObject(y);
                string contents = File.ReadAllText(y);
                string a1 = SHA256_.getHashSha256(contents);
                string a2 = SHA256_.sha256(contents);
                string ReportID = "".PadRight(15);
                if (Dividido.Length == 7)
                {
                    NombreJson = Dividido[0] + "." + Dividido[2] + "." + "UNITECH" + "." + Dividido[3] + "." + Dividido[4] + "." + Dividido[5] + "." + Dividido[6];
                    Number = Dividido[6].Substring(2).PadLeft(8, '0');

                    switch (Dividido[3].ToString())
                    {
                        case "PLCMNT":
                            ReportID = "ACORNSTPLCMNT".PadRight(15);
                            break;

                        case "RECALL":
                            ReportID = "ACORNSTRECALL".PadRight(15);
                            break;
                        case "UPDATESOB":
                            ReportID = "ACORNSTUPDOB".PadRight(15);

                            break;
                        default:
                            break;

                    }
                }                
                string totalText = ReportID + Number + a2;
                if (Dividido[3].ToString() == "RECALL")
                {

                    File.WriteAllText(archivo + "\\" + NombreJson, totalText);
                    Json_Update(archivo, NombreJson, Dividido);
                    StreamReader streamReader = new StreamReader(y);
                    JsonTextReader reader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    resultsRecall = new Ent_Json_Recall.RootObject();
                    while (reader.Read())
                    {
                        resultsRecall = serializer.Deserialize<Ent_Json_Recall.RootObject>(reader);
                    }
                    MessageBox.Show("Archivo HASH Generado", "COMPLETO", MessageBoxButtons.OK);
                }

                if (Dividido[3].ToString() == "UPDATESOB")
                {


                    File.WriteAllText(archivo + "\\" + NombreJson, totalText);
                    StreamReader streamReader = new StreamReader(y);
                    JsonTextReader reader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    resultsUpdate = new Ent_Json_Update.RootObject();
                    while (reader.Read())
                    {
                        resultsUpdate = serializer.Deserialize<Ent_Json_Update.RootObject>(reader);
                    }
                    Ent_Guardar_Json Guardar = new Ent_Guardar_Json();
                    Guardar.Update(resultsUpdate);
                    MessageBox.Show("Archivo HASH Generado", "COMPLETO", MessageBoxButtons.OK);
                }

                if (Dividido[3].ToString() == "PLCMNT")
                {
                    File.WriteAllText(archivo + "\\" + NombreJson, totalText);                   
                    StreamReader streamReader = new StreamReader(y);
                    JsonTextReader reader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    resultsPlacement = new RootObject();
                    while (reader.Read())
                    {
                        resultsPlacement = serializer.Deserialize<RootObject>(reader);
                    }
                    PRUEBA = new DataTable();
                    GenerarColumnas();                   
                    int mx = PRUEBA.Rows.Count;
                    AccountMaster accountMaster;
                    Comaker comaker;
                    CreditHistory credithistory;
                    History history;
                    MasterRecord masterrecord;
                    UserRecord userrecord;
                    XRecord xrecord;
                    string archivoSB = Path.GetDirectoryName(y);
                    string ruta = archivoSB + "\\DL " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
                    File.WriteAllText(ruta, "");

                    StringBuilder SB = new StringBuilder();

                    for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
                    {
                        if (i == 0)
                            SB.AppendLine("RMSHDR");
                        else
                            SB = new StringBuilder();
                        accountMaster = new AccountMaster();
                        accountMaster = ValidacionAccountMaster(i);
                        SB.AppendLine(Cadena(1, accountMaster, null, null, null, null, null, null, null, null, null));
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList.Count; ii++)
                        {
                            comaker = new Comaker();
                            comaker = ValidacionComaker(i, ii);
                            SB.AppendLine(Cadena(2, null, comaker, null, null, null, null, null, null, null, null));
                        }
                        credithistory = new CreditHistory();
                        credithistory = validacionCreditHistory(i);
                        SB.AppendLine(Cadena(3, null, null, credithistory, null, null, null, null, null, null, null));
                        history = new History();
                        history = ValidacionHistory(i);
                        SB.AppendLine(Cadena(4, null, null, null, history, null, null, null, null, null, null));
                        masterrecord = new MasterRecord();
                        masterrecord = validacionMasterRecord(i);
                        SB.AppendLine(Cadena(5, null, null, null, null, masterrecord, null, null, null, null, null));
                        userrecord = new UserRecord();
                        userrecord = validacionUserRecord(i);
                        SB.AppendLine(Cadena(6, null, null, null, null, null, userrecord, null, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXAA(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXAB(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXAC(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXAE(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXBA(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXBB(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXBC(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXPH(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXPI(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXPJ(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        xrecord = new XRecord();
                        xrecord = validacionXPO(i);
                        SB.AppendLine(Cadena(7, null, null, null, null, null, null, xrecord, null, null, null));
                        File.AppendAllText(ruta, SB.ToString());
                    }                   
                    //Json_UpdateTOTALES(archivo, NombreJson, Dividido);
                    Ent_Guardar_Json GuardarJson = new Ent_Guardar_Json();
                    GuardarJson.Json(resultsPlacement);
                    MessageBox.Show("Archivo DL y HASH Generado", "COMPLETO", MessageBoxButtons.OK);
                }
                return PRUEBA;
            });
        }
        private ArchivoMTFIinancial ValidacionArchivoMT_(int i, int ii, Ent_Json_Update.RootObject MT)
        {
            ArchivoMTFIinancial archivoMT = new ArchivoMTFIinancial();
            if (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode != "99")
            {
                switch (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode)
                {
                    case "50":
                        archivoMT.TRANSACTION_CODE = "50";
                        break;
                    case "11":
                        archivoMT.TRANSACTION_CODE = "11";
                        break;
                    case "12":
                        archivoMT.TRANSACTION_CODE = "12";
                        break;
                    case "55":
                        archivoMT.TRANSACTION_CODE = "55";
                        break;
                    default:
                        archivoMT.TRANSACTION_CODE = "MT";
                        break;
                }
                archivoMT.FLAG_INT_EXT = "I";
                //archivoMT.RECOVERER_CODE = "PLHS";
                
                archivoMT.RECOVERER_ID = "BATCH".PadRight(8);

                if (MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount != null)
                {
                    if (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode == "50")
                    {
                        string g = (MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount * -1).ToString().PadLeft(10, '0');
                        archivoMT.TRANSACTION_AMOUNT = DoFormat((MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount * -1).ToString()).Replace(".", "").PadLeft(10, '0');
                        archivoMT.DESCRIPCION = "DIRECT PAYMENT".PadRight(20); 
                    }
                    if (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode == "11")
                    {
                        string g = (MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount).ToString().PadLeft(10, '0');
                        archivoMT.TRANSACTION_AMOUNT = DoFormat((MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount ).ToString()).Replace(".", "").PadLeft(10, '0');
                        archivoMT.DESCRIPCION = "DEBIT ADJUSTMENT - O".PadRight(20);
                    }
                    if (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode == "55")
                    {
                        string g = (MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount).ToString().PadLeft(9, '0')+" ";
                        archivoMT.TRANSACTION_AMOUNT = DoFormat((MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount).ToString()).Replace(".", "").PadLeft(9, '0')+" ";
                        archivoMT.DESCRIPCION = "NSF DIRECT".PadRight(20);
                    }
                    if (MT.financialTransactionDetailsList[i].transactions[ii].transactionCode == "12")
                    {
                        string g = (MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount * -1).ToString().PadLeft(9, '0')+" ";
                        archivoMT.TRANSACTION_AMOUNT = DoFormat((MT.financialTransactionDetailsList[i].transactions[ii].transactionAmount * -1).ToString()).Replace(".", "").PadLeft(9, '0')+" ";
                        archivoMT.DESCRIPCION = "CREDIT ADJUSTMENT -".PadRight(20);
                    }                   
                }

                /////////////////////////////UPDATE
                if (MT.financialTransactionDetailsList[i].transactions[ii].transactionDate != null)
                {
                    archivoMT.DATE = Convert.ToDateTime(MT.financialTransactionDetailsList[i].transactions[ii].transactionDate).ToString("yyyyMMdd");
                    archivoMT.TIME = Convert.ToDateTime(MT.financialTransactionDetailsList[i].transactions[ii].transactionDate).ToString("hhmm");                    
                }

                /////////////////////////////ACCOUNTNUMBER
                if (MT.financialTransactionDetailsList[i].transactions[ii].accountNumber != null)
                {
                   
                            if (MT.financialTransactionDetailsList[i].transactions[ii].accountNumber.ToString().Length < 20)
                                archivoMT.ACCOUNTNUMBER = MT.financialTransactionDetailsList[i].transactions[ii].accountNumber.ToString().PadRight(20);
                            else
                                archivoMT.ACCOUNTNUMBER = MT.financialTransactionDetailsList[i].transactions[ii].accountNumber.ToString().Substring(0, 20);
                        
                }


                /////////////////////////////loancode
                if (MT.financialTransactionDetailsList[i].transactions[ii].processingStatus != null)
                {
                   
                            if (MT.financialTransactionDetailsList[i].transactions[ii].processingStatus.ToString().Length < 4)
                                archivoMT.LOAN_CODE = MT.financialTransactionDetailsList[i].transactions[ii].processingStatus.ToString().PadRight(4);
                            else
                                archivoMT.LOAN_CODE = MT.financialTransactionDetailsList[i].transactions[ii].processingStatus.ToString().Substring(0, 4).PadRight(4);
                        
                }

                List<spSelectProducto_Result> Resultado = new List<spSelectProducto_Result>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    Resultado = DB.spSelectProducto(MT.financialTransactionDetailsList[i].transactions[ii].accountNumber).ToList();
                }
                archivoMT.RECOVERER_CODE = Resultado[0].TBAXATCURRENTAGENCYID.Substring(2,4);
                archivoMT.LOAN_CODE = Resultado[0].TBAXATPRODUCTCODE.ToString().PadRight(4);

            }
            

            return archivoMT;
        }
        private ArchivoMT ValidacionArchivoMT(int i, Ent_Json.RootObject MT)
        {
            ArchivoMT archivoMT = new ArchivoMT();
            if (resultsPlacement.caseInfoList != null)
            {
                /////////////////////////////UPDATE
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.updateDate != null)
                        {
                            archivoMT.DATE = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.updateDate).ToString("yyyyMMdd");
                            archivoMT.TIME = Convert.ToDateTime(resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.updateDate).ToString("hhmm");

                        }
                    }
                }

                /////////////////////////////ACCOUNTNUMBER
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Length < 20)
                                archivoMT.ACCOUNTNUMBER = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().PadRight(20);
                            else
                                archivoMT.ACCOUNTNUMBER = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber.ToString().Substring(0, 20);
                        }
                    }
                }


                /////////////////////////////loancode
                if (resultsPlacement.caseInfoList[i].accountInfoList != null)
                {
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails != null)
                    {
                        if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode != null)
                        {
                            if (resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().Length < 4)
                                archivoMT.LOAN_CODE = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().PadRight(4);
                            else
                                archivoMT.LOAN_CODE = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode.ToString().Substring(0, 4);
                        }
                    }
                }              
                archivoMT.TRANSACTION_CODE = "MT";
                archivoMT.FIELD_CODE = "MASB$3";


            }
            return archivoMT;
        }

        private void Json_UpdateTest(string archivo, string NombreJson, string[] Dividido)
        {
            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();


            UpdateJson.accountList = new List<AccountList>();
            UpdateJson.contactInfoList = new List<ContactInfoList>();
            UpdateJson.deceasedDetailsList = new List<DeceasedDetailsList>();



            for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            {
                UpdateJson.accountList.Add(new AccountList());

                UpdateJson.deceasedDetailsList.Add(new DeceasedDetailsList());
                UpdateJson.contactInfoList.Add(new ContactInfoList());



            }
            for (int i = 0; i < 1; i++)
            {
                UpdateJson.accountList[i].accountStatus = "417";
                UpdateJson.accountList[i].accountNumber = " XX6728004411007";
                UpdateJson.contactInfoList[i].lastContactDate = Convert.ToDateTime("25/10/2018");
                UpdateJson.deceasedDetailsList[i].attorneyName = "Sertec Attorney";
                UpdateJson.deceasedDetailsList[i].attorneyAddress = "abc Avenida Guadalalupe1";
                UpdateJson.deceasedDetailsList[i].executorCity = "Mexico 1";
                UpdateJson.deceasedDetailsList[i].executorState = "Tabasco1";
                UpdateJson.deceasedDetailsList[i].executorZip = "03600";
                UpdateJson.deceasedDetailsList[i].executorPhone = "1111111111";

            }



            //    for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            //{

            //    ////////////ACCOUNT//////////////
            //    #region account.
            //    UpdateJson.accounList[i].accountStatus = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountStatus;
            //    UpdateJson.accounList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountNumber;                
            //    #endregion
            //    ////////////contactinfolist//////////////
            //    #region contactinfolist.
            //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].contactInfo != null)
            //    {
            //         UpdateJson.contactInfoList[i].lastContactDate = resultsPlacement.caseInfoList[i].accountInfoList[0].contactInfo.lastContactDate;
            //    }


            //    #endregion
            //    ////////////deceaseddetailslist//////////////
            //    #region deceaseddetailslist.
            //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
            //    {
            //        UpdateJson.deceasedDetailsList[i].attorneyName = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName;
            //        UpdateJson.deceasedDetailsList[i].attroneyAddress = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress;                    
            //        UpdateJson.deceasedDetailsList[i].executorCity = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity;
            //        UpdateJson.deceasedDetailsList[i].executorState = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity;
            //        UpdateJson.deceasedDetailsList[i].executorZip = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip;
            //        UpdateJson.deceasedDetailsList[i].executorPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone;
            //    }



            //    #endregion



            //}
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            //var jsonModel = JsonConvert.DeserializeObject(output, settings);

            string output = JsonConvert.SerializeObject(UpdateJson, settings);


            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATE" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
        }
        private void Json_Update(string archivo, string NombreJson, string[] Dividido)
        {
            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();
            UpdateJson.header = new Header();
            UpdateJson.customerDetailsList = new List<CustomerDetailsList>();
            UpdateJson.demographicsList = new List<DemographicsList>();
            UpdateJson.employerList = new List<EmployerList>();
            UpdateJson.accountDetailsList = new List<AccountDetailsList>();
            UpdateJson.productDetailsList = new List<ProductDetailsList>();
            UpdateJson.customerFinancialList = new List<CustomerFinancialList>();
            UpdateJson.financialRiskList = new List<FinancialRiskList>();
            UpdateJson.financialSummaryList = new List<FinancialSummaryList>();
            UpdateJson.bankruptcyDetailsList = new List<BankruptcyDetailsList>();
            UpdateJson.riskScoreList = new List<RiskScoreList>();
            UpdateJson.strategyInfoList = new List<StrategyInfoList>();
            UpdateJson.accountList = new List<AccountList>();
            UpdateJson.collectionScoreList = new List<CollectionScoreList>();
            UpdateJson.customerAdditionalDetailsList = new List<CustomerAdditionalDetailsList>();
            UpdateJson.agecyInfoList = new List<AgencyInfoList>();
            UpdateJson.AgencyAssignmentList = new List<AgencyAssignmentList>();

            for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            {
                UpdateJson.customerDetailsList.Add(new CustomerDetailsList());
                UpdateJson.demographicsList.Add(new DemographicsList());
                UpdateJson.employerList.Add(new EmployerList());
                UpdateJson.accountDetailsList.Add(new AccountDetailsList());
                UpdateJson.demographicsList[i].addresses = new List<Address>();
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses.Count; ii++)
                {
                    UpdateJson.demographicsList[i].addresses.Add(new Address());
                }
                UpdateJson.demographicsList[i].phones = new List<Phone>();
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                {
                    UpdateJson.demographicsList[i].phones.Add(new Phone());
                }
                UpdateJson.employerList[i].Phones = new List<Phone>();
                UpdateJson.employerList[i].address = new Address();
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].employer.Phones.Count; ii++)
                {

                    UpdateJson.employerList[i].Phones.Add(new Phone());
                }
                UpdateJson.productDetailsList.Add(new ProductDetailsList());
                UpdateJson.customerFinancialList.Add(new CustomerFinancialList());
                UpdateJson.financialRiskList.Add(new FinancialRiskList());
                UpdateJson.financialSummaryList.Add(new FinancialSummaryList());
                UpdateJson.financialSummaryList[i].debitSummaryInMonths = new DebitSummaryInMonths();
                UpdateJson.financialSummaryList[i].accountBalanceInMonths = new AccountBalanceInMonths();
                UpdateJson.financialSummaryList[i].summaryCreditInMonths = new SummaryCreditInMonths();
                UpdateJson.financialSummaryList[i].accountAgingInMonths = new AccountAgingInMonths();
                UpdateJson.bankruptcyDetailsList.Add(new BankruptcyDetailsList());
                UpdateJson.riskScoreList.Add(new RiskScoreList());
                UpdateJson.strategyInfoList.Add(new StrategyInfoList());
                UpdateJson.accountList.Add(new AccountList());
                UpdateJson.collectionScoreList.Add(new CollectionScoreList());
                UpdateJson.customerAdditionalDetailsList.Add(new CustomerAdditionalDetailsList());
                UpdateJson.agecyInfoList.Add(new AgencyInfoList());
                UpdateJson.AgencyAssignmentList.Add(new AgencyAssignmentList());

            }





            UpdateJson.updateDate = resultsPlacement.updateDate;
            UpdateJson.updateBy = "ST";
            UpdateJson.header.updateDate = resultsPlacement.header.updateDate;
            UpdateJson.header.senderID = resultsPlacement.header.senderID;
            UpdateJson.header.targetID = resultsPlacement.header.targetID;
            UpdateJson.header.totalRecords = resultsPlacement.header.totalRecords;
            UpdateJson.header.balancingSeqNo = resultsPlacement.header.balancingSeqNo;
            for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            {
                ////////////customerDetails////////////////////
                #region CUSTOMERDETAILS

                UpdateJson.customerDetailsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.updateDate;
                UpdateJson.customerDetailsList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.updatedBy;
                UpdateJson.customerDetailsList[i].customerId = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.customerId;
                UpdateJson.customerDetailsList[i].accountMarketCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.accountMarketCode;
                UpdateJson.customerDetailsList[i].countryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.countryCode;
                UpdateJson.customerDetailsList[i].accountCategoryTypeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.accountCategoryTypeCode;
                #endregion
                ////////////Demographics////////////////////
                #region DEMOGRAPHICS
                UpdateJson.demographicsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.updateDate;
                UpdateJson.demographicsList[i].firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName;
                UpdateJson.demographicsList[i].lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName;
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses.Count; ii++)
                {
                    UpdateJson.demographicsList[i].addresses[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].typeCode;
                    UpdateJson.demographicsList[i].addresses[ii].categoryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].categoryCode;
                    UpdateJson.demographicsList[i].addresses[ii].statusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].statusCode;
                }
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                {
                    UpdateJson.demographicsList[i].phones[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode;
                    UpdateJson.demographicsList[i].phones[ii].categoryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].categoryCode;
                    UpdateJson.demographicsList[i].phones[ii].statusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].statusCode;
                    UpdateJson.demographicsList[i].phones[ii].number = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number;
                    UpdateJson.demographicsList[i].phones[ii].lastContactDate = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].lastContactDate;
                }
                UpdateJson.demographicsList[i].birthDate = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.updateDate;
                UpdateJson.demographicsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.accountNumber;
                #endregion
                ////////////Employer////////////////////////
                #region EMPLOYER
                UpdateJson.employerList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.updateDate;
                UpdateJson.employerList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.accountNumber;
                UpdateJson.employerList[i].address.typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address.typeCode;
                for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].employer.Phones.Count; ii++)
                {
                    UpdateJson.employerList[i].Phones[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.Phones[ii].typeCode;
                    UpdateJson.employerList[i].Phones[ii].categoryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.Phones[ii].categoryCode;
                    UpdateJson.employerList[i].Phones[ii].statusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.Phones[ii].statusCode;
                }
                #endregion
                ////////////AccountDetailsList//////////////
                #region ACCOUNTDETAILS
                UpdateJson.accountDetailsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.updateDate;
                UpdateJson.accountDetailsList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.updatedBy;
                UpdateJson.accountDetailsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountNumber;
                UpdateJson.accountDetailsList[i].accountMarketCode = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.accountMarketCode;
                UpdateJson.accountDetailsList[i].customerId = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.customerId;
                UpdateJson.accountDetailsList[i].cancelCode = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancelCode;
                UpdateJson.accountDetailsList[i].crDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.crDate;
                UpdateJson.accountDetailsList[i].cancellationDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cancellationDate;
                UpdateJson.accountDetailsList[i].cardOpenDate = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.cardOpenDate;
                UpdateJson.accountDetailsList[i].lastChargeActivity = resultsPlacement.caseInfoList[i].accountInfoList[0].accountDetails.lastChargeActivity;
                #endregion
                ////////////productDetails//////////////
                #region PRODUCTDETAILS
                UpdateJson.productDetailsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.updateDate;
                UpdateJson.productDetailsList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.updatedBy;
                UpdateJson.productDetailsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.accountNumber;
                UpdateJson.productDetailsList[i].amexProductCode = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.amexProductCode;
                UpdateJson.productDetailsList[i].fullProductDescription = resultsPlacement.caseInfoList[i].accountInfoList[0].productDetails.fullProductDescription;
                #endregion
                ////////////customerFinancial//////////////
                #region CUSTOMERFINALCIAL
                UpdateJson.customerFinancialList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.updateDate;
                UpdateJson.customerFinancialList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.updatedBy;
                UpdateJson.customerFinancialList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.accountNumber;
                UpdateJson.customerFinancialList[i].cycleCut = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.cycleCut;
                UpdateJson.customerFinancialList[i].totalExposure = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.totalExposure;
                UpdateJson.customerFinancialList[i].lastPaymentDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerFinancial.lastPaymentDate;
                #endregion
                ////////////FINANCIALRISKLIST//////////////
                #region financialRiskList
                UpdateJson.financialRiskList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.updateDate;
                UpdateJson.financialRiskList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.updatedBy;
                UpdateJson.financialRiskList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.accountNumber;
                UpdateJson.financialRiskList[i].lendingAgeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.lendingAgeCode;
                UpdateJson.financialRiskList[i].minDueIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].financialRisk.minDueIndicator;
                #endregion

                ////////////FINANCIALSUMMARY//////////////
                #region financialSummary
                UpdateJson.financialSummaryList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.updateDate;
                UpdateJson.financialSummaryList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.updatedBy;
                UpdateJson.financialSummaryList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountNumber;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month01;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month02;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month03;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month04;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month05;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month06;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month07 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month07;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month08 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month08;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month09 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month09;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month10 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month10;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month11 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month11;
                UpdateJson.financialSummaryList[i].debitSummaryInMonths.Month12 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.debitSummaryInMonths.Month12;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month01;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month02;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month03;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month04;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month05;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month06;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month07 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month07;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month08 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month08;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month09 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month09;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month10 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month10;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month11 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month11;
                UpdateJson.financialSummaryList[i].accountBalanceInMonths.Month12 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountBalanceInMonths.Month12;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month01;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month02;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month03;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month04;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month05;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month06;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month07 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month07;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month08 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month08;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month09 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month09;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month10 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month10;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month11 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month11;
                UpdateJson.financialSummaryList[i].summaryCreditInMonths.Month12 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.summaryCreditInMonths.Month12;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month01 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month01;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month02 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month02;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month03 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month03;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month04 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month04;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month05 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month05;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month06 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month06;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month07 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month07;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month08 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month08;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month09 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month09;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month10 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month10;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month11 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month11;
                UpdateJson.financialSummaryList[i].accountAgingInMonths.Month12 = resultsPlacement.caseInfoList[i].accountInfoList[0].financialSummary.accountAgingInMonths.Month12;
                #endregion

                ////////////BANKRUPTCYDETAILSLIST//////////////
                #region bankruptcyDetailsList
                UpdateJson.bankruptcyDetailsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.updateDate;
                UpdateJson.bankruptcyDetailsList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.updatedBy;
                UpdateJson.bankruptcyDetailsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.accountNumber;
                UpdateJson.bankruptcyDetailsList[i].assetIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.assetIndicator;
                UpdateJson.bankruptcyDetailsList[i].bankruptcyChapter = resultsPlacement.caseInfoList[i].accountInfoList[0].bankruptcyDetails.bankruptcyChapter;
                #endregion
                ////////////RISKSCORE//////////////
                #region riskScore
                UpdateJson.riskScoreList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.updateDate;
                UpdateJson.riskScoreList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.updatedBy;
                UpdateJson.riskScoreList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.accountNumber;
                UpdateJson.riskScoreList[i].customerLevelScoreForChargeAndLending = resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.customerLevelScoreForChargeAndLending;
                UpdateJson.riskScoreList[i].lendingPayToCurrrentScore = resultsPlacement.caseInfoList[i].accountInfoList[0].riskScore.lendingPayToCurrrentScore;
                #endregion

                ////////////STRATEGYINFO//////////////
                #region strategyInfo
                UpdateJson.strategyInfoList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.updateDate;
                UpdateJson.strategyInfoList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.updatedBy;
                UpdateJson.strategyInfoList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.accountNumber;
                UpdateJson.strategyInfoList[i].strategyIndicator1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator1;
                UpdateJson.strategyInfoList[i].strategyIndicator2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator2;
                UpdateJson.strategyInfoList[i].strategyIndicator3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator3;
                UpdateJson.strategyInfoList[i].strategyIndicator4 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.strategyIndicator4;
                UpdateJson.strategyInfoList[i].noOfCcsgChargeCardsCustomerHas = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgChargeCardsCustomerHas;
                UpdateJson.strategyInfoList[i].noOfCcsgLendingCardsCustomerHas = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfCcsgLendingCardsCustomerHas;
                UpdateJson.strategyInfoList[i].segmentId1 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId1;
                UpdateJson.strategyInfoList[i].segmentId2 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId2;
                UpdateJson.strategyInfoList[i].segmentId3 = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.segmentId3;
                UpdateJson.strategyInfoList[i].noOfOpenCardsCustomerHas = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.noOfOpenCardsCustomerHas;
                UpdateJson.strategyInfoList[i].indicatorForLocBalance = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.indicatorForLocBalance;
                UpdateJson.strategyInfoList[i].reAgeIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.reAgeIndicator;
                UpdateJson.strategyInfoList[i].careEligibility = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.careEligibility;
                UpdateJson.strategyInfoList[i].writtenOffIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.writtenOffIndicator;
                UpdateJson.strategyInfoList[i].lendingInCharge = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.lendingInCharge;
                UpdateJson.strategyInfoList[i].speedToPayModel = resultsPlacement.caseInfoList[i].accountInfoList[0].strategyInfo.speedToPayModel;
                #endregion
                ////////////ACCOUNT//////////////
                #region account.
                UpdateJson.accountList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].account.updateDate;
                UpdateJson.accountList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].account.updatedBy;
                UpdateJson.accountList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountNumber;
                UpdateJson.accountList[i].accountCategoryTypeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountCategoryTypeCode;
                UpdateJson.accountList[i].countryIsoAlpha2Code = resultsPlacement.caseInfoList[i].accountInfoList[0].account.countryIsoAlpha2Code;
                UpdateJson.accountList[i].productCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.productCode;
                UpdateJson.accountList[i].chargeOffReasonCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.chargeOffReasonCode;
                UpdateJson.accountList[i].placementBalance = resultsPlacement.caseInfoList[i].accountInfoList[0].account.placementBalance;
                UpdateJson.accountList[i].currentBalance = resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentBalance;
                UpdateJson.accountList[i].accountStatus = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountStatus;
                UpdateJson.accountList[i].originalPlacementDate = resultsPlacement.caseInfoList[i].accountInfoList[0].account.originalPlacementDate;
                UpdateJson.accountList[i].placementLevelCode = resultsPlacement.caseInfoList[i].accountInfoList[0].account.placementLevelCode;
                UpdateJson.accountList[i].agencyAssignmentDate = resultsPlacement.caseInfoList[i].accountInfoList[0].account.agencyAssignmentDate;
                UpdateJson.accountList[i].lastStatusChangeDate = resultsPlacement.caseInfoList[i].accountInfoList[0].account.lastStatusChangeDate;
                UpdateJson.accountList[i].currentAgencyId = resultsPlacement.caseInfoList[i].accountInfoList[0].account.currentAgencyId;
                #endregion
                ////////////COLLECTIONSCORE//////////////
                #region collectionScoreList.
                UpdateJson.collectionScoreList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.updateDate;
                UpdateJson.collectionScoreList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.updatedBy;
                UpdateJson.collectionScoreList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.accountNumber;
                UpdateJson.collectionScoreList[i].accountCategoryTypeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.accountCategoryTypeCode;
                UpdateJson.collectionScoreList[i].collectibilityScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.collectibilityScore;
                UpdateJson.collectionScoreList[i].recoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.recoveryScore;
                UpdateJson.collectionScoreList[i].marketRecoveryScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.marketRecoveryScore;
                UpdateJson.collectionScoreList[i].ficoScore = resultsPlacement.caseInfoList[i].accountInfoList[0].collectionScore.ficoScore;
                #endregion
                ////////////CUSTOMERADDITIONALDETAILS//////////////
                #region customerAdditionalDetailsList.
                UpdateJson.customerAdditionalDetailsList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.updateDate;
                UpdateJson.customerAdditionalDetailsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.accountNumber;
                UpdateJson.customerAdditionalDetailsList[i].cardMemberType = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.cardMemberType;
                UpdateJson.customerAdditionalDetailsList[i].monthlyIncome = resultsPlacement.caseInfoList[i].accountInfoList[0].customerAdditionalDetails.monthlyIncome;

                #endregion
                ////////////AGENCYINFO//////////////
                #region agecyInfoList.
                UpdateJson.agecyInfoList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.updateDate;
                UpdateJson.agecyInfoList[i].agencyId = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyId;
                UpdateJson.agecyInfoList[i].agencyGroupId = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyGroupId;
                UpdateJson.agecyInfoList[i].assignmentGroupNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.assignmentGroupNumber;
                UpdateJson.agecyInfoList[i].countrycode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.countrycode;
                UpdateJson.agecyInfoList[i].agencyDescription = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.agencyDescription;
                UpdateJson.agecyInfoList[i].channelCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.channelCode;
                UpdateJson.agecyInfoList[i].levelCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.levelCode;
                UpdateJson.agecyInfoList[i].programCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.programCode;
                UpdateJson.agecyInfoList[i].legacyRecoverCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyInfo.legacyRecoverCode;
                #endregion

                ////////////AGENCYASSIGMENT//////////////
                #region agencyAssignment.
                UpdateJson.AgencyAssignmentList[i].updateDate = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.updateDate;
                UpdateJson.AgencyAssignmentList[i].updatedBy = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.updatedBy;
                UpdateJson.AgencyAssignmentList[i].agencyId = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.agencyId;
                UpdateJson.AgencyAssignmentList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.accountNumber;
                UpdateJson.AgencyAssignmentList[i].accountCategoryTypeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.accountCategoryTypeCode;
                UpdateJson.AgencyAssignmentList[i].accountStatusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.accountStatusCode;
                UpdateJson.AgencyAssignmentList[i].countryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.countryCode;
                UpdateJson.AgencyAssignmentList[i].agencyAssignmentStatusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.agencyAssignmentStatusCode;
                UpdateJson.AgencyAssignmentList[i].accountInsertTimeStamp = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.accountInsertTimeStamp;
                UpdateJson.AgencyAssignmentList[i].agencyAssignmentDate = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.agencyAssignmentDate;
                UpdateJson.AgencyAssignmentList[i].balanceAmount = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.balanceAmount;
                UpdateJson.AgencyAssignmentList[i].noOfDays = resultsPlacement.caseInfoList[i].accountInfoList[0].agencyAssignment.noOfDays;
                #endregion



            }

            //string output = JsonConvert.SerializeObject(UpdateJson,);

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            //var jsonModel = JsonConvert.DeserializeObject(output, settings);

            string output = JsonConvert.SerializeObject(UpdateJson, settings);


            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATE" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
        }

        public void Json_Update_(string archivo, string NombreJson, string[] Dividido)
        {
            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();
            //UpdateJson.header = resultsPlacement.header;

            string output = JsonConvert.SerializeObject(UpdateJson);

            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATE" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
        }
        public string Cadena(int tipo, AccountMaster accountMaster, Comaker comaker, CreditHistory credithistory, History history, MasterRecord masterrecord, UserRecord userrecord, XRecord xrecord, ArchivoMTFIinancial archivoMT ,ArchivoMT archivoMT_, ArchivoRecall archivoRecall)
        {
            string x = "";
            switch (tipo)
            {
                case 1:
                    x = @"" + accountMaster.AccountNumber + accountMaster.RecordType + accountMaster.SequenceNumber + accountMaster.Title + accountMaster.CustomerType + accountMaster.Name + accountMaster.AccountAddress1 + accountMaster.AccountAddress2 + accountMaster.City
                    + accountMaster.County + accountMaster.State + accountMaster.ZipCode + accountMaster.HomePhone + accountMaster.WorkPhone + accountMaster.BirthDate + accountMaster.EmployerName + accountMaster.EmployerAddress + accountMaster.ProductCode + accountMaster.OfficerCode
                    + accountMaster.DefinedCode2 + accountMaster.RecovererCode + accountMaster.PHONEflag + accountMaster.ReasonCode + accountMaster.AccountStatus + accountMaster.InterestRate + accountMaster.SourceCode + accountMaster.ReceiptDate + accountMaster.ContractDate
                    + accountMaster.ChargeDate + accountMaster.LastPaymentDate + accountMaster.ChargeAmount + accountMaster.AssociatedCosts + accountMaster.AccruedInterest + accountMaster.CurrentBalance + accountMaster.NetPrincipal + accountMaster.NetAssociatedCosts
                    + accountMaster.NetInterest + accountMaster.LastCommentLine1 + accountMaster.LastCommentLine2 + accountMaster.LastCommentLine3 + accountMaster.LastCommentDate + accountMaster.SecondNameLastName + accountMaster.SecondNamesFirstName + accountMaster.MonthlyIncome
                    + accountMaster.OtherIncome + accountMaster.MonthlyPayment + accountMaster.OtherObligations + accountMaster.OwnRentCode + accountMaster.ReturnMetricScore + accountMaster.NextPaymentDate + accountMaster.LastInterestDate + accountMaster.LastContactDate
                    + accountMaster.CommissionRate + accountMaster.Filler1 + accountMaster.Filler2 + accountMaster.Filler3 + accountMaster.CustomerID + accountMaster.Filler4 + accountMaster.AgencyCode + accountMaster.FormatCode;
                    break;
                case 2:
                    x = @"" + comaker.AccountNumber + comaker.RecordType + comaker.SequenceNumber + comaker.Title + comaker.CustomerType + comaker.Name + comaker.Address1 + comaker.Address2 + comaker.City + comaker.County + comaker.State + comaker.ZipCode + comaker.HomePhone
                                      + comaker.WorkPhone + comaker.BirthDate + comaker.EmployersName + comaker.SocialSecurity + comaker.Filler1 + comaker.CustomerID + comaker.Filler2 + comaker.AgencyCode + comaker.FormatCode;
                    break;
                case 3:
                    x = @"" + credithistory.AccountNumber + credithistory.RecordType + credithistory.SequenceNumber + credithistory.CycleCutDate + credithistory.DueDate + credithistory.AcctAginginmonth01 + credithistory.AcctAginginmonth02 + credithistory.AcctAginginmonth03
                    + credithistory.AcctAginginmonth04 + credithistory.AcctAginginmonth05 + credithistory.AcctAginginmonth06 + credithistory.Filler1 + credithistory.Filler2 + credithistory.Filler3 + credithistory.Filler4 + credithistory.Filler5 + credithistory.Ability + credithistory.Summarycreditinmonth1
                    + credithistory.Summarycreditinmonth2 + credithistory.Summarycreditinmonth3 + credithistory.Summarycreditinmonth4 + credithistory.Summarycreditinmonth5 + credithistory.Summarycreditinmonth6 + credithistory.Summarycreditinmonth7 + credithistory.Summarycreditinmonth8
                    + credithistory.Summarycreditinmonth9 + credithistory.Summarycreditinmonth10 + credithistory.Summarycreditinmonth11 + credithistory.Summarycreditinmonth12 + credithistory.AcctBalanceinmonth01 + credithistory.AcctBalanceinmonth02 + credithistory.AcctBalanceinmonth03
                    + credithistory.AcctBalanceinmonth04 + credithistory.AcctBalanceinmonth05 + credithistory.AcctBalanceinmonth06 + credithistory.AssessedLastMonth + credithistory.Assessed2MonthsAgo + credithistory.Assessed3MonthsAgo + credithistory.Assessed4MonthsAgo + credithistory.Filler6
                    + credithistory.Filler7 + credithistory.Summarydebitsinmonth1 + credithistory.Summarydebitsinmonth2 + credithistory.Summarydebitsinmonth3 + credithistory.Summarydebitsinmonth4 + credithistory.Summarydebitsinmonth5 + credithistory.Summarydebitsinmonth6 + credithistory.Summarydebitsinmonth7
                    + credithistory.Summarydebitsinmonth8 + credithistory.Summarydebitsinmonth9 + credithistory.Summarydebitsinmonth10 + credithistory.Summarydebitsinmonth11 + credithistory.Summarydebitsinmonth12 + credithistory.CreditorField + credithistory.FutureUse_CreditLimit + credithistory.WAIVERORGUARANTEED
                    + credithistory.LifeInsuranceIndicator + credithistory.Liability + credithistory.LargeorMiddlemarket + credithistory.CycleCut + credithistory.Exposure_CCSG + credithistory.Exposure_OPEN + credithistory.TotalExposure + credithistory.Filler8 + credithistory.Filler9 + credithistory.Filler10
                    + credithistory.DebttoValueRatio + credithistory.Filler11 + credithistory.Filler12 + credithistory.Filler13 + credithistory.Filler14 + credithistory.Filler15 + credithistory.Filler16 + credithistory.Parent_OrgCode + credithistory.AgencyCode + credithistory.FormatCode;
                    break;
                case 4:
                    x = @"" + history.AccountNumber + history.RecordType + history.SequenceNumber + history.Date_NoteLine + history.Filler + history.AgencyCode + history.FormatCode;
                    break;
                case 5:
                    x = @"" + masterrecord.AccountNumber + masterrecord.RecordType + masterrecord.SequenceNumber + masterrecord.SuitReason + masterrecord.JudgmentDate + masterrecord.CaseNumber + masterrecord.CourtName + masterrecord.JudgmentRecorded + masterrecord.JudgmentBook
                    + masterrecord.ACProgram + masterrecord.Filler1 + masterrecord.Filler2 + masterrecord.Filler3 + masterrecord.CaseNumber + masterrecord.JudgmentDate + masterrecord.BarDate + masterrecord.DismissalDate + masterrecord.DischargeDate + masterrecord.ReaffirmationDate + masterrecord.StayLiftedDate
                    + masterrecord.BankruptcyAssetIndicator + masterrecord.StopDunnRequest + masterrecord.FDCPAComplaints + masterrecord.Mindueindicator + masterrecord.ProbC + masterrecord.OldLendingScore + masterrecord.BankruptcyFilingDate + masterrecord.StatuteofLimitationsExpirationDate + masterrecord.BANKRUPTCYUSERDATE3
                    + masterrecord.ReturnMetricScore + masterrecord.EstateClaimFiledFlag + masterrecord.TotalExposure + masterrecord.SELinkageFlags + masterrecord.SpeedtoPayModel + masterrecord.HomeMarketValue + masterrecord.HomeEquity + masterrecord.OldChargeScore + masterrecord.BankruptcyAttorneyNameorExecutorName
                    + masterrecord.BankruptcyAttorneyorEstateAddress1 + masterrecord.BankruptcyAttorneyorEstateAddress2 + masterrecord.BankruptcyAttorneyorEstateCity + masterrecord.BankruptcyAttorneyorEstateState + masterrecord.BankruptcyAttorneyorEstateZip + masterrecord.BankruptcyAttorneyorExecutorPhone
                    + masterrecord.CreditBalanceReason + masterrecord.TypeofBankruptcyfiling + masterrecord.GRMSvariables + masterrecord.DeceasedDate + masterrecord.DateofLegalFiling + masterrecord.LegalProceedingCourtDate + masterrecord.EstateClaimDate + masterrecord.Reinstatementoffer + masterrecord.RecallWarningDate
                    + masterrecord.BankruptcyChapter + masterrecord.Filler4 + masterrecord.ParentOrgCode + masterrecord.AgencyCode + masterrecord.FormatCode;
                    break;
                case 6:
                    x = @"" + userrecord.AccountNumber + userrecord.RecordType + userrecord.SequenceNumber + userrecord.SocialSecurityNumber + userrecord.FullProductDescription + userrecord.FilmRequest + userrecord.AgencyBranch + userrecord.StrategyIndicator + userrecord.CorporateIDNumber
                   + userrecord.MembershipRewards + userrecord.CADVISION + userrecord.CreditBalance + userrecord.MexicoReinstatement + userrecord.SettlementAmount + userrecord.RecoveryScoreforQuads + userrecord.WriteOffAmount + userrecord.FICOScore + userrecord.OldRecoveryScore + userrecord.NewRecoveryScore
                   + userrecord.CollectionReceivableDate + userrecord.CancellationDate + userrecord.CardAnniversaryDate + userrecord.WriteOffDate + userrecord.LastChargeDate + userrecord.HomePurchaseDate + userrecord.CustomerLastPaymentDate + userrecord.ReinstatementAcceptDate + userrecord.Filler1
                   + userrecord.ParentOrgCode + userrecord.AgencyCode + userrecord.FormatCode;
                    break;
                case 7:
                    x = @"" + xrecord.AccountNumber + xrecord.RecordType + xrecord.SequenceNumber + xrecord.UserDefinedCode + xrecord.Alpha1 + xrecord.Alpha2 + xrecord.Alpha3 + xrecord.Alpha4 + xrecord.Alpha5 + xrecord.Alpha6 + xrecord.Alpha7 + xrecord.Alpha8 + xrecord.Alpha9 + xrecord.Alpha10
                    + xrecord.Numeric1 + xrecord.Numeric2 + xrecord.Numeric3 + xrecord.Numeric4 + xrecord.Numeric5 + xrecord.Numeric6 + xrecord.Numeric7 + xrecord.Numeric8 + xrecord.Numeric9 + xrecord.Numeric10 + xrecord.Date1 + xrecord.Date2 + xrecord.Date3 + xrecord.Date4 + xrecord.Date5 + xrecord.Date6 + xrecord.Date7
                    + xrecord.Date8 + xrecord.Date9 + xrecord.Date10 + xrecord.Filler1 + xrecord.Filler2 + xrecord.AgencyCode + xrecord.FormatCode;
                    break;
                case 8:
                    x = @"" + archivoMT.DATE + archivoMT.TIME + archivoMT.ACCOUNTNUMBER + archivoMT.TRANSACTION_CODE + archivoMT.TRANSACTION_AMOUNT+ archivoMT.FLAG + archivoMT.SELF + archivoMT.DESCRIPCION + archivoMT.PAYMENT + archivoMT.PERCENT + archivoMT.FLAG_INT_EXT + archivoMT.RECOVERER_CODE + archivoMT.RECOVERER_ID + archivoMT.LOAN_CODE + archivoMT.FILL;
                    int xxx = x.Length;
                    break;
                case 9:
                    x = @"" + archivoRecall.DATE + archivoRecall.TIME + archivoRecall.ACCOUNTNUMBER + archivoRecall.TRANSACTION_CODE + archivoRecall.FIELD_CODE + archivoRecall.FILL + archivoRecall.FLAG + archivoRecall.RECOVERER_CODE + archivoRecall.RECOVERER_ID + archivoRecall.LOAN_CODE + archivoRecall.FILLER;                    
                    break;

                default:
                    break;
            }
            return x;
        }
        public DataRow GenerarRegistro(DataRow newrow, int i)
        {
            for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList.Count; ii++)
            {

                newrow["CRAC01"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month01.ToString().Trim();
                newrow["CRAC02"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month02.ToString().Trim();
                newrow["CRAC03"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month03.ToString().Trim();
                newrow["CRAC04"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month04.ToString().Trim();
                newrow["CRAC05"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month05.ToString().Trim();
                newrow["CRAC06"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month06.ToString().Trim();
                newrow["CRAC07"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month07.ToString().Trim();
                newrow["CRAC08"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month08.ToString().Trim();
                newrow["CRAC09"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month09.ToString().Trim();
                newrow["CRAC10"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month10.ToString().Trim();
                newrow["CRAC11"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month11.ToString().Trim();
                newrow["CRAC12"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.debitSummaryInMonths.Month12.ToString().Trim();
                newrow["CRAP01"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month01.ToString().Trim();
                newrow["CRAP02"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month02.ToString().Trim();
                newrow["CRAP03"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month03.ToString().Trim();
                newrow["CRAP04"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month04.ToString().Trim();
                newrow["CRAP05"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month05.ToString().Trim();
                newrow["CRAP06"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountBalanceInMonths.Month06.ToString().Trim();
                newrow["CRAP07"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.interestAccessedByMonth.Month01.ToString().Trim();
                newrow["CRAP08"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.interestAccessedByMonth.Month02.ToString().Trim();
                newrow["CRAP09"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.interestAccessedByMonth.Month03.ToString().Trim();
                newrow["CRAP10"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.interestAccessedByMonth.Month04.ToString().Trim();
                newrow["CRLCAD"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.cycleCutDate.ToString().Trim();
                newrow["CRLPRD"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.dueDate.ToString().Trim();
                newrow["CRP180"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.cycleCut.ToString().Trim();
                newrow["CRPA01"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month01.ToString().Trim();
                newrow["CRPA02"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month02.ToString().Trim();
                newrow["CRPA03"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month03.ToString().Trim();
                newrow["CRPA04"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month04.ToString().Trim();
                newrow["CRPA05"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month05.ToString().Trim();
                newrow["CRPA06"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month06.ToString().Trim();
                newrow["CRPA07"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month07.ToString().Trim();
                newrow["CRPA08"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month08.ToString().Trim();
                newrow["CRPA09"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month09.ToString().Trim();
                newrow["CRPA10"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month10.ToString().Trim();
                newrow["CRPA11"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month11.ToString().Trim();
                newrow["CRPA12"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.summaryCreditInMonths.Month12.ToString().Trim();
                newrow["CRPN01"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month01.ToString().Trim();
                newrow["CRPN02"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month02.ToString().Trim();
                newrow["CRPN03"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month03.ToString().Trim();
                newrow["CRPN04"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month04.ToString().Trim();
                newrow["CRPN05"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month05.ToString().Trim();
                newrow["CRPN06"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialSummary.accountAgingInMonths.Month06.ToString().Trim();
                newrow["MASB$1"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.minDueIndicator.ToString().Trim();
                newrow["MASB$3"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].riskScore.lendingPayToCurrrentScore.ToString().Trim();
                newrow["MASL10"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.cancelCode.ToString().Trim();
                newrow["MASLN8"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.totalExposure.ToString().Trim();
                newrow["MASU04"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].agencyInfo.agencyBranchName.ToString().Trim();
                newrow["MASU09"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.crDate.ToString().Trim();
                newrow["MASU10"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.cancellationDate.ToString().Trim();
                newrow["MASU11"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.cardOpenDate.ToString().Trim();
                newrow["MASU18"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].collectionScore.ficoScore.ToString().Trim();
                newrow["MASU21"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.lastChargeActivity.ToString().Trim();
                newrow["X00AAK"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.totalAmountDueInUSD.ToString().Trim();
                newrow["X00AAL"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.unbilledAmountDueInUSD.ToString().Trim();
                newrow["X00AAM"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.currentAmountDueInUSD.ToString().Trim();
                newrow["X00AAN"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue30DaysInUSD.ToString().Trim();
                newrow["X00AAO"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue60DaysInUSD.ToString().Trim();
                newrow["X00AAP"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue90DaysInUSD.ToString().Trim();
                newrow["X00AAQ"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue120DaysInUSD.ToString().Trim();
                newrow["X00AAR"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue150DaysInUSD.ToString().Trim();
                newrow["X00ABK"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.minimumAmountDue.ToString().Trim();
                newrow["X00ABL"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.unbilledAmountDue.ToString().Trim();
                newrow["X00ABM"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.currentAmountDue.ToString().Trim();
                newrow["X00ABN"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue30Days.ToString().Trim();
                newrow["X00ABO"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue60Days.ToString().Trim();
                newrow["X00ABP"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue90Days.ToString().Trim();
                newrow["X00ABQ"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue120Days.ToString().Trim();
                newrow["X00ABR"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].customerFinancial.amountDue150Days.ToString().Trim();
                newrow["X00BAK"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.totalCustomerLevelMinDueCcsg.ToString().Trim();
                newrow["X00BAL"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.totalCustomerLevelMinDueOpen.ToString().Trim();
                newrow["X00BAM"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].financialRisk.totalCustomerLevelMinDue.ToString().Trim();
                newrow["M00CNT"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].agencyInfo.countrycode.ToString().Trim();
                newrow["MASACT"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].accountDetails.accountNumber.ToString().Trim();

                newrow["MASU13"] = @"" + resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.strategyIndicator1.ToString().Trim() + "/" +
                                       resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.strategyIndicator2.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.strategyIndicator3.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.strategyIndicator4.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.noOfCcsgChargeCardsCustomerHas.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.noOfCcsgLendingCardsCustomerHas.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.segmentId1.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.segmentId2.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.segmentId3.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.segmentId4.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.noOfOpenCardsCustomerHas.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.reAgeIndicator.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.careEligibility.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.writtenOffIndicator.ToString().Trim() + "/" +
                resultsPlacement.caseInfoList[i].accountInfoList[ii].strategyInfo.lendingInCharge.ToString().Trim();

                newrow["X00BAA"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[0].lastUpdatedDate.ToString().Trim();
                if (Convert.ToBoolean(newrow["X00BAB"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[0].name != null))
                    newrow["X00BAB"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[0].name;
                else
                    newrow["X00BAB"] = null;



                newrow["X00BAE"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[0].bankAccountNumber.ToString().Trim();
                newrow["X00BAF"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[0].abaNumber.ToString().Trim();

                if (resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks.Count > 1)
                {
                    newrow["X00BBA"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[1].lastUpdatedDate.ToString().Trim();
                    newrow["X00BBF"] = resultsPlacement.caseInfoList[i].accountInfoList[ii].bankList.banks[1].abaNumber.ToString().Trim();
                }




            }

            //for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
            //{
            //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode == "HOME")
            //    {
            //        if (newrow["MASHPH"].ToString() != string.Empty)
            //        {
            //            newrow["MASHPH"] = newrow["MASHPH"] + "/" + resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Trim();
            //        }
            //        else
            //        {
            //            newrow["MASHPH"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Trim();
            //        }

            //    }

            //    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode == "WORK")
            //    {

            //        if (newrow["MASOPH"].ToString() != string.Empty)
            //        {
            //            newrow["MASOPH"] = newrow["MASHPH"] + "/" + resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Trim();
            //        }
            //        else
            //        {
            //            newrow["MASOPH"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number.ToString().Trim();
            //        }

            //    }             
            //}


            //for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses.Count; ii++)
            //{
            //    newrow["MASAD1"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].addressLine1.ToString().Trim();
            //    newrow["MASAD2"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].addressLine2.ToString().Trim();
            //    newrow["MASCNT"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].country.ToString().Trim();
            //    newrow["MASCTY"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].city.ToString().Trim();
            //    newrow["MASSTC"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].state.ToString().Trim();
            //}
            //newrow["MASBDY"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.birthDate.ToString().Trim();            
            //newrow["MASDAS"] = resultsPlacement.caseInfoList[i].agencyAssignment.agencyAssignmentDate.ToString().Trim();
            //newrow["MASEAD"] = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.address.ToString().Trim();
            //newrow["MASENM"] = resultsPlacement.caseInfoList[i].accountInfoList[0].employer.name.ToString().Trim();
            //newrow["MASFNM"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName.ToString().Trim();
            //newrow["MASFRD"] = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.receiptDate.ToString().Trim();            
            //newrow["MASLNM"] = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName.ToString().Trim();           
            //newrow["MASTAX"] = resultsPlacement.caseInfoList[i].accountInfoList[0].customerDetails.customerId.ToString().Trim();

            return newrow;
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {



        }
        public void GenerarColumnas()
        {
            PRUEBA.Columns.Add("CRAC01");
            PRUEBA.Columns.Add("CRAC02");
            PRUEBA.Columns.Add("CRAC03");
            PRUEBA.Columns.Add("CRAC04");
            PRUEBA.Columns.Add("CRAC05");
            PRUEBA.Columns.Add("CRAC06");
            PRUEBA.Columns.Add("CRAC07");
            PRUEBA.Columns.Add("CRAC08");
            PRUEBA.Columns.Add("CRAC09");
            PRUEBA.Columns.Add("CRAC10");
            PRUEBA.Columns.Add("CRAC11");
            PRUEBA.Columns.Add("CRAC12");
            PRUEBA.Columns.Add("CRAP01");
            PRUEBA.Columns.Add("CRAP02");
            PRUEBA.Columns.Add("CRAP03");
            PRUEBA.Columns.Add("CRAP04");
            PRUEBA.Columns.Add("CRAP05");
            PRUEBA.Columns.Add("CRAP06");
            PRUEBA.Columns.Add("CRAP07");
            PRUEBA.Columns.Add("CRAP08");
            PRUEBA.Columns.Add("CRAP09");
            PRUEBA.Columns.Add("CRAP10");
            PRUEBA.Columns.Add("CRLCAD");
            PRUEBA.Columns.Add("CRLPRD");
            PRUEBA.Columns.Add("CRP180");
            PRUEBA.Columns.Add("CRPA01");
            PRUEBA.Columns.Add("CRPA02");
            PRUEBA.Columns.Add("CRPA03");
            PRUEBA.Columns.Add("CRPA04");
            PRUEBA.Columns.Add("CRPA05");
            PRUEBA.Columns.Add("CRPA06");
            PRUEBA.Columns.Add("CRPA07");
            PRUEBA.Columns.Add("CRPA08");
            PRUEBA.Columns.Add("CRPA09");
            PRUEBA.Columns.Add("CRPA10");
            PRUEBA.Columns.Add("CRPA11");
            PRUEBA.Columns.Add("CRPA12");
            PRUEBA.Columns.Add("CRPN01");
            PRUEBA.Columns.Add("CRPN02");
            PRUEBA.Columns.Add("CRPN03");
            PRUEBA.Columns.Add("CRPN04");
            PRUEBA.Columns.Add("CRPN05");
            PRUEBA.Columns.Add("CRPN06");
            PRUEBA.Columns.Add("M00CNT");
            PRUEBA.Columns.Add("MASACT");
            PRUEBA.Columns.Add("MASAD1");
            PRUEBA.Columns.Add("MASAD2");
            PRUEBA.Columns.Add("MASB$1");
            PRUEBA.Columns.Add("MASB$3");
            PRUEBA.Columns.Add("MASBDY");
            PRUEBA.Columns.Add("MASCNT");
            PRUEBA.Columns.Add("MASCTY");
            PRUEBA.Columns.Add("MASDAS");
            PRUEBA.Columns.Add("MASEAD");
            PRUEBA.Columns.Add("MASENM");
            PRUEBA.Columns.Add("MASFNM");
            PRUEBA.Columns.Add("MASFRD");
            PRUEBA.Columns.Add("MASHPH");
            PRUEBA.Columns.Add("MASL10");
            PRUEBA.Columns.Add("MASLN8");
            PRUEBA.Columns.Add("MASLNM");
            PRUEBA.Columns.Add("MASOPH");
            PRUEBA.Columns.Add("MASSTC");
            PRUEBA.Columns.Add("MASTAX");
            PRUEBA.Columns.Add("MASU04");
            PRUEBA.Columns.Add("MASU09");
            PRUEBA.Columns.Add("MASU10");
            PRUEBA.Columns.Add("MASU11");
            PRUEBA.Columns.Add("MASU13");
            PRUEBA.Columns.Add("MASU18");
            PRUEBA.Columns.Add("MASU21");
            PRUEBA.Columns.Add("X00AAK");
            PRUEBA.Columns.Add("X00AAL");
            PRUEBA.Columns.Add("X00AAM");
            PRUEBA.Columns.Add("X00AAN");
            PRUEBA.Columns.Add("X00AAO");
            PRUEBA.Columns.Add("X00AAP");
            PRUEBA.Columns.Add("X00AAQ");
            PRUEBA.Columns.Add("X00AAR");
            PRUEBA.Columns.Add("X00ABK");
            PRUEBA.Columns.Add("X00ABL");
            PRUEBA.Columns.Add("X00ABM");
            PRUEBA.Columns.Add("X00ABN");
            PRUEBA.Columns.Add("X00ABO");
            PRUEBA.Columns.Add("X00ABP");
            PRUEBA.Columns.Add("X00ABQ");
            PRUEBA.Columns.Add("X00ABR");
            PRUEBA.Columns.Add("X00BAA");
            PRUEBA.Columns.Add("X00BAB");
            PRUEBA.Columns.Add("X00BAE");
            PRUEBA.Columns.Add("X00BAF");
            PRUEBA.Columns.Add("X00BAK");
            PRUEBA.Columns.Add("X00BAL");
            PRUEBA.Columns.Add("X00BAM");
            PRUEBA.Columns.Add("X00BBA");
            PRUEBA.Columns.Add("X00BBF");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ReportID = "".PadRight(15);
            string Number = "".PadRight(8);
            string Hash = "".PadRight(64);
            string xxx = "LZ.E2.ACORN.ST.RECALL.V01.090418.0008";
            string xx = "LZ.E2.ACORN.ST.PLCMNT.V01.091218.0097";
            string aa1 = SHA256_.getHashSha256(xxx);
            string aaa1 = SHA256_.getHashSha256(xx);
            string a = "ACORNUPDIB";
            string b = "00000017";
            string a1 = SHA256_.getHashSha256(a);
            string a2 = SHA256_.GetSha256FromString(a);
            string a3 = SHA256_.sha256(a);
            string a4 = SHA256_.sha256_(a);
            string a5 = SHA256_.Sha256encrypt(a);
            string b1 = SHA256_.getHashSha256(b);
            string b2 = SHA256_.GetSha256FromString(b);
            string b3 = SHA256_.sha256(b);
            string b4 = SHA256_.sha256_(b);
            var password_ = "1234";
            var hashedPassword = SHA256_.Sha256encrypt(password_);




            var str = "String to be encrypted";
            var password = "p@SSword";
            var strEncryptred = SHA256_.Encrypt(str, password);
            var strDecrypted = SHA256_.Decrypt(strEncryptred, password);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sequencia = 1;
            int cuentas = 1;
            string archivo = "C:\\Users\\ABNQJ\\Downloads\\PRUEBA";
            string fecha = DateTime.Now.ToString("MMddyy");
            string NombreJson = "LZ.E2.ACORN.ST.UPDATES.V01." + fecha + "." + sequencia.ToString().PadLeft(4, '0') + "";
            string[] Dividido = NombreJson.Split('.');
            int ContadorClases = 0;

            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();

            UpdateJson.header = new Header();



            for (int i = 0; i < cuentas; i++)
            {
                UpdateJson.accountList = new List<AccountList>();
                ContadorClases++;
                UpdateJson.contactInfoList = new List<ContactInfoList>();
                ContadorClases++;
                UpdateJson.deceasedDetailsList = new List<DeceasedDetailsList>();
                ContadorClases++;
                UpdateJson.demographicsList = new List<DemographicsList>();
                ContadorClases++;
                UpdateJson.visionList = new List<VisionList>();
                ContadorClases++;
                UpdateJson.treatmentList = new List<TreatmentList>();
                ContadorClases++;
            }



            for (int i = 0; i < cuentas; i++)
            {

                UpdateJson.accountList.Add(new AccountList());
                UpdateJson.deceasedDetailsList.Add(new DeceasedDetailsList());
                UpdateJson.contactInfoList.Add(new ContactInfoList());
                UpdateJson.demographicsList.Add(new DemographicsList());
                UpdateJson.demographicsList[0].phones = new List<Phone>();
                UpdateJson.demographicsList[0].phones.Add(new Phone());
                UpdateJson.demographicsList[0].emails = new List<Emails>();
                UpdateJson.demographicsList[0].emails.Add(new Emails());
                UpdateJson.demographicsList[0].addresses = new List<Address>();
                UpdateJson.demographicsList[0].addresses.Add(new Address());
                UpdateJson.visionList.Add(new VisionList());
                UpdateJson.treatmentList.Add(new TreatmentList());


            }
            for (int i = 0; i < 1; i++)
            {

                DateTime date1 = new DateTime(2018, 8, 29, 19, 27, 15, 18);
                CultureInfo ci = CultureInfo.InvariantCulture;

                string x = date1.ToString("hh:mm:ss.fffzzz", ci);
                string date = "2009-02-25 16:13:00Z"; // Coordinated Universal Time string fromDateTime.Now.ToUniversalTime().ToString("u"); 
                DateTime localDateTime = DateTime.Parse(date);


                UpdateJson.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                UpdateJson.updateBy = "ST";
                UpdateJson.header.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                UpdateJson.header.senderID = "ST";
                UpdateJson.header.targetID = "AMEX";
                UpdateJson.header.totalRecords = ContadorClases;
                UpdateJson.header.balancingSeqNo = sequencia;
                UpdateJson.accountList[i].accountStatus = "417";
                UpdateJson.accountList[i].accountNumber = "376728004411007";
                UpdateJson.accountList[i].lastStatusChangeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);

                UpdateJson.contactInfoList[i].accountNumber = "376728004411007";
                UpdateJson.contactInfoList[i].lastContactDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);


                UpdateJson.deceasedDetailsList[i].accountNumber = "376728004411007";
                UpdateJson.deceasedDetailsList[i].attorneyName = "Sertec Attorney";
                UpdateJson.deceasedDetailsList[i].attorneyAddress = "abc Avenida Guadalalupe1";
                UpdateJson.deceasedDetailsList[i].executorCity = "Mexico 1";
                UpdateJson.deceasedDetailsList[i].executorState = "Tabasco1";
                UpdateJson.deceasedDetailsList[i].executorZip = "03600";
                UpdateJson.deceasedDetailsList[i].executorPhone = "1111111111";

                UpdateJson.demographicsList[i].accountNumber = "376728004411007";

                UpdateJson.demographicsList[i].phones[0].number = "12345678";
                UpdateJson.demographicsList[i].phones[0].typeCode = "Business";
                UpdateJson.demographicsList[i].phones[0].statusCode = "InUse";
                UpdateJson.demographicsList[i].phones[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].emails[0].emailAddress = "sertec@yahoo.com.mx";
                UpdateJson.demographicsList[i].emails[0].typeCode = "Home";
                UpdateJson.demographicsList[i].emails[0].statusCode = "InUse";
                UpdateJson.demographicsList[i].emails[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].addresses[0].addressLine1 = "calle Los lagos1";
                UpdateJson.demographicsList[i].addresses[0].addressLine2 = "Colonia Prado1";
                UpdateJson.demographicsList[i].addresses[0].addressLine3 = "Alcaldía Benito Juárez";
                UpdateJson.demographicsList[i].addresses[0].country = "México";
                UpdateJson.demographicsList[i].addresses[0].city = "Ciudad de México";
                UpdateJson.demographicsList[i].addresses[0].zipCode = "11111";
                UpdateJson.demographicsList[i].addresses[0].state = "Ciudad de México2";
                UpdateJson.demographicsList[i].addresses[0].typeCode = "Home";
                UpdateJson.demographicsList[i].addresses[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].returnMailIndicator = "Y";

                UpdateJson.visionList[i].accountNumber = "376728004411007";
                UpdateJson.visionList[i].rpc = "Y";
                UpdateJson.visionList[i].rpcTypeCode = "P";

                UpdateJson.treatmentList[i].accountNumber = "376728004411007";
                UpdateJson.treatmentList[i].treatmentProgram = "Oasis";
                UpdateJson.treatmentList[i].treatmentOffer = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].treatmentAccept = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].treatmentCompletion = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].treatmentExpiration = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
                //UpdateJson.treatmentList[i].actualSettlementAmount = 1000.00;
                //UpdateJson.treatmentList[i].agreedSettlementAmount = 1000.00;



            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "yyyy-MM-ddThh:mm:ss.fffzz00"
            };
            //var jsonModel = JsonConvert.DeserializeObject(output, settings);

            string output = JsonConvert.SerializeObject(UpdateJson, settings);


            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
            NombreJson = Dividido[0] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);

            string contents = File.ReadAllText(archivo + "\\" + NombreJson);
            string Number = "".PadRight(8);
            string a1 = SHA256_.getHashSha256(contents);
            string a2 = SHA256_.sha256(contents);
            string ReportID = "".PadRight(15);
            ReportID = "ACORNSTUPDIB".PadRight(15);
            Number = Dividido[7].Substring(2).PadLeft(8, '0');
            string totalText = ReportID + Number + a2;
            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);
            NombreJson = Dividido[0] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);

        }



        private void Json_UpdateTOTALES(string archivo, string NombreJson, string[] Dividido)
        {
            int ValidadorContactInfo = 0,
                ValidadorDeceasedDetails = 0,
                ValidadorTreatVision = 0,
                ValidadorTreat = 0,
                ValidarDemographics = 0,
                ContadorClases = 0;


            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();
            UpdateJson.header = new Header();
            UpdateJson.accountList = new List<AccountList>();
            UpdateJson.contactInfoList = new List<ContactInfoList>();

            UpdateJson.deceasedDetailsList = new List<DeceasedDetailsList>();
            UpdateJson.demographicsList = new List<DemographicsList>();

            UpdateJson.visionList = new List<VisionList>();
            UpdateJson.treatmentList = new List<TreatmentList>();

            for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            {
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                {
                    UpdateJson.accountList.Add(new AccountList());
                    ContadorClases++;
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                {
                    UpdateJson.deceasedDetailsList.Add(new DeceasedDetailsList());
                    ContadorClases++;
                }
                else
                {
                    ValidadorDeceasedDetails++;
                }


                if (resultsPlacement.caseInfoList[i].accountInfoList[0].contactInfo != null)
                {
                    UpdateJson.contactInfoList.Add(new ContactInfoList());
                    ContadorClases++;
                }
                else
                {
                    ValidadorContactInfo++;
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                {
                    UpdateJson.demographicsList.Add(new DemographicsList());
                    ContadorClases++;
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails != null)
                    {
                        UpdateJson.demographicsList[i].emails = new List<Emails>();
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].emails.Add(new Emails());
                        }
                    }

                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                    {
                        UpdateJson.demographicsList[i].addresses = new List<Address>();
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].addresses.Add(new Address());
                        }
                    }

                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                    {
                        UpdateJson.demographicsList[i].phones = new List<Phone>();
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].phones.Add(new Phone());
                        }
                    }

                }
                else
                {
                    ValidarDemographics++;
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                {
                    UpdateJson.treatmentList.Add(new TreatmentList());
                    ContadorClases++;
                   
                }
                else
                {
                    ValidadorTreat++;
                    ValidadorTreatVision++;
                }





            }



            if (ValidadorContactInfo == resultsPlacement.caseInfoList.Count)
            {
                UpdateJson.contactInfoList = null;
            }
            if (ValidadorDeceasedDetails == resultsPlacement.caseInfoList.Count)
            {
                UpdateJson.deceasedDetailsList = null;
            }
            if (ValidadorTreatVision == resultsPlacement.caseInfoList.Count)
            {
                UpdateJson.visionList = null;
            }
            if (ValidadorTreat == resultsPlacement.caseInfoList.Count)
            {
                UpdateJson.treatmentList = null;
            }




            UpdateJson.updateDate = resultsPlacement.updateDate;
            UpdateJson.updateBy = "ST";
            UpdateJson.header.updateDate = DateTime.Now;
            UpdateJson.header.senderID = "ST";
            UpdateJson.header.targetID = "AMEX";
            UpdateJson.header.totalRecords = resultsPlacement.caseInfoList.Count;
            UpdateJson.header.balancingSeqNo = 1;

            for (int i = 0; i < resultsPlacement.caseInfoList.Count; i++)
            {
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].account != null)
                {
                    UpdateJson.accountList[i].accountStatus = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountStatus;
                    UpdateJson.accountList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].account.accountNumber;
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].contactInfo != null)
                {
                    UpdateJson.contactInfoList[i].lastContactDate = resultsPlacement.caseInfoList[i].accountInfoList[0].contactInfo.lastContactDate;
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails != null)
                {
                    UpdateJson.deceasedDetailsList[i].attorneyName = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attorneyName;
                    UpdateJson.deceasedDetailsList[i].attorneyAddress = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.attroneyAddress;
                    UpdateJson.deceasedDetailsList[i].executorCity = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorCity; ;
                    UpdateJson.deceasedDetailsList[i].executorState = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorState; ;
                    UpdateJson.deceasedDetailsList[i].executorZip = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorZip;
                    UpdateJson.deceasedDetailsList[i].executorPhone = resultsPlacement.caseInfoList[i].accountInfoList[0].deceasedDetails.executorPhone;
                }
                if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics != null)
                {
                    ////////////Demographics////////////////////
                    #region DEMOGRAPHICS
                    UpdateJson.demographicsList[i].returnMailIndicator = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.returnMailIndicator;
                    UpdateJson.demographicsList[i].accountNumber = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.accountNumber;
                    UpdateJson.demographicsList[i].firstName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.firstName;
                    UpdateJson.demographicsList[i].lastName = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.lastName;
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses != null)
                    {
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].addresses[ii].addressLine1 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].addressLine1;
                            UpdateJson.demographicsList[i].addresses[ii].addressLine2 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].addressLine2;
                            UpdateJson.demographicsList[i].addresses[ii].addressLine3 = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].addressLine3;
                            UpdateJson.demographicsList[i].addresses[ii].country = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].country;
                            UpdateJson.demographicsList[i].addresses[ii].city = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].city;
                            UpdateJson.demographicsList[i].addresses[ii].zipCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].zipCode;
                            UpdateJson.demographicsList[i].addresses[ii].state = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].state;
                            UpdateJson.demographicsList[i].addresses[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.addresses[ii].typeCode;
                        }
                    }
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones != null)
                    {
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].phones[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].typeCode;
                            UpdateJson.demographicsList[i].phones[ii].categoryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].categoryCode;
                            UpdateJson.demographicsList[i].phones[ii].statusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].statusCode;
                            UpdateJson.demographicsList[i].phones[ii].number = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.phones[ii].number;
                        }
                    }
                    if (resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails != null)
                    {
                        for (int ii = 0; ii < resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails.Count; ii++)
                        {
                            UpdateJson.demographicsList[i].emails[ii].emailAddress = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails[ii].emailAddress;
                            UpdateJson.demographicsList[i].emails[ii].typeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails[ii].typeCode;
                            UpdateJson.demographicsList[i].emails[ii].statusCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails[ii].statusCode;
                            UpdateJson.demographicsList[i].emails[ii].categoryCode = resultsPlacement.caseInfoList[i].accountInfoList[0].demographics.emails[ii].categoryCode;
                        }
                    }


                    #endregion
                }

                if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment != null)
                {

                    UpdateJson.treatmentList[i].treatmentProgram = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.treatmentProgram;
                    //UpdateJson.treatmentList[i].treatmentOffer = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.treatmentOffer;
                    //UpdateJson.treatmentList[i].treatmentAccept = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.treatmentAccept;
                    //UpdateJson.treatmentList[i].treatmentCompletion = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.treatmentCompletion;
                    //UpdateJson.treatmentList[i].treatmentExpiration = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.trea;


                    //if (resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.vision != null)
                    //{

                    //    UpdateJson.visionList[i].rpc = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.vision.rpc;
                    //    UpdateJson.visionList[i].rpcTypeCode = resultsPlacement.caseInfoList[i].accountInfoList[0].treatment.vision.rpcTypeCode;
                    //}

                }










            }

            //string output = JsonConvert.SerializeObject(UpdateJson,);

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            //var jsonModel = JsonConvert.DeserializeObject(output, settings);

            string output = JsonConvert.SerializeObject(UpdateJson, settings);


            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[2] + "." + "UPDATE" + "." + Dividido[4] + "." + Dividido[5] + "." + Dividido[6];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
        }

        private void Txt_Update_Click(object sender, EventArgs e)
        {
            List<spSelectOracle_Result> Resultado = new List<spSelectOracle_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                Resultado = DB.spSelectOracle().ToList();
            }
        }

        private void Txt_Generar_Click(object sender, EventArgs e)
        {
        //    IList<spSelectUpdateAmex_Result> result = new List<spSelectUpdateAmex_Result>();
        //    using (CYBEREntities DB = new CYBEREntities())
        //    {
        //        result = DB.spSelectUpdateAmex().ToList();
        //    }

        //    int sequencia = 3;
        //    int cuentas = 1;
        //    string archivo = "C:\\Users\\ABNQJ\\Downloads\\PRUEBA";
        //    string fecha = DateTime.Now.ToString("MMddyy");
        //    string NombreJson = "LZ.E2.ACORN.ST.UPDATES.V01." + fecha + "." + sequencia.ToString().PadLeft(4, '0') + "";
        //    string[] Dividido = NombreJson.Split('.');
        //    int ContadorClases = 0;

        //    Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();

        //    UpdateJson.header = new Header();
        //    for (int i = 0; i < cuentas; i++)
        //    {
        //        //UpdateJson.accountList = new List<AccountList>();
        //        //ContadorClases++;
        //        //UpdateJson.contactInfoList = new List<ContactInfoList>();
        //        //ContadorClases++;
        //        //UpdateJson.deceasedDetailsList = new List<DeceasedDetailsList>();
        //        //ContadorClases++;
        //        UpdateJson.demographicsList = new List<DemographicsList>();
        //        //UpdateJson.visionList = new List<VisionList>();
        //        //ContadorClases++;
        //        //UpdateJson.treatmentList = new List<TreatmentList>();
        //        //ContadorClases++;
        //    }



        //    for (int i = 0; i < result.Count; i++)
        //    {

        //        //UpdateJson.accountList.Add(new AccountList());
        //        //UpdateJson.deceasedDetailsList.Add(new DeceasedDetailsList());
        //        //UpdateJson.contactInfoList.Add(new ContactInfoList());
        //        UpdateJson.demographicsList.Add(new DemographicsList());
        //        ContadorClases++;
        //        //UpdateJson.demographicsList[0].phones = new List<Phone>();
        //        //UpdateJson.demographicsList[0].phones.Add(new Phone());


        //        if (result[i].EMAIL != null)
        //        {
        //            UpdateJson.demographicsList[i].emails = new List<Emails>();
        //            UpdateJson.demographicsList[i].emails.Add(new Emails());
        //        }


        //        UpdateJson.demographicsList[i].nationalIds = new List<NationalId>();
        //        UpdateJson.demographicsList[i].nationalIds.Add(new NationalId());

        //        //UpdateJson.demographicsList[0].addresses = new List<Address>();
        //        //UpdateJson.demographicsList[0].addresses.Add(new Address());
        //        //UpdateJson.visionList.Add(new VisionList());
        //        //UpdateJson.treatmentList.Add(new TreatmentList());
        //    }
        //    for (int i = 0; i < result.Count; i++)
        //    {

        //        DateTime date1 = new DateTime(2018, 8, 29, 19, 27, 15, 18);
        //        CultureInfo ci = CultureInfo.InvariantCulture;

        //        string x = date1.ToString("hh:mm:ss.fffzzz", ci);
        //        string date = "2009-02-25 16:13:00Z"; // Coordinated Universal Time string fromDateTime.Now.ToUniversalTime().ToString("u"); 
        //        DateTime localDateTime = DateTime.Parse(date);


        //        UpdateJson.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
        //        UpdateJson.updateBy = "ST";
        //        UpdateJson.header.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
        //        UpdateJson.header.senderID = "ST";
        //        UpdateJson.header.targetID = "AMEX";
        //        UpdateJson.header.totalRecords = ContadorClases;
        //        UpdateJson.header.balancingSeqNo = sequencia;
        //        //UpdateJson.accountList[i].accountStatus = "417";
        //        //UpdateJson.accountList[i].accountNumber = "376728004411007";
        //        //UpdateJson.accountList[i].lastStatusChangeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);

        //        //UpdateJson.contactInfoList[i].accountNumber = "376728004411007";
        //        //UpdateJson.contactInfoList[i].lastContactDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);


        //        //UpdateJson.deceasedDetailsList[i].accountNumber = "376728004411007";
        //        //UpdateJson.deceasedDetailsList[i].attorneyName = "Sertec Attorney";
        //        //UpdateJson.deceasedDetailsList[i].attorneyAddress = "abc Avenida Guadalalupe1";
        //        //UpdateJson.deceasedDetailsList[i].executorCity = "Mexico 1";
        //        //UpdateJson.deceasedDetailsList[i].executorState = "Tabasco1";
        //        //UpdateJson.deceasedDetailsList[i].executorZip = "03600";
        //        //UpdateJson.deceasedDetailsList[i].executorPhone = "1111111111";


        //        UpdateJson.demographicsList[i].accountNumber = result[i].TBAXDSACCOUNTNUMBER;

        //        UpdateJson.demographicsList[i].updateDate = DateTime.Now;
        //        UpdateJson.demographicsList[i].updatedBy = "ST";
        //        //UpdateJson.demographicsList[i].phones[0].number = "12345678";
        //        //UpdateJson.demographicsList[i].phones[0].typeCode = "Business";
        //        //UpdateJson.demographicsList[i].phones[0].statusCode = "InUse";
        //        //UpdateJson.demographicsList[i].phones[0].categoryCode = "OA provided";
        //        if (result[i].EMAIL != null)
        //        {
        //            UpdateJson.demographicsList[i].emails[0].emailAddress = result[i].EMAIL;
        //            UpdateJson.demographicsList[i].emails[0].typeCode = result[i].EMAIL_TYPE;
        //            UpdateJson.demographicsList[i].emails[0].statusCode = result[i].EMAIL_STA;
        //            UpdateJson.demographicsList[i].emails[0].updateDate = result[i].EMAIL_FECHA;
        //            UpdateJson.demographicsList[i].emails[0].updatedBy = "ST";
        //        }




        //        UpdateJson.demographicsList[i].nationalIds[0].nationalIdNumber = result[i].RFC;
        //        UpdateJson.demographicsList[i].nationalIds[0].nationalIDtype = result[i].RFC_TYPE;
        //        UpdateJson.demographicsList[i].nationalIds[0].updateDate = result[i].RFC_FECHA;
        //        UpdateJson.demographicsList[i].nationalIds[0].updatedBy = "ST";

        //        //UpdateJson.demographicsList[i].addresses[0].addressLine1 = "calle Los lagos1";
        //        //UpdateJson.demographicsList[i].addresses[0].addressLine2 = "Colonia Prado1";
        //        //UpdateJson.demographicsList[i].addresses[0].addressLine3 = "Alcaldía Benito Juárez";
        //        //UpdateJson.demographicsList[i].addresses[0].country = "México";
        //        //UpdateJson.demographicsList[i].addresses[0].city = "Ciudad de México";
        //        //UpdateJson.demographicsList[i].addresses[0].zipCode = "11111";
        //        //UpdateJson.demographicsList[i].addresses[0].state = "Ciudad de México2";
        //        //UpdateJson.demographicsList[i].addresses[0].typeCode = "Home";
        //        //UpdateJson.demographicsList[i].addresses[0].categoryCode = "OA provided";


        //        //UpdateJson.visionList[i].accountNumber = "376728004411007";
        //        //UpdateJson.visionList[i].rpc = "Y";
        //        //UpdateJson.visionList[i].rpcTypeCode = "P";

        //        //UpdateJson.treatmentList[i].accountNumber = "376728004411007";
        //        //UpdateJson.treatmentList[i].treatmentProgram = "Oasis";
        //        //UpdateJson.treatmentList[i].treatmentOffer = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
        //        //UpdateJson.treatmentList[i].treatmentAccept = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
        //        //UpdateJson.treatmentList[i].treatmentCompletion = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
        //        //UpdateJson.treatmentList[i].treatmentExpiration = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
        //        //UpdateJson.treatmentList[i].actualSettlementAmount = 1000.00;
        //        //UpdateJson.treatmentList[i].agreedSettlementAmount = 1000.00;
        //        var settings = new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore,
        //            MissingMemberHandling = MissingMemberHandling.Ignore,
        //            DateFormatString = "yyyy-MM-ddThh:mm:ss.fffzz00"
        //        };
        //        //var jsonModel = JsonConvert.DeserializeObject(output, settings);

        //        string output = JsonConvert.SerializeObject(UpdateJson, settings);


        //        NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
        //        File.WriteAllText(archivo + "\\" + NombreJson, output);
        //        NombreJson = Dividido[0] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
        //        File.WriteAllText(archivo + "\\" + NombreJson, output);

        //        string contents = File.ReadAllText(archivo + "\\" + NombreJson);
        //        string Number = "".PadRight(8);
        //        string a1 = SHA256_.getHashSha256(contents);
        //        string a2 = SHA256_.sha256(contents);
        //        string ReportID = "".PadRight(15);
        //        ReportID = "ACORNSTUPDIB".PadRight(15);
        //        Number = Dividido[7].Substring(2).PadLeft(8, '0');
        //        string totalText = ReportID + Number + a2;
        //        NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
        //        File.WriteAllText(archivo + "\\" + NombreJson, totalText);
        //        NombreJson = Dividido[0] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
        //        File.WriteAllText(archivo + "\\" + NombreJson, totalText);


        //    }


        }




        private async void Btn_Json_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            await EjecutarAsynJSON();
            //Dgv_Informacion.DataSource = PRUEBA.DefaultView;
            Dgv_Informacion.Show();
            pictureBox1.Visible = false;
            Lbl_Total.Visible = true;
            Lbl_Total.Text = "Total : " + (Dgv_Informacion.Rows.Count - 1);
            lbx_Cuentas.Items.Clear();
            Txt_Cuenta.Text = string.Empty;
            Btn_Json.Enabled = false;

           
        }

        public static string QuerySQL(DataTable Total,DateTime Fecha)
        {
            string connectionString = "data source = 192.168.50.5; database = CYBER; User = usuarioCBY; password = C1bercyb; Connect Timeout = 90000";
            string mensaje;
            using (SqlConnection objSqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    #region Instancia de los parametros
                    SqlParameter sqlP_1 = new SqlParameter();
                    SqlParameter sqlP_2 = new SqlParameter();

                    #endregion


                    #region Nombre de los parametros
                    sqlP_1.ParameterName = "@i_tPaso";
                    sqlP_2.ParameterName = "@i_dFecha";



                    #endregion

                    #region Tipo de variable de los parametros
                    sqlP_1.SqlDbType = SqlDbType.Structured;
                    sqlP_2.SqlDbType = SqlDbType.Date;



                    #endregion

                    #region Tamaño del parametro




                    #endregion

                    #region Dirección del parametro


                    #endregion

                    #region Asignacion de los valores
                    sqlP_1.Value = Total;
                    sqlP_2.Value = Fecha;



                    #endregion

                    #region Creación de arreglo de parametros
                    SqlParameter[] mySQLParametros = new SqlParameter[]
                    {   sqlP_1,sqlP_2
                    };
                    #endregion

                    //Abrir conexion
                    objSqlConnection.Open();

                    //Ejecuta la sentencia
                    using (SqlCommand objSqlCommand = new SqlCommand("spInsertTabAmexUpdate", objSqlConnection))
                    {
                        var returnParameter = objSqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        mensaje  = string.Empty;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.Parameters.AddRange(mySQLParametros);
                        objSqlCommand.ExecuteScalar();
                        mensaje = returnParameter.Value.ToString();
                    }
                    //Cerrar conexion
                    objSqlConnection.Close();
                }
                catch (Exception exc)
                {
                    objSqlConnection.Close();
                    mensaje = string.Empty;
                    mensaje = exc.Message.ToString();
                }
            }
            return mensaje;
        }

        public DataTable  GenerarSaldos(string archivo)
        {
            DataTable Tabla = new DataTable();
            IList<spSelectAmexUpdateSALDOS_Result> result = new List<spSelectAmexUpdateSALDOS_Result>();
            using (CYBEREntities DB = new CYBEREntities())
            {
                result = DB.spSelectAmexUpdateSALDOS().ToList();
            }
            if (result.Count >0)
            {
                Tabla.Columns.Add("Cyclecut");
                Tabla.Columns.Add("Accountnumber");
                Tabla.Columns.Add("Currentamountdue");
                Tabla.Columns.Add("30");
                Tabla.Columns.Add("60");
                Tabla.Columns.Add("90");
                Tabla.Columns.Add("120");
                Tabla.Columns.Add("150");
                Tabla.Columns.Add("180");

                for (int i = 0; i < result.Count; i++)
                {
                    Tabla.Rows.Add(result[i].CYCLECUT, result[i].ACCOUNTNUMBER, result[i].CURRENTAMOUNTDUE, result[i].TBAXCLAMOUNTDUE30DAYS, result[i].TBAXCLAMOUNTDUE60DAYS, result[i].TBAXCLAMOUNTDUE90DAYS, result[i].TBAXCLAMOUNTDUE120DAYS, result[i].TBAXCLAMOUNTDUE150DAYS, result[i].TBAXCLAMOUNTDUE180DAYS);
                }
                Ent_Excel Excel = new Ent_Excel();
                Excel.ConvertToExcel(Tabla,archivo);
            }
            return Tabla;
        }
        public Task<DataTable> EjecutarAsynJSON()
        {
            return Task.Run(() =>
            {
                DataTable Saldos = new DataTable();
                
                DataSet ds;
                string Servidor = "192.168.90.10:1521/sertecp";
                string Usuario = "RCVRY";
                string Password = "PR3c0V3ryS3rt3C2018";
                IList<DateTime?> FechaU = new List<DateTime?>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    FechaU = DB.spSelectTabAmexUpdateFecha().ToList();
                }


                string F_FECHA = Convert.ToDateTime(FechaU[0]).ToString("dd/MM/yy");
                string queryString = @"SELECT CUENTA,FECHA,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,D11,D12,D13,D14,D15,D16,D17,D18,D19,D20 FROM RPT_UPDATE_1 WHERE TO_DATE(FECHA,'DD/MM/YY')>=TO_DATE('" + F_FECHA+ "','DD/MM/YY')";
                try
                {


                    using (OracleConnection con = new OracleConnection(string.Format("Data Source={0};User Id={1};Password={2};", Servidor, Usuario, Password)))
                    {
                        OracleDataAdapter da = new OracleDataAdapter("PROC_RPT_Update", con); // Using a Store Procedure.

                        //SqlDataAdapter da = new SqlDataAdapter("SELECT 'this is a test text' as test", con); To use a hard coded query.
                        OracleParameter OraP_1 = new OracleParameter();
                        OraP_1.ParameterName = "F_FECHA";
                        OraP_1.OracleDbType = OracleDbType.NVarchar2;
                        OraP_1.Value = F_FECHA;
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;


                        OracleParameter[] myORAParametros = new OracleParameter[]
                       {   OraP_1
                       };
                        da.SelectCommand.Parameters.AddRange(myORAParametros);

                        ds = new DataSet(); // Definition: Memory representation of the database.
                                            //da.SelectCommand.Parameters.AddWithValue("@ggg", 95); // Repeat for each parameter present in the Store Procedure.

                        da.Fill(ds); // Fill the dataset with the query data



                        //TextBox1.Text=GridView1.Rows[0].Cells[0].Text; If you want to pass the data to another element.
                    }
                }

                catch (Exception e)
                {
                    string x = e.Message;
                }


                using (OracleConnection con = new OracleConnection(string.Format("Data Source={0};User Id={1};Password={2};", Servidor, Usuario, Password)))
                {
                    using (OracleCommand command = new OracleCommand(queryString, con))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        da.SelectCommand = command;
                        DsRetorno = new DataTable();
                        da.Fill(DsRetorno);
                    }

                }
                QuerySQL(DsRetorno,Convert.ToDateTime(F_FECHA));
                //using (CYBEREntities DB = new CYBEREntities())
                //{
                //    string x = DB.spUpdateAmexTablaUpdate().ToString();
                //}
                //using (Entities DB = new Entities())
                //{
                //    DB.PROC_RPT_UPDATE();
                //}
                string FechaInicio = Dtp_Fecha.Text.ToString();
                IList<spSelectAmexUpdate_Result> result = new List<spSelectAmexUpdate_Result>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    result = DB.spSelectAmexUpdate(FechaInicio).ToList();
                }

                IList<spSelectAmexUpdateCUENTA_Result> resultCuenta = new List<spSelectAmexUpdateCUENTA_Result>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    resultCuenta = DB.spSelectAmexUpdateCUENTA(FechaInicio).ToList();
                }

                IList<string> resultDemo = new List<string>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    resultDemo = DB.spSelectAmexUpdateTOTAL(FechaInicio).ToList();
                }
                IList<string> sec = new List<string>();
                using (CYBEREntities DB = new CYBEREntities())
                {
                    sec = DB.spSelectAmexSecuencia().ToList();
                }
                int sequencia = (Convert.ToInt32(sec[0])+1);/////
                int cuentas = 1;
                string pathes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string archivo = pathes+"\\JSON\\UPDATESIB\\"+DateTime.Now.ToString("dd-MM-yyyy");
                if (!Directory.Exists(archivo))
                {
                    Directory.CreateDirectory(archivo);
                }

                Saldos = GenerarSaldos(archivo);

                string fecha = DateTime.Now.ToString("MMddyy");
                string NombreJson = "LZ.E2.ACORN.ST.UPDATES.V01." + fecha + "." + sequencia.ToString().PadLeft(4, '0') + "";
                string[] Dividido = NombreJson.Split('.');
                int ContadorClases = 0;
                IList<string> CuentasUnicas = new List<string>();

                Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();

                UpdateJson.header = new Header();

                if (resultDemo.Count > 0)
                {
                    for (int i = 0; i < resultDemo.Count; i++)
                    {
                        if (UpdateJson.demographicsList == null)
                        {
                            UpdateJson.demographicsList = new List<DemographicsList>();
                            UpdateJson.demographicsList.Add(new DemographicsList());
                        }
                        else
                        {
                            UpdateJson.demographicsList.Add(new DemographicsList());
                        }
                        ContadorClases++;
                    }
                }
               
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (i==0)
                        {
                            CuentasUnicas.Add(result[i].CUENTA);
                        }
                        else
                        {
                            if (!CuentasUnicas.Contains(result[i].CUENTA))
                            {
                                CuentasUnicas.Add(result[i].CUENTA);
                            }                           
                        }

                    }
                    if (CuentasUnicas.Count > 0)
                    {
                        for (int i = 0; i < CuentasUnicas.Count; i++)
                        {
                            if (UpdateJson.visionList == null)
                            {
                                UpdateJson.visionList = new List<VisionList>();
                                UpdateJson.visionList.Add(new VisionList());
                            }
                            else
                            {
                                UpdateJson.visionList.Add(new VisionList());
                            }
                            ContadorClases++;
                        }
                    }

                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].D5 == "AH" || result[i].D5 == "RV")
                        {
                            // if (result[i].D6 == "YA" || result[i].D6 == "RI" || result[i].D6 == "YS" || result[i].D6 == "NS" || result[i].D6 == "AI" || result[i].D6 == "OY" || result[i].D6 == "OO" || result[i].D6 == "NI" || result[i].D6 == "NA")
                            if (result[i].D6 == "YA" || result[i].D6 == "RI" || result[i].D6 == "YS"  || result[i].D6 == "AI" || result[i].D6 == "OY")
                            {
                                if (UpdateJson.treatmentList == null)
                                {
                                    UpdateJson.treatmentList = new List<TreatmentList>();
                                    UpdateJson.treatmentList.Add(new TreatmentList());
                                }
                                else
                                {
                                    UpdateJson.treatmentList.Add(new TreatmentList());
                                }
                                ContadorClases++;
                            }
                            else
                            {
                                if (result[i].D6 == "CC")
                                {
                                    string[] Cerrada =result[i].D9.ToString().Trim().Split(';');

                                    if (Cerrada[1].ToString().Trim().Substring(0, 1) == "4" && Cerrada[1].ToString().Trim().Substring(2, 1) == "2")
                                    {
                                        if (!result[i].D9.ToString().Trim().Contains("CONVENIOS"))
                                        {
                                            if (UpdateJson.treatmentList == null)
                                            {
                                                UpdateJson.treatmentList = new List<TreatmentList>();
                                                UpdateJson.treatmentList.Add(new TreatmentList());
                                            }
                                            else
                                            {
                                                UpdateJson.treatmentList.Add(new TreatmentList());
                                            }
                                            ContadorClases++;
                                        }
                                    }
                                    else
                                    {
                                        if (!result[i].D9.ToString().Trim().Contains("CONVENIOS"))
                                        {
                                            if (UpdateJson.treatmentList == null)
                                            {
                                                UpdateJson.treatmentList = new List<TreatmentList>();
                                                UpdateJson.treatmentList.Add(new TreatmentList());
                                            }
                                            else
                                            {
                                                UpdateJson.treatmentList.Add(new TreatmentList());
                                            }
                                            ContadorClases++;
                                        }
                                    }
                                }
                            }
                        }                      
                        
                    }
                }
                

                List<string> Cuentas = lbx_Cuentas.Items.OfType<string>().ToList();
                 if (resultCuenta.Count > 0)
                {
                    for (int i = 0; i < resultCuenta.Count; i++)
                    {

                        if (resultCuenta[i].D6 == "CC")
                        {
                            string[] CerradaCUENTA = resultCuenta[i].D9.ToString().Trim().Split(';');

                            if (CerradaCUENTA[1].ToString().Trim().Substring(0, 1) == "4" && CerradaCUENTA[1].ToString().Trim().Substring(2, 1) == "2")
                            {
                                if (!resultCuenta[i].D9.ToString().Trim().Contains("CONVENIOS"))
                                {
                                    if (UpdateJson.accountList == null)
                                    {
                                        UpdateJson.accountList = new List<AccountList>();
                                        UpdateJson.accountList.Add(new AccountList());
                                    }
                                    else
                                    {
                                        UpdateJson.accountList.Add(new AccountList());
                                    }
                                    ContadorClases++;
                                }
                            }
                            
                        }
                        else
                        {
                            if (resultCuenta[i].D6.ToString() == "CL")
                            {
                                if (UpdateJson.accountList == null)
                                {
                                    UpdateJson.accountList = new List<AccountList>();
                                    UpdateJson.accountList.Add(new AccountList());
                                }
                                else
                                {
                                    UpdateJson.accountList.Add(new AccountList());
                                }
                                ContadorClases++;
                            }

                        }
                    }
                }
                if (Chk_Retencion.Checked == true)
                {
                    if (resultCuenta.Count > 0)
                    {
                        for (int i = 0; i < Cuentas.Count; i++)
                        {
                            UpdateJson.accountList.Add(new AccountList());
                            ContadorClases++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Cuentas.Count; i++)
                        {
                            if (UpdateJson.accountList == null)
                            {
                                UpdateJson.accountList = new List<AccountList>();
                                UpdateJson.accountList.Add(new AccountList());
                            }
                            else
                            {
                                UpdateJson.accountList.Add(new AccountList());
                            }
                            ContadorClases++;
                        }

                    }   
                }



                if (ContadorClases > 0)
                {

                    for (int i = 0; i < 1; i++)
                    {
                        DateTime date1 = new DateTime(2018, 8, 29, 19, 27, 15, 18);
                        CultureInfo ci = CultureInfo.InvariantCulture;

                        string x = date1.ToString("hh:mm:ss.fffzzz", ci);
                        string date = "2009-02-25 16:13:00Z"; // Coordinated Universal Time string fromDateTime.Now.ToUniversalTime().ToString("u"); 
                        DateTime localDateTime = DateTime.Parse(date);


                        UpdateJson.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                        UpdateJson.updateBy = "ST";
                        UpdateJson.header.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                        UpdateJson.header.senderID = "ST";
                        UpdateJson.header.targetID = "AMEX";
                        
                        UpdateJson.header.balancingSeqNo = sequencia;




                        for (int ii = 0; ii < resultDemo.Count; ii++)
                        {

                            IList<spSelectAmexUpdatePHONE_Result> resultTelefono = new List<spSelectAmexUpdatePHONE_Result>();
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                resultTelefono = DB.spSelectAmexUpdatePHONE(resultDemo[ii].ToString(), FechaInicio).ToList();
                            }
                            if (resultTelefono.Count > 0)
                            {
                                for (int iii = 0; iii < resultTelefono.Count; iii++)
                                {
                                    UpdateJson.demographicsList[ii].phones = new List<Phone>();
                                    UpdateJson.demographicsList[ii].phones.Add(new Phone());
                                    UpdateJson.demographicsList[ii].phones[iii].updateDate = Convert.ToDateTime(resultTelefono[iii].D15);
                                    UpdateJson.demographicsList[ii].phones[iii].number = resultTelefono[iii].D4 + resultTelefono[iii].D5;
                                    UpdateJson.demographicsList[ii].phones[iii].typeCode = "Personal";
                                    UpdateJson.demographicsList[ii].phones[iii].statusCode = "InUse";
                                    UpdateJson.demographicsList[ii].phones[iii].updatedBy = "ST";
                                    using (CYBEREntities DB =  new CYBEREntities())
                                    {
                                        DB.spInsertAmexBitacora(resultDemo[ii],"TEL: "+ resultTelefono[iii].D4 + resultTelefono[iii].D5+" "+ UpdateJson.demographicsList[ii].phones[iii].statusCode, "",DateTime.Now, sequencia.ToString().PadLeft(4, '0')+" UPDATESIB", 1);
                                    }

                                }
                            }
                            IList<spSelectAmexUpdateADDRESS_Result> resultAddress = new List<spSelectAmexUpdateADDRESS_Result>();
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                resultAddress = DB.spSelectAmexUpdateADDRESS(resultDemo[ii].ToString(), FechaInicio).ToList();
                            }
                            if (resultAddress.Count > 0)
                            {
                                for (int iii = 0; iii < resultAddress.Count; iii++)
                                {
                                    UpdateJson.demographicsList[ii].addresses = new List<Address>();
                                    UpdateJson.demographicsList[ii].addresses.Add(new Address());
                                    UpdateJson.demographicsList[ii].addresses[iii].typeCode = "NotAvailable";
                                    UpdateJson.demographicsList[ii].addresses[iii].statusCode = "InUse";
                                    UpdateJson.demographicsList[ii].addresses[iii].updateDate = Convert.ToDateTime(resultAddress[iii].D14);
                                    UpdateJson.demographicsList[ii].addresses[iii].addressLine1 = resultAddress[iii].D5;
                                    UpdateJson.demographicsList[ii].addresses[iii].addressLine2 = resultAddress[iii].D6;
                                    UpdateJson.demographicsList[ii].addresses[iii].state = resultAddress[iii].D7;
                                    UpdateJson.demographicsList[ii].addresses[iii].country = resultAddress[iii].D8;
                                    UpdateJson.demographicsList[ii].addresses[iii].zipCode = resultAddress[iii].D10;
                                    UpdateJson.demographicsList[ii].addresses[iii].updatedBy = "ST";
                                    using (CYBEREntities DB = new CYBEREntities())
                                    {
                                        DB.spInsertAmexBitacora(resultDemo[ii], "DIR: " + resultAddress[iii].D5 + resultAddress[iii].D7 + " " + UpdateJson.demographicsList[ii].addresses[iii].statusCode, "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                    }
                                }
                            }
                            IList<spSelectAmexUpdateEMAIL_Result> resultEMAIL = new List<spSelectAmexUpdateEMAIL_Result>();
                            using (CYBEREntities DB = new CYBEREntities())
                            {
                                resultEMAIL = DB.spSelectAmexUpdateEMAIL(resultDemo[ii].ToString(), FechaInicio).ToList();
                            }
                            if (resultEMAIL.Count > 0)
                            {
                                for (int iii = 0; iii < resultEMAIL.Count; iii++)
                                {
                                    UpdateJson.demographicsList[ii].emails = new List<Emails>();
                                    UpdateJson.demographicsList[ii].emails.Add(new Emails());
                                    UpdateJson.demographicsList[ii].emails[iii].emailAddress = resultEMAIL[iii].D5;
                                    UpdateJson.demographicsList[ii].emails[iii].typeCode = "NotAvailable";
                                    UpdateJson.demographicsList[ii].emails[iii].statusCode = "InUse";
                                    UpdateJson.demographicsList[ii].emails[iii].updateDate = Convert.ToDateTime(resultEMAIL[iii].D14);
                                    UpdateJson.demographicsList[ii].emails[iii].updatedBy = "ST";
                                    using (CYBEREntities DB = new CYBEREntities())
                                    {
                                        DB.spInsertAmexBitacora(resultDemo[ii], "EMAIL: " + resultEMAIL[iii].D5 + " " + UpdateJson.demographicsList[ii].emails[iii].statusCode, "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                    }
                                }
                            }
                            UpdateJson.demographicsList[ii].accountNumber = resultDemo[ii];
                            UpdateJson.demographicsList[ii].updateDate = DateTime.Now;
                            UpdateJson.demographicsList[ii].updatedBy = "ST";
                        }

                        if (UpdateJson.accountList !=null)
                        {
                            if (resultCuenta.Count > 0)
                            {
                                for (int ii = 0; ii < UpdateJson.accountList.Count; ii++)
                                {
                                    if (resultCuenta[ii].D6 == "CC")
                                    {
                                        string[] CerradaCUENTA = resultCuenta[ii].D9.ToString().Trim().Split(';');

                                        if (CerradaCUENTA[1].ToString().Trim().Substring(0, 1) == "4" && CerradaCUENTA[1].ToString().Trim().Substring(2, 1) == "2")
                                        {
                                            if (!resultCuenta[ii].D9.ToString().Trim().Contains("CONVENIOS"))
                                            {
                                                IList<spSelectAmexUpdateSEG_Result> resultSeg2 = new List<spSelectAmexUpdateSEG_Result>();
                                                using (CYBEREntities DB = new CYBEREntities())
                                                {
                                                    resultSeg2 = DB.spSelectAmexUpdateSEG(resultCuenta[ii].CUENTA.ToString()).ToList();
                                                }
                                                UpdateJson.accountList[ii].updatedBy = "ST";
                                                UpdateJson.accountList[ii].updateDate = Convert.ToDateTime(resultCuenta[ii].D3);
                                                UpdateJson.accountList[ii].accountNumber = resultCuenta[ii].CUENTA;
                                                UpdateJson.accountList[ii].accountStatus = "4" + resultSeg2[0].AGENCY.Substring(2, 1) + "2";
                                                UpdateJson.accountList[ii].currentAgencyId = resultSeg2[0].AGENCY;
                                                UpdateJson.accountList[ii].lastStatusChangeDate = Convert.ToDateTime(resultCuenta[ii].D3);
                                                UpdateJson.accountList[ii].accountCategoryTypeCode = resultSeg2[0].TYPECODE;
                                                using (CYBEREntities DB = new CYBEREntities())
                                                {
                                                    DB.spInsertAmexBitacora(UpdateJson.accountList[ii].accountNumber, "ESTATUS: " + UpdateJson.accountList[ii].accountStatus, "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        IList<spSelectAmexUpdateSEG_Result> resultSeg = new List<spSelectAmexUpdateSEG_Result>();
                                        using (CYBEREntities DB = new CYBEREntities())
                                        {
                                            resultSeg = DB.spSelectAmexUpdateSEG(resultCuenta[ii].CUENTA.ToString()).ToList();
                                        }
                                        UpdateJson.accountList[ii].updatedBy = "ST";
                                        UpdateJson.accountList[ii].updateDate = Convert.ToDateTime(resultCuenta[ii].D3);
                                        UpdateJson.accountList[ii].accountNumber = resultCuenta[ii].CUENTA;
                                        UpdateJson.accountList[ii].accountStatus = "4" + resultSeg[0].AGENCY.Substring(2, 1) + "7";
                                        UpdateJson.accountList[ii].currentAgencyId = resultSeg[0].AGENCY;
                                        UpdateJson.accountList[ii].lastStatusChangeDate = Convert.ToDateTime(resultCuenta[ii].D3);
                                        UpdateJson.accountList[ii].accountCategoryTypeCode = resultSeg[0].TYPECODE;
                                        using (CYBEREntities DB = new CYBEREntities())
                                        {
                                            DB.spInsertAmexBitacora(UpdateJson.accountList[ii].accountNumber, "ESTATUS: " + UpdateJson.accountList[ii].accountStatus, "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                        }
                                    }

                                }
                            }
                            if (Chk_Retencion.Checked == true)
                            {
                                for (int ii = 0; ii < Cuentas.Count; ii++)
                                {
                                    IList<spSelectAmexUpdateSEG_Result> resultSeg = new List<spSelectAmexUpdateSEG_Result>();
                                    using (CYBEREntities DB = new CYBEREntities())
                                    {
                                        resultSeg = DB.spSelectAmexUpdateSEG(Cuentas[ii].ToString()).ToList();
                                    }
                                    if (resultSeg.Count > 0)
                                    {
                                        UpdateJson.accountList[ii].updatedBy = "ST";
                                        UpdateJson.accountList[ii].updateDate = Convert.ToDateTime(DateTime.Now);
                                        UpdateJson.accountList[ii].accountNumber = Cuentas[ii];                                       
                                        UpdateJson.accountList[ii].accountStatus = "4"+ resultSeg[0].AGENCY.Substring(2, 1) + "6";
                                        UpdateJson.accountList[ii].currentAgencyId = resultSeg[0].AGENCY;
                                        UpdateJson.accountList[ii].lastStatusChangeDate = Convert.ToDateTime(DateTime.Now);
                                        UpdateJson.accountList[ii].accountCategoryTypeCode = resultSeg[0].TYPECODE;
                                        using (CYBEREntities DB = new CYBEREntities())
                                        {
                                            DB.spInsertAmexBitacora(UpdateJson.accountList[ii].accountNumber, "ESTATUS: " + UpdateJson.accountList[ii].accountStatus, "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                        }

                                        using (CYBEREntities DB = new CYBEREntities())
                                        {
                                            DB.spInsertTabAmexRetencion(Cuentas[ii].ToString(),DateTime.Now, sequencia);
                                        }

                                    }
                                    else
                                    {
                                        UpdateJson.accountList.Remove(UpdateJson.accountList[ii]);
                                        Cuentas.RemoveAt(ii);
                                        ii--;
                                        ContadorClases--;
                                        if (UpdateJson.accountList.Count ==0)
                                        {
                                            UpdateJson.accountList =  null;
                                        }
                                    }
                                }

                            }

                        }
                        int contador = 0;
                        if (UpdateJson.treatmentList != null)
                        {
                            for (int ii = 0; ii < UpdateJson.treatmentList.Count; ii++)
                            {
                                while (true)
                                {
                                    if (result[contador].D5=="AH")
                                    {


                                        if (result[contador].D6 == "YA" || result[contador].D6 == "PA")
                                        {
                                            UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                            UpdateJson.treatmentList[ii].treatmentProgram = "PPA";
                                            contador++;
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: PPA", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                            break;
                                        }
                                        if (result[contador].D6 == "RI" /*|| result[contador].D6 == "NA"*/)
                                        {
                                            UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                            UpdateJson.treatmentList[ii].treatmentProgram = "Reinst";
                                            contador++;
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: Reinst", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                            break;
                                        }
                                        if (result[contador].D6 == "YS" /*|| result[contador].D6 == "NS"*/)
                                        {
                                            UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                            UpdateJson.treatmentList[ii].treatmentProgram = "Settlmnt";
                                            UpdateJson.treatmentList[ii].treatmentOffer = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].treatmentAccept = Convert.ToDateTime(result[contador].D3);
                                            contador++;
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: Settlmnt", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                            break;
                                        }
                                        if (result[contador].D6 == "AI" /*|| result[contador].D6 == "NI"*/)
                                        {
                                            UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                            UpdateJson.treatmentList[ii].treatmentProgram = "AC Pgrm";
                                            contador++;
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: AC Pgrm", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                            break;
                                        }
                                        if (result[contador].D6 == "OY" /*|| result[contador].D6 == "OO"*/)
                                        {
                                            UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                            UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                            UpdateJson.treatmentList[ii].treatmentProgram = "OASIS";
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: OASIS", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                            contador++;
                                            break;
                                        }
                                    }
                                    if (result[contador].D5 == "RV")
                                    {
                                        if (result[contador].D6 == "CC")
                                        {
                                            string[] Cerrada = result[contador].D9.ToString().Trim().Split(';');
                                            string inicio = Cerrada[1].ToString().Trim().Substring(0, 1);
                                            string final = Cerrada[1].ToString().Trim().Substring(2, 1);
                                            if (Cerrada[1].ToString().Trim().Substring(0, 1)=="4"&& Cerrada[1].ToString().Trim().Substring(2, 1) == "2")
                                            {
                                                if (!result[contador].D9.ToString().Trim().Contains("CONVENIOS"))
                                                {
                                                    IList<DateTime?> resultSeg = new List<DateTime?>();
                                                    using (CYBEREntities DB = new CYBEREntities())
                                                    {
                                                        resultSeg = DB.spSelectAmexUpdateFECHA(result[contador].CUENTA.ToString()).ToList();
                                                    }
                                                    UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                                    UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                                    UpdateJson.treatmentList[ii].treatmentProgram = "Settlmnt";
                                                    UpdateJson.treatmentList[ii].actualSettlementAmount = Convert.ToDouble(Cerrada[0]);
                                                     UpdateJson.treatmentList[ii].treatmentOffer = resultSeg[0];                                                    
                                                    contador++;
                                                    using (CYBEREntities DB = new CYBEREntities())
                                                    {
                                                        DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: CERRADOS", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                                    }
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (!result[contador].D9.ToString().Trim().Contains("CONVENIOS"))
                                                {
                                                    IList<DateTime?> resultSeg = new List<DateTime?>();
                                                    using (CYBEREntities DB = new CYBEREntities())
                                                    {
                                                        resultSeg = DB.spSelectAmexUpdateFECHA(result[contador].CUENTA.ToString()).ToList();
                                                    }
                                                    UpdateJson.treatmentList[ii].updateDate = Convert.ToDateTime(result[contador].D3);
                                                    UpdateJson.treatmentList[ii].accountNumber = result[contador].CUENTA;
                                                    UpdateJson.treatmentList[ii].treatmentProgram = "Settlmnt";
                                                    UpdateJson.treatmentList[ii].treatmentAccept = Convert.ToDateTime(Cerrada[0]);
                                                    UpdateJson.treatmentList[ii].agreedSettlementAmount = Convert.ToDouble(Cerrada[1]);
                                                    UpdateJson.treatmentList[ii].treatmentExpiration = Convert.ToDateTime(Cerrada[2]);
                                                    UpdateJson.treatmentList[ii].treatmentOffer = resultSeg[0];
                                                    contador++;
                                                    using (CYBEREntities DB = new CYBEREntities())
                                                    {
                                                        DB.spInsertAmexBitacora(UpdateJson.treatmentList[ii].accountNumber, "HERRAMIENTA: CONVENIOS", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }                                  

                                    contador++;
                               
                                }
                            }
                        }


                        contador = 0;
                        if (UpdateJson.visionList != null)
                        {
                            for (int ii = 0; ii < UpdateJson.visionList.Count; ii++)
                            {

                                for (int iii = 0; iii < result.Count; iii++)
                                {
                                    if (CuentasUnicas[ii]== result[iii].CUENTA)
                                    {
                                        if (UpdateJson.visionList[ii].updateDate != null)
                                        {
                                            if (Convert.ToDateTime(result[iii].D3) > UpdateJson.visionList[ii].updateDate)
                                            {
                                                UpdateJson.visionList[ii].updateDate = Convert.ToDateTime(result[iii].D3);
                                                UpdateJson.visionList[ii].updatedBy = "ST";
                                                UpdateJson.visionList[ii].accountNumber = result[iii].CUENTA;
                                                UpdateJson.visionList[ii].rpc = "Y";
                                                UpdateJson.visionList[ii].rpcTypeCode = "P";
                                            }
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.visionList[ii].accountNumber, "RCP", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                        }
                                        else
                                        {
                                            UpdateJson.visionList[ii].updateDate = Convert.ToDateTime(result[iii].D3);
                                            UpdateJson.visionList[ii].updatedBy = "ST";
                                            UpdateJson.visionList[ii].accountNumber = result[iii].CUENTA;
                                            UpdateJson.visionList[ii].rpc = "Y";
                                            UpdateJson.visionList[ii].rpcTypeCode = "P";
                                            using (CYBEREntities DB = new CYBEREntities())
                                            {
                                                DB.spInsertAmexBitacora(UpdateJson.visionList[ii].accountNumber, "RCP", "", DateTime.Now, sequencia.ToString().PadLeft(4, '0') + " UPDATESIB", 1);
                                            }
                                        }
                                    }
                                }                                
                            }
                        }

                        UpdateJson.header.totalRecords = ContadorClases;

                        using (CYBEREntities DB = new CYBEREntities())
                        {
                            DB.spUpdateAmexSecuencia().ToString();
                        }

                    }
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        DateFormatString = "yyyy-MM-ddThh:mm:ss.fffzz00"
                    };
                    string output = JsonConvert.SerializeObject(UpdateJson, settings);
                    NombreJson = Dividido[0] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
                    File.WriteAllText(archivo + "\\" + NombreJson, output);
                    string contents = File.ReadAllText(archivo + "\\" + NombreJson);
                    string Number = "".PadRight(8);
                    string a1 = SHA256_.getHashSha256(contents);
                    string a2 = SHA256_.sha256(contents);
                    string ReportID = "".PadRight(15);
                    ReportID = "ACORNSTUPDIB".PadRight(15);
                    Number = Dividido[7].Substring(2).PadLeft(8, '0');
                    string totalText = ReportID + Number + a2;
                    NombreJson = Dividido[0] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
                    File.WriteAllText(archivo + "\\" + NombreJson, totalText);
                    MessageBox.Show("Archivo Generado", "COMPLETO", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("No hay nada que procesar", "ERROR", MessageBoxButtons.OK);
                }
                DataTable tabla = new DataTable();
                return tabla;
                
            });
        }

        private async void Btn_MT_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            //archivo.Filter = "Archivos JSON (*.json)|*.json"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
            archivo.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            if (archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Txt_Archivo.Text = archivo.FileName;
                pictureBox1.Visible = true;
                await EjecutarAsynJsonTotal();  
                //await EjecutarAsynMT();
                //Dgv_Informacion.DataSource = PRUEBA.DefaultView;
                Dgv_Informacion.Show();
                pictureBox1.Visible = false;
                Lbl_Total.Visible = true;
                Lbl_Total.Text = "Total : " + (Dgv_Informacion.Rows.Count - 1);
                MessageBox.Show("Archivo MT Generado", "COMPLETO", MessageBoxButtons.OK);


            }
           

        }

        public Task<DataTable> EjecutarAsynMT()
        {
            return Task.Run(() =>
            {
                string y = "";
                DataTable x = new DataTable();
                y = Path.GetDirectoryName(Txt_Archivo.Text) + "\\" + Path.GetFileName(Txt_Archivo.Text);
                StreamReader streamReader_ = new StreamReader(y);
                JsonTextReader reader = new JsonTextReader(streamReader_);
                var serializer = new JsonSerializer();
                resultsUpdate = new Ent_Json_Update.RootObject();
                while (reader.Read())
                {
                    resultsUpdate = serializer.Deserialize<Ent_Json_Update.RootObject>(reader);
                }

                ArchivoMTFIinancial archivoMT;
                string archivoSB_ = Path.GetDirectoryName(y);
                string ruta_ = archivoSB_ + "\\MT " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".txt";
                File.WriteAllText(ruta_, "");

                
                if (resultsUpdate.financialTransactionDetailsList != null)
                {
                    IList<string> Unicos = new List<string>();
                    for (int i = 0; i < resultsUpdate.financialTransactionDetailsList.Count; i++)
                    {
                        

                        if (resultsUpdate.financialTransactionDetailsList[i].transactions != null)
                        {
                            for (int ii = 0; ii < resultsUpdate.financialTransactionDetailsList[i].transactions.Count; ii++)
                            {
                                
                                

                                IList<int?> Valor = new List<int?>();
                                using (CYBEREntities DB = new CYBEREntities())
                                {
                                    Valor = DB.spSelectAmexTablaTrans(resultsUpdate.financialTransactionDetailsList[i].transactions[ii].updateDate, Convert.ToDecimal(resultsUpdate.financialTransactionDetailsList[i].transactions[ii].transactionAmount), resultsUpdate.financialTransactionDetailsList[i].transactions[ii].accountNumber).ToList();
                                }
                                if (Valor[0] == 0)
                                {
                                    StringBuilder SB_ = new StringBuilder();
                                    archivoMT = new ArchivoMTFIinancial();
                                    archivoMT = ValidacionArchivoMT_(i, ii, resultsUpdate);
                                    if (resultsUpdate.financialTransactionDetailsList[i].transactions[ii].transactionCode != "99")
                                    {
                                        string cade = Cadena(8, null, null, null, null, null, null, null, archivoMT, null, null);                                       
                                        
                                        if (!Unicos.Contains(cade))
                                        {
                                            Unicos.Add(cade);
                                            SB_.AppendLine(cade);
                                            File.AppendAllText(ruta_, SB_.ToString());
                                        }
                                        
                                    }
                                }

                            }
                        }
                    }
                }
                
                
                return x;
            });
        }

        private void Chk_Carga_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Carga.Checked)
            {
                Chk_MT.Visible = false;
                Chk_JSON.Visible = false;
                Chk_MT.Checked = false;
                Chk_JSON.Checked = false;
                Btn_Archivo.Visible = true;
            }
            else
            {
                Chk_MT.Visible = true;
                Chk_JSON.Visible = true;
                Btn_Archivo.Visible = false;

            }
           
        }

        private void Chk_MT_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_MT.Checked)
            {
                //Chk_Carga.Visible = false;
                Chk_JSON.Visible = false;
                //Chk_Carga.Checked = false;
                Chk_JSON.Checked = false;
                Btn_MT.Visible = true;
            }
            else
            {
                //Chk_Carga.Visible = true;
                Chk_JSON.Visible = true;
                Btn_MT.Visible = false;

            }
        }

        private void Chk_JSON_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_JSON.Checked)
            {
                //Chk_Carga.Visible = false;
                Chk_MT.Visible = false;
                //Chk_Carga.Checked = false;
                Chk_MT.Checked = false;
                Btn_Json.Visible = true;
                Dtp_Fecha.Visible = true;
                Chk_Retencion.Visible = true;
            }
            else
            {
                //Chk_Carga.Visible = true;
                Chk_MT.Visible = true;
                Btn_Json.Visible = false;
                Dtp_Fecha.Visible = false;
                Chk_Retencion.Visible = false;

                Chk_Retencion.Visible = false;
                Chk_Retencion.Checked = false;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (CYBEREntities DB = new CYBEREntities())
            {
               string x =  DB.spUpdateAmexTablaUpdate().ToString();
            }
        }

        private void Frm_Json_Load(object sender, EventArgs e)
        {
            Dtp_Fecha.Value = DateTime.Now.AddDays(-2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sequencia = 5;
            int cuentas = 2;
            string archivo = "C:\\Users\\ABNQJ\\Downloads\\PRUEBA";
            string fecha = DateTime.Now.ToString("MMddyy");
            string NombreJson = "LZ.E2.ACORN.ST.UPDATES.V01." + fecha + "." + sequencia.ToString().PadLeft(4, '0') + "";
            string[] Dividido = NombreJson.Split('.');
            int ContadorClases = 0;

            Ent_Json_Update.RootObject UpdateJson = new Ent_Json_Update.RootObject();

            UpdateJson.header = new Header();



            for (int i = 0; i < cuentas; i++)
            {
                UpdateJson.accountList = new List<AccountList>();
                ContadorClases++;
                UpdateJson.contactInfoList = new List<ContactInfoList>();
                ContadorClases++;
                UpdateJson.deceasedDetailsList = new List<DeceasedDetailsList>();
                ContadorClases++;
                UpdateJson.demographicsList = new List<DemographicsList>();
                ContadorClases++;
                UpdateJson.visionList = new List<VisionList>();
                ContadorClases++;
                UpdateJson.treatmentList = new List<TreatmentList>();
                ContadorClases++;
            }



            for (int i = 0; i < cuentas; i++)
            {

                UpdateJson.accountList.Add(new AccountList());
                UpdateJson.deceasedDetailsList.Add(new DeceasedDetailsList());
                UpdateJson.contactInfoList.Add(new ContactInfoList());
                UpdateJson.demographicsList.Add(new DemographicsList());
               


                UpdateJson.demographicsList[i].phones = new List<Phone>();
                UpdateJson.demographicsList[i].phones.Add(new Phone());
                UpdateJson.demographicsList[i].emails = new List<Emails>();
                UpdateJson.demographicsList[i].emails.Add(new Emails());
                UpdateJson.demographicsList[i].addresses = new List<Address>();
                UpdateJson.demographicsList[i].addresses.Add(new Address());

                UpdateJson.visionList.Add(new VisionList());
                UpdateJson.treatmentList.Add(new TreatmentList());


            }
            for (int i = 0; i < 1; i++)
            {

                DateTime date1 = new DateTime(2018, 8, 29, 19, 27, 15, 18);
                CultureInfo ci = CultureInfo.InvariantCulture;

                string x = date1.ToString("hh:mm:ss.fffzzz", ci);
                string date = "2009-02-25 16:13:00Z"; // Coordinated Universal Time string fromDateTime.Now.ToUniversalTime().ToString("u"); 
                DateTime localDateTime = DateTime.Parse(date);


                UpdateJson.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                UpdateJson.updateBy = "ST";
                UpdateJson.header.updateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);
                UpdateJson.header.senderID = "ST";
                UpdateJson.header.targetID = "AMEX";
                UpdateJson.header.totalRecords = ContadorClases;
                UpdateJson.header.balancingSeqNo = sequencia;

                UpdateJson.accountList[i].accountStatus = "417";
                UpdateJson.accountList[i].accountNumber = "370781926141000";
                UpdateJson.accountList[i].lastStatusChangeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);

                UpdateJson.contactInfoList[i].accountNumber = "370781926141000";
                UpdateJson.contactInfoList[i].lastContactDate = new DateTime(2019, 01, 12, 00, 00, 00, 000, DateTimeKind.Local);


                UpdateJson.deceasedDetailsList[i].accountNumber = "370781926141000";
                UpdateJson.deceasedDetailsList[i].attorneyName = "Ernesto Núñez";
                UpdateJson.deceasedDetailsList[i].attorneyAddress = "calle#5 529";
                UpdateJson.deceasedDetailsList[i].executorCity = "México";
                UpdateJson.deceasedDetailsList[i].executorState = "Tabasco 1";
                UpdateJson.deceasedDetailsList[i].executorZip = "03600";
                UpdateJson.deceasedDetailsList[i].executorPhone = "0445510109590";

                UpdateJson.demographicsList[i].accountNumber = "370781926141000";

                UpdateJson.demographicsList[i].phones[0].number = "12345678";
                UpdateJson.demographicsList[i].phones[0].typeCode = "Business";
                UpdateJson.demographicsList[i].phones[0].statusCode = "InUse";
                UpdateJson.demographicsList[i].phones[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].emails[0].emailAddress = "sertec@yahoo.com.mx";
                UpdateJson.demographicsList[i].emails[0].typeCode = "Home";
                UpdateJson.demographicsList[i].emails[0].statusCode = "InUse";
                UpdateJson.demographicsList[i].emails[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].addresses[0].addressLine1 = "calle Los lagos1";
                UpdateJson.demographicsList[i].addresses[0].addressLine2 = "Colonia Prado1";
                UpdateJson.demographicsList[i].addresses[0].addressLine3 = "Alcaldía Benito Juárez";
                UpdateJson.demographicsList[i].addresses[0].country = "México";
                UpdateJson.demographicsList[i].addresses[0].city = "Ciudad de México";
                UpdateJson.demographicsList[i].addresses[0].zipCode = "11111";
                UpdateJson.demographicsList[i].addresses[0].state = "Ciudad de México2";
                UpdateJson.demographicsList[i].addresses[0].typeCode = "Work";
                //UpdateJson.demographicsList[i].addresses[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[i].returnMailIndicator = "Y";

                UpdateJson.visionList[i].accountNumber = "370781926141000";
                UpdateJson.visionList[i].rpc = "Y";
                UpdateJson.visionList[i].rpcTypeCode = "P";

                UpdateJson.treatmentList[i].accountNumber = "370781926141000";
                UpdateJson.treatmentList[i].treatmentProgram = "Oasis";
                UpdateJson.treatmentList[i].treatmentOffer = new DateTime(2019, 01, 12, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].treatmentAccept = new DateTime(2019, 01, 13, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].treatmentCompletion = new DateTime(2019, 01, 13, 00, 00, 00, 000, DateTimeKind.Local);
                //UpdateJson.treatmentList[i].treatmentExpiration = new DateTime(2018, 10, 19, 00, 00, 00, 000, DateTimeKind.Local);
                //UpdateJson.treatmentList[i].actualSettlementAmount = 1000.00;
                //UpdateJson.treatmentList[i].agreedSettlementAmount = 1000.00;







                UpdateJson.accountList[1].accountStatus = "412";
                UpdateJson.accountList[1].accountNumber = "370781926141000";
                UpdateJson.accountList[1].lastStatusChangeDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTimeKind.Local);

                UpdateJson.contactInfoList[1].accountNumber = "370781926141000";
                UpdateJson.contactInfoList[1].lastContactDate = new DateTime(2018, 12, 29, 00, 00, 00, 000, DateTimeKind.Local);


                UpdateJson.deceasedDetailsList[1].accountNumber = "370781926141000";
                UpdateJson.deceasedDetailsList[1].attorneyName = "Josefina Rodríguez";
                UpdateJson.deceasedDetailsList[1].attorneyAddress = "Segundo retorno 119-3";
                UpdateJson.deceasedDetailsList[1].executorCity = "Guadalajara";
                UpdateJson.deceasedDetailsList[1].executorState = "Tabasco 2";
                UpdateJson.deceasedDetailsList[1].executorZip = "039400";
                UpdateJson.deceasedDetailsList[1].executorPhone = "42255394968";

                UpdateJson.demographicsList[1].accountNumber = "370781926141000";

                UpdateJson.demographicsList[1].phones[0].number = "0445554324900";
                UpdateJson.demographicsList[1].phones[0].typeCode = "Supplementary";
                UpdateJson.demographicsList[1].phones[0].statusCode = "NotInUse";
                UpdateJson.demographicsList[1].phones[0].categoryCode = "Amex";

                UpdateJson.demographicsList[1].emails[0].emailAddress = "sertec_2@hotmail.com";
                UpdateJson.demographicsList[1].emails[0].typeCode = "Business";
                UpdateJson.demographicsList[1].emails[0].statusCode = "NotInUse";
                UpdateJson.demographicsList[1].emails[0].categoryCode = "Amex";

                UpdateJson.demographicsList[1].addresses[0].addressLine1 = "Patriotismo# 555";
                UpdateJson.demographicsList[1].addresses[0].addressLine2 = "Colonia Vertiz Narvarte";
                UpdateJson.demographicsList[1].addresses[0].addressLine3 = "Municipio de Ecatepec";
                UpdateJson.demographicsList[1].addresses[0].country = "México";
                UpdateJson.demographicsList[1].addresses[0].city = "Ciudad de México";
                UpdateJson.demographicsList[1].addresses[0].zipCode = "34560";
                UpdateJson.demographicsList[1].addresses[0].state = "Veracruz34";
                UpdateJson.demographicsList[1].addresses[0].typeCode = "Primary";
                //UpdateJson.demographicsList[1].addresses[0].categoryCode = "OA provided";

                UpdateJson.demographicsList[1].returnMailIndicator = "N";

                UpdateJson.visionList[1].accountNumber = "370781926141000";
                UpdateJson.visionList[1].rpc = "N";
                //UpdateJson.visionList[1].rpcTypeCode = "P";

                UpdateJson.treatmentList[1].accountNumber = "370781926141000";
                UpdateJson.treatmentList[1].treatmentProgram = "Settlement";
                UpdateJson.treatmentList[1].treatmentOffer = new DateTime(2018, 12, 29, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[1].treatmentAccept = new DateTime(2018, 12, 31, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[1].treatmentCompletion = new DateTime(2019, 01, 10, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[1].treatmentExpiration = new DateTime(2019, 02, 19, 00, 00, 00, 000, DateTimeKind.Local);
                UpdateJson.treatmentList[i].actualSettlementAmount = 2800.00;
                UpdateJson.treatmentList[i].agreedSettlementAmount = 2800.00;



            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "yyyy-MM-ddThh:mm:ss.fffzz00"
            };
            //var jsonModel = JsonConvert.DeserializeObject(output, settings);

            string output = JsonConvert.SerializeObject(UpdateJson, settings);


            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);
            NombreJson = Dividido[0] + "." + Dividido[3] + "." + Dividido[2] + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, output);

            string contents = File.ReadAllText(archivo + "\\" + NombreJson);
            string Number = "".PadRight(8);
            string a1 = SHA256_.getHashSha256(contents);
            string a2 = SHA256_.sha256(contents);
            string ReportID = "".PadRight(15);
            ReportID = "ACORNSTUPDIB".PadRight(15);
            Number = Dividido[7].Substring(2).PadLeft(8, '0');
            string totalText = ReportID + Number + a2;
            NombreJson = Dividido[0] + "." + Dividido[1] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);
            NombreJson = Dividido[0] + "." + Dividido[3] + "." + "UNITECH" + "." + "UPDATESIB" + "." + Dividido[5] + "." + Dividido[6] + "." + Dividido[7];
            File.WriteAllText(archivo + "\\" + NombreJson, totalText);
        }

        private void Chk_Retencion_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Retencion.Checked == true)
            {
                lbx_Cuentas.Visible = true;
                Btn_Agregar.Visible = true;
                Btn_Json.Enabled = false;
                Txt_Cuenta.Visible = true;
                Bnt_Uno.Visible = true;
                Bnt_Todos.Visible = true;
               
            }
            else
            {
                lbx_Cuentas.Visible = false;
                Btn_Agregar.Visible = false;
                Btn_Json.Enabled = true;
                Txt_Cuenta.Visible = false;
                lbx_Cuentas.Items.Clear();
                Txt_Cuenta.Text = string.Empty;
                Bnt_Uno.Visible = false;
                Bnt_Todos.Visible = false;
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Txt_Cuenta.Text!=string.Empty)
            {
                lbx_Cuentas.Items.Add(Txt_Cuenta.Text);
                Txt_Cuenta.Text = string.Empty;
                Txt_Cuenta.Focus();
                Btn_Json.Enabled = true;
            }
        }

        private void Txt_Uno_Click(object sender, EventArgs e)
        {
            if (lbx_Cuentas.Items.Count>0)
            {
                lbx_Cuentas.Items.RemoveAt(lbx_Cuentas.Items.Count-1);
                if (lbx_Cuentas.Items.Count == 0)
                {
                    Btn_Json.Enabled = false;
                }
            }
        }

        private void Txt_Todos_Click(object sender, EventArgs e)
        {
            if (lbx_Cuentas.Items.Count > 0)
            {
                lbx_Cuentas.Items.Clear();
                Btn_Json.Enabled = false;
            }
        }

        private void Txt_Cuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (Txt_Cuenta.Text != string.Empty)
                {
                    lbx_Cuentas.Items.Add(Txt_Cuenta.Text);
                    Txt_Cuenta.Text = string.Empty;
                    Txt_Cuenta.Focus();
                    Btn_Json.Enabled = true;
                }
            }
        }
    }
    public class Telefonos
    {
        public string telefono;
        public string fecha;
        public string type;
    }
    public class Update
    {

    }


}
