using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Excel
    {
        
        public void ConvertToExcel(DataTable ds, string Archivo)

        {
            string ruta;
            //Instance reference for Excel Application
            Microsoft.Office.Interop.Excel.Application objXL = null;
            //Workbook refrence
            Microsoft.Office.Interop.Excel.Workbook objWB = null;
            try
            {
                //Instancing Excel using COM services
                objXL = new Microsoft.Office.Interop.Excel.Application();
                //Adding WorkBook
                objWB = objXL.Workbooks.Add(1);
                //Variable to keep sheet count
                int sheetcount = 1;
                //Do I need to explain this ??? If yes please close my website and learn abc of .net .
                
                    //Adding sheet to workbook for each datatable
                    Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)objWB.Sheets.Add();
                    //Naming sheet as SheetData1.SheetData2 etc....
                    objSHT.Name = "SheetData" + sheetcount.ToString();
                    for (int j = 0; j < ds.Rows.Count; j++)
                    {
                        for (int i = 0; i < ds.Columns.Count; i++)
                        {
                            //Condition to put column names in 1st row
                            //Excel work book indexes start from 1,1 and not 0,0
                            if (j == 0)
                            {
                                objSHT.Cells[1, i + 1] = ds.Columns[i].ColumnName.ToString();
                            }
                        //Writing down data
                        objSHT.Cells[j + 2, i + 1].EntireColumn.NumberFormat = "@";
                        objSHT.Cells[j + 2, i + 1] = ds.Rows[j][i].ToString();
                        }
                    }
                    //Incrementing sheet count
                    sheetcount++;
               
                //Saving the work book
                objWB.Saved = true;
                string pathes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string archivo = Archivo;
                ruta = archivo+"\\Saldos" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
                objWB.SaveCopyAs(ruta);
                //Closing work book
                objWB.Close();
                //Closing excel application
                objXL.Quit();
            }
            catch (System.Exception ex)
            {
                objWB.Saved = true;
                //Closing work book
                objWB.Close();
                //Closing excel application
                objXL.Quit();
            }

        }
    }

}
