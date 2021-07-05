using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;


namespace Business.Concrete
{
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll(re => re.CarId == rental.CarId);

            foreach (var result in results)
            {
                if (result.ReturnDate == null ||
                    (rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) ||
                    (rental.ReturnDate >= result.RentDate && rental.RentDate <= result.ReturnDate))
                {
                    return new ErrorResult(Messages.RentalInvalid);
                }
            }
            _rentalDal.Add(rental);
            return new Result(true, Messages.RentalAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p=>p.Id==id));
        }

        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new Result(true, Messages.RentalUpdated);
        }
    }
}
