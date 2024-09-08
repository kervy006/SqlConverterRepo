using ConverterConsoleApp.Constants;
using ConverterConsoleApp.Models;
using ConverterConsoleApp.Validators;
using ConverterConsoleApp.Database;
using SqlConverterLibrary;

namespace ConverterConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName;
            string input;
            string fullFilePath;
            UserInput userInput;

            do
            {
                Console.Write("Enter Filename : ");
                fileName = Console.ReadLine() ?? string.Empty;
                if (!InputValidator.IsValidFileName(fileName))
                {
                    Console.WriteLine("You have entered invalid filename.");
                }
            }
            while (!InputValidator.IsValidFileName(fileName));

            do
            {
                Console.Write("Select file extension (1) XLSX (2) CSV : ");
                input = Console.ReadLine() ?? string.Empty;

                if (!InputValidator.IsValidInput(input))
                {
                    Console.WriteLine("Invalid input. Please select 1 or 2.");
                }
            }
            while (!InputValidator.IsValidInput(input));

            var SqlGetCarData = new SqlGetCarData(new ApplicationDBContext());
            var datatable = SqlGetCarData.GetCarData();

            SqlConverter sc;
            bool result;
            switch (input)
            {
                case "1":
                    userInput = new UserInput(fileName, Constant.XlsxExtension);
                    fullFilePath = userInput.FullFilePath;

                    sc = new SqlToExcelConverter();
                    result = sc.ConvertSql(datatable, fullFilePath);
                    Console.WriteLine(result ? "Sql record has been converted to an Excel File." : "Error converting.");

                    break;
                case "2":
                    userInput = new UserInput(fileName, Constant.TxtExtension);
                    fullFilePath = userInput.FullFilePath;

                    sc = new SqlToTxtConverter();
                    result = sc.ConvertSql(datatable, fullFilePath);
                    Console.WriteLine(result ? "Sql record has been converted to a Text File." : "Error converting.");
                    break;
            }
        }
    }
}