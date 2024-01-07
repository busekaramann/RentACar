using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserOperationClaimDal: EfEntityRepositoryBase<UserOperationClaim, RentACarContext>, IUserOperationClaimDal
    {
    }
}
