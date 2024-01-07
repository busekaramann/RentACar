using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Color color)
        {
           _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
