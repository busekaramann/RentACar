using Core.Utilities.Results;
using Entities.Concreate;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
