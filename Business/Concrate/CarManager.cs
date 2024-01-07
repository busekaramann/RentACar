using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();
            if(result != null)
            {
                return result;
            
            }
            _carDal.Add(car);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;

            }

            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAll()
        {
            List<CarDetailDto> cars = _carDal.GetCarDetails();


            IResult result = BusinessRules.Run(CheckCarCount(cars.Count));


            if (result != null)
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

        public int GetCount()
        {
            return _carDal.Count();
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;

            }

            _carDal.Update(car);
            return new SuccessResult();
        }
        private IResult CheckCarCount(int count) 
        { 
            if (count == 0)
            {
                return new ErrorResult();
            
            }
            return new SuccessResult();
        
        }

    }
}
