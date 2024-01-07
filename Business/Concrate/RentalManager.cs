using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;  
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("user,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental request)
        {
            // rental.Id kısmında arabanın Idsini vermiş oluyorum
            RentalDetailDto rent= _rentalDal.GetRentalDetailsById(request.CarId);
            // eğer rent null ise bu araba daha önce kiralanmamıştır. o halde bu araba kiralanabilir
            if(rent != null)
            {
                if(rent.ReturnDate>request.RentDate)
                {
                    return new ErrorResult();
                }
                if (request.ReturnDate <= request.RentDate)
                {
                    return new ErrorResult();
                }
            }
            _rentalDal.Add(request);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<List<RentalDetailDto>> GetAll()
        {
            List<RentalDetailDto> rentals = _rentalDal.GetRentalDetails();
            if(rentals.Count== 0)
            {
               return new ErrorDataResult<List<RentalDetailDto>>(rentals);
            }
            return new SuccessDataResult<List<RentalDetailDto>>();
        }

        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<RentalDetailDto> GetById(int id)
        {
            RentalDetailDto rental = _rentalDal.GetRentalDetailsById(id);
            if(rental == null)
            {
                return new ErrorDataResult<RentalDetailDto>();
            }
            return new SuccessDataResult<RentalDetailDto>(rental);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
