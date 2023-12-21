using DataAccess.Concrate.InMemory;
using Entities.Concreate;

InMemoryCarDal _carDal = new InMemoryCarDal();

Car carToAdded = new Car() { Id = 6, BrandId = 2, ColorId = 1 , ModelYear = 2022, DailyPrice = 579.0, Description = "Yeni Tesla"};

_carDal.Add(carToAdded);

List<Car> cars = _carDal.GetAll();

foreach (var item in cars)
{
    Console.WriteLine(item.DailyPrice);
}


Car car = _carDal.GetById(2);
Console.WriteLine(car.DailyPrice);

