using Business.Abstract;
using Business.Concrate;
using Core.Utilities.Results;
using DataAccess.Concrate.EntityFramework;
using Entities.DTOs;

//InMemoryCarDal _carDal = new InMemoryCarDal();

//Car carToAdded = new Car() { Id = 6, BrandId = 2, ColorId = 1 , ModelYear = 2022, DailyPrice = 579.0, Description = "Yeni Tesla"};

//_carDal.Add(carToAdded);

//List<Car> cars = _carDal.GetAll();

//foreach (var item in cars)
//{
//    Console.WriteLine(item.DailyPrice);
//}


//Car car = _carDal.GetById(2);
//Console.WriteLine(car.DailyPrice);

ICarService carManager = new CarManager(new EfCarDal());


//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.Description);
//    Console.WriteLine(item.BrandName);
//    Console.WriteLine(item.ColorName);
//}
//Console.WriteLine("--------------");

//Console.WriteLine(carManager.GetById(2).BrandName);
