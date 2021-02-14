using Business.Abstract;
using Entitites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getallcars")]
        public IActionResult GetAllCars()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result); //Statu 200 Ok datanın kendisi doner
            }
            return BadRequest(result);//Statu 400 Bad request döner
        }
        [HttpGet("getavailablecars")]
        public IActionResult GetAvailableCars()
        {
            //postman de https://localhost:44361/api/cars/getavailablecars şeklinde GET yapılır.
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addcar")]
        public IActionResult AddCar(Car car)
        {

            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
