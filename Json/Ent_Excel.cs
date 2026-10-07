using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Diagnostics;

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
                ruta = archivo+"\\RPT_UPDATE" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
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

        public void ConvertToExcelFCS(DataTable ds, string Archivo, int Secuencial)
        {
            string ruta;
            string Sec = Secuencial.ToString();
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
                //Do I need to explain this ??? If yes please close my website and learn abc of .net.
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
                ruta = archivo + "\\FCS"+"(" + (DateTime.Now.ToString("dd-MM-yyyy HHmmss")).ToString() + ")-" + Sec+".xlsx";
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

        public DataTable ConvertToDataTable(string FileName)

        {

            DataTable res = null;
            OleDbConnection oledbConn = new OleDbConnection();

            try

            {

                string path = System.IO.Path.GetFullPath(FileName);

                oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");

                oledbConn.Open();

                OleDbCommand cmd = new OleDbCommand(); ;

                OleDbDataAdapter oleda = new OleDbDataAdapter();

                DataSet ds = new DataSet();

                DataTable dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = string.Empty;

                if (dt != null)

                {

                    sheetName = "Sheet1";

                }

                cmd.Connection = oledbConn;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT cm15,RFC,Email FROM [" + sheetName + "$] ";

                oleda = new OleDbDataAdapter(cmd);

                oleda.Fill(ds, "excelData");

                res = ds.Tables["excelData"];

            }

            catch (Exception ex)

            {

            }

            finally

            {

                oledbConn.Close();

            }

            return res;

        }
        public DataTable PruebaRICKY(string FileName)
        {
            DataTable dtResult = null;
            int totalSheet = 0; //No of sheets on excel file  
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");
                dtResult = ds.Tables["excelData"];
                objConn.Close();
                return dtResult; //Returning Dattable  
            }
        }
        public System.Data.DataTable ConvertToDataTableExcel(string path)

        {

            System.Data.DataTable dt = null;

            try

            {

                object rowIndex = 1;

                dt = new System.Data.DataTable();

                DataRow row;

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,

                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

                int temp = 1;

                while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {

                    dt.Columns.Add(Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2));

                    temp++;

                }

                rowIndex = Convert.ToInt32(rowIndex) + 1;

                int columnCount = temp;

                temp = 1;

                while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {

                    row = dt.NewRow();

                    for (int i = 1; i < columnCount; i++)

                    {

                        row[i - 1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, i]).Value2);

                    }

                    dt.Rows.Add(row);

                    rowIndex = Convert.ToInt32(rowIndex) + 1;

                    temp = 1;

                }

                app.Workbooks.Close();

            }

            catch (Exception ex)

            {

                //lblError.Text = ex.Message;

            }

            return dt;

        }
        public  bool CreateExcelDocument<T>(List<T> list, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(ListToDataTable(list));

            return CreateExcelDocument(ds, xlsxFilePath);
        }

        //  This function is adapated from: http://www.codeguru.com/forum/showthread.php?t=450171
        //  My thanks to Carl Quirion, for making it "nullable-friendly".
        public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, GetNullableType(info.PropertyType)));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    if (!IsNullableType(info.PropertyType))
                        row[info.Name] = info.GetValue(t, null);
                    else
                        row[info.Name] = (info.GetValue(t, null) ?? DBNull.Value);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        private static Type GetNullableType(Type t)
        {
            Type returnType = t;
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                returnType = Nullable.GetUnderlyingType(t);
            }
            return returnType;
        }
        private static bool IsNullableType(Type type)
        {
            return (type == typeof(string) ||
                    type.IsArray ||
                    (type.IsGenericType &&
                     type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
        }

        public  bool CreateExcelDocument(DataTable dt, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            return CreateExcelDocument(ds, xlsxFilePath);
        }

        public  bool CreateExcelDocument(DataSet ds, string excelFilename)
        {
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(excelFilename, SpreadsheetDocumentType.Workbook))
                {
                    document.AddWorkbookPart();
                    document.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    //  My thanks to James Miera for the following line of code (which prevents crashes in Excel 2010)
                    document.WorkbookPart.Workbook.Append(new BookViews(new WorkbookView()));

                    //  If we don't add a "WorkbookStylesPart", OLEDB will refuse to connect to this .xlsx file !
                    WorkbookStylesPart workbookStylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>("rIdStyles");
                    Stylesheet stylesheet = new Stylesheet();
                    workbookStylesPart.Stylesheet = stylesheet;

                    CreateParts(ds, document);
                }
                Trace.WriteLine("Successfully created: " + excelFilename);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed, exception thrown: " + ex.Message);
                return false;
            }
        }

        private static void CreateParts(DataSet ds, SpreadsheetDocument spreadsheet)
        {
            //  Loop through each of the DataTables in our DataSet, and create a new Excel Worksheet for each.
            uint worksheetNumber = 1;
            foreach (DataTable dt in ds.Tables)
            {
                //  For each worksheet you want to create
                string workSheetID = "rId" + worksheetNumber.ToString();
                string worksheetName = dt.TableName;

                WorksheetPart newWorksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                newWorksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet();

                // create sheet data
                newWorksheetPart.Worksheet.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.SheetData());

                // save worksheet
                WriteDataTableToExcelWorksheet(dt, newWorksheetPart);
                newWorksheetPart.Worksheet.Save();

                // create the worksheet to workbook relation
                if (worksheetNumber == 1)
                    spreadsheet.WorkbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());

                spreadsheet.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheet()
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(newWorksheetPart),
                    SheetId = (uint)worksheetNumber,
                    Name = dt.TableName
                });

                worksheetNumber++;
            }

            spreadsheet.WorkbookPart.Workbook.Save();
        }


        private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart)
        {
            var worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();

            string cellValue = "";

            //  Create a Header Row in our Excel file, containing one header for each Column of data in our DataTable.
            //
            //  We'll also create an array, showing which type each column of data is (Text or Numeric), so when we come to write the actual
            //  cells of data, we'll know if to write Text values or Numeric cell values.
            int numberOfColumns = dt.Columns.Count;
            bool[] IsNumericColumn = new bool[numberOfColumns];

            string[] excelColumnNames = new string[numberOfColumns];
            for (int n = 0; n < numberOfColumns; n++)
                excelColumnNames[n] = GetExcelColumnName(n);

            //
            //  Create the Header row in our Excel Worksheet
            //
            uint rowIndex = 1;

            var headerRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
            sheetData.Append(headerRow);

            for (int colInx = 0; colInx < numberOfColumns; colInx++)
            {
                DataColumn col = dt.Columns[colInx];
                AppendTextCell(excelColumnNames[colInx] + "1", col.ColumnName, headerRow);
                IsNumericColumn[colInx] = (col.DataType.FullName == "System.Decimal") || (col.DataType.FullName == "System.Int32");
            }

            //
            //  Now, step through each row of data in our DataTable...
            //
            double cellNumericValue = 0;
            foreach (DataRow dr in dt.Rows)
            {
                // ...create a new row, and append a set of this row's data to it.
                ++rowIndex;
                var newExcelRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
                sheetData.Append(newExcelRow);

                for (int colInx = 0; colInx < numberOfColumns; colInx++)
                {
                    cellValue = dr.ItemArray[colInx].ToString();

                    // Create cell with data
                    if (IsNumericColumn[colInx])
                    {
                        //  For numeric cells, make sure our input data IS a number, then write it out to the Excel file.
                        //  If this numeric value is NULL, then don't write anything to the Excel file.
                        cellNumericValue = 0;
                        if (double.TryParse(cellValue, out cellNumericValue))
                        {
                            cellValue = cellNumericValue.ToString();
                            AppendNumericCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                        }
                    }
                    else
                    {
                        //  For text cells, just write the input data straight out to the Excel file.
                        AppendTextCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                    }
                }
            }
        }

        private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference, DataType = CellValues.String };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }

        private static void AppendNumericCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }

        private static string GetExcelColumnName(int columnIndex)
        {
            //  Convert a zero-based column index into an Excel column reference  (A, B, C.. Y, Y, AA, AB, AC... AY, AZ, B1, B2..)
            //
            //  eg  GetExcelColumnName(0) should return "A"
            //      GetExcelColumnName(1) should return "B"
            //      GetExcelColumnName(25) should return "Z"
            //      GetExcelColumnName(26) should return "AA"
            //      GetExcelColumnName(27) should return "AB"
            //      ..etc..
            //
            if (columnIndex < 26)
                return ((char)('A' + columnIndex)).ToString();

            char firstChar = (char)('A' + (columnIndex / 26) - 1);
            char secondChar = (char)('A' + (columnIndex % 26));

            return string.Format("{0}{1}", firstChar, secondChar);
        }

    }

}
