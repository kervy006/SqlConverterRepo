using ConverterConsoleApp.Constants;

namespace ConverterConsoleApp.Models
{
    public class UserInput
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string FullFilePath { get; set; }
        public UserInput(string fileName, string extension) 
        { 
            this.FileName = fileName;
            this.Extension = extension;
            this.FullFilePath = GenerateFullFilePath(fileName,extension);
        }
        private static string GenerateFullFilePath(string fileName, string extension)
        {
            return Path.Combine(Constant.FilePath,$"{fileName}.{extension}");
        }
    }
}
