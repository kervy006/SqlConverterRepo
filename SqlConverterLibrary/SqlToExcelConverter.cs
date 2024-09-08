using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
namespace SqlConverterLibrary
{
    public class SqlToExcelConverter : SqlConverter
    {
        public override bool ConvertSql(DataTable dt,string fullFilePath)
        {
            StartConverting();
            bool isConversionSuccessful = false;
            try
            {
                var excelApp = new Excel.Application();
                var workBook = excelApp.Workbooks.Add();
                var workSheet = workBook.Worksheets[1];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }

                for (int i = 0;i < dt.Rows.Count; i++)
                {
                    for (int j = 0;j < dt.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }

                workBook.SaveAs(fullFilePath);
                workBook.Close();
                excelApp.Quit();

                isConversionSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isConversionSuccessful;
        }

    }
}
