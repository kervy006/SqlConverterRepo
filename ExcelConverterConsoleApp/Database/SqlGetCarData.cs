using ConverterConsoleApp.Models;
using System.Data;
using System.Reflection;

namespace ConverterConsoleApp.Database
{
    internal class SqlGetCarData
    {
        private readonly ApplicationDBContext _context;

        public SqlGetCarData(ApplicationDBContext context)
        {
            _context = context;
        }
        public DataTable GetCarData()
        {
            var dt = new DataTable();
            try
            {
                //var cars = _context.Cars.Where(Car => Car.CarId == 1).ToList();
                //_context.Cars.Remove(new Car { CarId = 1 });
                //_context.Cars.Add(new Car { CarModel = "s" });
                //var dataRecordUpdate = _context.Cars.Find(1);
                //if (dataRecordUpdate != null)
                //{
                //    dataRecordUpdate.CarModel = "Honda 2024";
                //    _context.Cars.Update(dataRecordUpdate);
                //} 
                //_context.SaveChanges();

                var cars = from Car in _context.Cars
                           where Car.CarId <= 4
                           select Car;

                var carList = cars.ToList();

                Type type = typeof(Car);
                PropertyInfo[] properties = type.GetProperties();

                foreach (var p in properties)
                {
                    dt.Columns.Add(p.Name);
                }

                foreach (var car in carList)
                {
                    dt.Rows.Add(car.CarId, car.CarModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured : {ex.Message}");
            }
            return dt;
        }
    }
}
