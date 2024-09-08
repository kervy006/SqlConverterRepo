using ConverterConsoleApp.Models;
using System.Text.Json;

namespace ConverterConsoleApp.Database
{
    internal class DbConfig
    {
        private readonly string _filePath;
        private ConnectionStrings _connectionStrings;

        public DbConfig(string filePath)
        {
            _filePath = filePath;
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            string x = _filePath;
            string jsonString = File.ReadAllText(_filePath);
            using var jsonDoc = JsonDocument.Parse(jsonString);
            _connectionStrings = jsonDoc.RootElement.GetProperty("ConnectionStrings").Deserialize<ConnectionStrings>();
        }
        public ConnectionStrings GetConnectionStrings()
        {
            return _connectionStrings;
        }
    }
}
