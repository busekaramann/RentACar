using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;

namespace Business.Concrate
{
    public class BrandManager : IBrandService
        
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        public IResult Add(Brand brand)
        { 
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
