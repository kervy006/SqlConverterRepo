using System.Data;
using System.Text;
namespace SqlConverterLibrary
{
    public class SqlToTxtConverter : SqlConverter
    {
        
        public override bool ConvertSql(DataTable dt, string fullFilePath)
        {
            StartConverting();
            bool isConversionSuccessful = false;
            try
            {
                var result = new StringBuilder();

                for (int i =  0; i < dt.Columns.Count; i++)
                {
                    result.Append(dt.Columns[i].ColumnName);
                    if(i < dt.Columns.Count -1) result.Append(",");
                }
                result.AppendLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        result.Append(row[i].ToString());
                        if (i < dt.Columns.Count - 1) result.Append(",");
                    }
                    result.AppendLine();
                }

                File.WriteAllText(fullFilePath, result.ToString());

                isConversionSuccessful = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return isConversionSuccessful;
        }
    }
}
