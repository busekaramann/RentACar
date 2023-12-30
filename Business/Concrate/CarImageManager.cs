using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;
        public CarImageManager( ICarImageDal carImageDal , IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            
        }
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            if (!CheckCarImageCount(carImage.CarId).Success)
            {
                return new ErrorResult();
            }
            var imageResult = _fileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            List<CarImage> carImages = _carImageDal.GetAll();
            if(carImages.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>> (new List<CarImage>() { 
                    new CarImage() { ImagePath= "/images/default.png" } 
                });
            }
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            List<CarImage> carImages = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (carImages.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>() {
                    new CarImage() { ImagePath= "/images/default.png" }
                });
            }
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount (int carId )
        {
            int count = _carImageDal.Count(c => c.CarId==carId);
            if(count >=5)
            { 
                return new ErrorResult();
            
            }return new SuccessResult();

          
        }
    }
}
