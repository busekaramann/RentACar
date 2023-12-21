using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
             {
                 new Car() {Id = 1, BrandId = 1, ColorId= 1, ModelYear= 2015, DailyPrice= 150.0, Description="Sahibinden Temiz"},
                 new Car() {Id = 2, BrandId = 1, ColorId= 4, ModelYear= 2012, DailyPrice= 550.0, Description="Sahibinden Temiz"},
                 new Car() {Id = 3, BrandId = 5, ColorId= 2, ModelYear= 2017, DailyPrice= 250.0, Description="Sahibinden Temiz"},
                 new Car() {Id = 4, BrandId = 2, ColorId= 1, ModelYear= 2018, DailyPrice= 750.0, Description="Sahibinden Temiz"},
                 new Car() {Id = 5, BrandId = 2, ColorId= 5, ModelYear= 2023, DailyPrice= 1000.0, Description="Sahibinden Temiz"},
             };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int Id)
        {
            Car carToDeleted=_cars.SingleOrDefault(c => c.Id == Id);
            _cars.Remove(carToDeleted);
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public Car GetById(int Id)
        {
            return  _cars.SingleOrDefault(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.DailyPrice= car.DailyPrice;
            carToUpdate.Description= car.Description;
            carToUpdate.ModelYear= car.ModelYear;
            
        }
    }
}
