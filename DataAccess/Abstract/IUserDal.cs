using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetById(int id);
        List<UserDetailDto> GetAll();

    }
}
