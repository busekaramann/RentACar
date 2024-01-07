using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetAll();
        IDataResult<CarDetailDto> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        int GetCount();
    }
}
