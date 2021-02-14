using Core.Utilities.Results;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDto>> GetRentalDetails();
        IDataResult<List<RentalDto>> GetRentalDetailsByCar( int carId);
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
    }
}
