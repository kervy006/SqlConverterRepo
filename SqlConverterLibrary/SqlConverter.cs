using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverterLibrary
{
    public abstract class SqlConverter
    {
        public static void StartConverting()
        {
            Console.WriteLine("The conversion has started...");
        }
        public abstract bool ConvertSql(DataTable dt, string fullFilePath);
    }
}
