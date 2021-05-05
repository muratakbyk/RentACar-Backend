using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
        

    {
        ICarImageDal _carImageDal_;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal_ = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.Datee = DateTime.Now;
            carImage.ImagePath = FileHelper.Add(file);
            _carImageDal_.Add(carImage);
            return new Result(true,Messages.CarImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            carImage = _carImageDal_.Get(p => p.ImageId == carImage.ImageId);
            carImage.ImagePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot") + carImage.ImagePath);
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal_.Delete(carImage);
            return new Result(true, Messages.CarImageDeleted);
          
        }

        public IDataResult<CarImage> Get(int id)
        {

            return new SuccessDataResult<CarImage>(_carImageDal_.Get(p => p.ImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal_.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal_.GetAll(p => p.CarId == CarId));
        }

        public IResult Update(CarImage carImages, IFormFile file)
        {
            carImages = _carImageDal_.Get(p => p.ImageId == carImages.ImageId );
            carImages.Datee = DateTime.Now;
            carImages.ImagePath = FileHelper.Update(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")+carImages.ImagePath), file);
            _carImageDal_.Update(carImages);
            return new Result(true, Messages.CarImagesUpdated);
        }

        private IResult CheckIfCarImagesLimitExceded(int CarId)
        {
            var result =_carImageDal_.GetAll(p=>p.CarId == CarId ).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceded);
            }
            return new SuccessResult();

        }
    }
}
