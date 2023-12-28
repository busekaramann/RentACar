using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarDetailDto GetCarDetailsById(int id);
        List<CarDetailDto> GetCarDetails();

        List<CarDetailDto> GetCarsByBrandId(int id);
        List<CarDetailDto>GetCarByColorId(int id);

    }
}
