using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<RentalDetailDto> GetById(int id);
        IDataResult<List<RentalDetailDto>> GetAll();
    }
}
