using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             select new RentalDetailDto
                             {

                                 Id = r.Id,
                                 CarId = c.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }



        }


        public RentalDetailDto GetRentalDetailsById(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                //Rent sorgusu atarken car id verdim 
                var result = from r in context.Rentals
                             join c in context.Cars on
                             r.CarId equals c.Id
                             where r.CarId == carId
                             select new RentalDetailDto
                             {

                                 Id = r.Id,
                                 CarId = c.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList().OrderByDescending(c => c.ReturnDate).First();


            }

        }
    }
}


