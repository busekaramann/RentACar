using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }


        public IDataResult<List<UserDetailDto>> GetAll()
        {
           List<UserDetailDto> user= _userDal.GetAll();
            if (user.Count == 0)
            {
                return new ErrorDataResult<List<UserDetailDto>>();
            }
            return new SuccessDataResult<List<UserDetailDto>>(user);

        }

        public IDataResult<UserDetailDto> GetById(int id)
        {
            UserDetailDto user = _userDal.GetById(id);
            if (user == null)
            {
                return new ErrorDataResult<UserDetailDto>();
            }
            return new SuccessDataResult<UserDetailDto>(user);
            
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
