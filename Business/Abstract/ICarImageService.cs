using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetByCarId(int carId);

    }
}
