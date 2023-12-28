using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {

                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 ModelYear=c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,

                             };
                             return result.ToList();

            }
        }

        public CarDetailDto GetCarDetailsById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Id=c.Id,
                                 BrandName = b.Name,
                                 ModelYear=c.ModelYear,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,

                             };
                return result.SingleOrDefault();

            }
        }

        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             where c.BrandId == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                             };
                return result.ToList();

            }
            
        }
        public List<CarDetailDto> GetCarByColorId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where c.ColorId == id
                             select new CarDetailDto
                             { 
                                 Id = c.Id,
                                 BrandName= b.Name,
                                 ColorName= cl.Name,
                                 DailyPrice= c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,


                             };
                return result.ToList() ;

            }
        }

    }
}
