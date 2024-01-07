using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<UserDetailDto> GetById(int id);
        IDataResult<List<UserDetailDto>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

    }
}
