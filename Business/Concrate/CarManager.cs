using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        public IResult Add(Car car)
        {
            int lenght = car.Description.Length;
            if (lenght < 2) {
                return new ErrorResult();
            }

            if(car.DailyPrice <= 0) {
                return new ErrorResult();
            }
            _carDal.Add(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
 
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetAll()
        {
            List<CarDetailDto> cars = _carDal.GetCarDetails();
            if (cars.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        public IDataResult<CarDetailDto> GetById(int id)
        {
            CarDetailDto car = _carDal.GetCarDetailsById(id); 
            if (car==null)
            {
                return new ErrorDataResult<CarDetailDto>();

            }
            car.IsAvaiable = true;
            // TODO isAvaiable durumu check edilecek.
            return new SuccessDataResult<CarDetailDto> (car);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            List<CarDetailDto> cars = _carDal.GetCarsByBrandId(id);
            if (cars.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CAR_NOT_FOUND);
                
            }
    
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            List<CarDetailDto> car = _carDal.GetCarByColorId(id);
            if (car.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List< CarDetailDto>>(car); 
        }

        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
