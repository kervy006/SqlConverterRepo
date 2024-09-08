using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterConsoleApp.Validators
{
    internal class InputValidator
    {
        public static bool IsValidFileName(string fileName)
        {
            return !string.IsNullOrEmpty(fileName);
        }
        public static bool IsValidInput(string input)
        {
            if (input == "1" || input == "2")
            {
                return true;
            }
            else 
                return false;
        }
    }
}
