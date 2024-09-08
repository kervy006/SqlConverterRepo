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
            
            do
            {
                Console.Write("Enter Filename : ");
                fileName = Console.ReadLine() ?? string.Empty;
                if (!InputValidator.IsValidFileName(fileName.Trim()))
                {
                    Console.WriteLine("You have entered invalid filename.");
                }
            }
            while (!InputValidator.IsValidFileName(fileName));

            do
            {
                Console.Write("Convert file to (1) EXCEL (2) TEXT : ");
                input = Console.ReadLine() ?? string.Empty;

                if (!InputValidator.IsValidInput(input))
                {
                    Console.WriteLine("Invalid input. Please select 1 or 2.");
                }
            }
            while (!InputValidator.IsValidInput(input));

            var sqlGetCarData = new SqlGetCarData(new ApplicationDBContext());
            var datatable = sqlGetCarData.GetCarData();

            SqlConverter sc;
            bool isConversionSuccesful;
            UserInput userInput;
            string fullFilePath;

            switch (input)
            {
                case "1":
                    userInput = new UserInput(fileName, Constant.XlsxExtension);
                    fullFilePath = userInput.FullFilePath;

                    sc = new SqlToExcelConverter();
                    isConversionSuccesful = sc.ConvertSql(datatable, fullFilePath);
                    Console.WriteLine(isConversionSuccesful ? "Sql record has been converted to an Excel File." : "Error converting.");

                    break;
                case "2":
                    userInput = new UserInput(fileName, Constant.TxtExtension);
                    fullFilePath = userInput.FullFilePath;

                    sc = new SqlToTxtConverter();
                    isConversionSuccesful = sc.ConvertSql(datatable, fullFilePath);
                    Console.WriteLine(isConversionSuccesful ? "Sql record has been converted to a Text File." : "Error converting.");
                    break;
            }
        }
    }
}