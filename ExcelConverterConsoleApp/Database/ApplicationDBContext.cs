using Microsoft.EntityFrameworkCore;
using ConverterConsoleApp.Models;
using ConverterConsoleApp.Constants;

namespace ConverterConsoleApp.Database
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configService = new DbConfig(Constant.jsonFilePath);
            var connectionStrings = configService.GetConnectionStrings();
            string connectionString = connectionStrings.DefaultConnection;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
