using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Http;
using JunkCarsApp.Data;
using JunkCarsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JunkCarsApp.Controllers.Api
{


    [Route("api/[controller]")]
    [ApiController]
    // [Route("api/[controller]")]

    public class AllCarsController : ControllerBase
    {
        private readonly CarsContext _context;
        //Constuctor to initialize context:
        public AllCarsController(CarsContext context)
        {
            _context = context;
        }

        //GET ---> API/CONTROLLER/ACTIONRESULT(IENUMERABLE):  
        //GET:  api/AllCars
        //[HttpGet("api/[controller]/[action]")]


        [HttpGet] // api/allcars
                  // [Route("hola")] //This will add to the route set up already on top of the class:   api/controller/hola 
        public async Task<ActionResult<IEnumerable<Car>>> GetCarss()
        {
            // return _context.Car();
            return await _context.Car.ToListAsync();
        }




        // [HttpGet]//      api/allcars  
        // public async Task<ActionResult<Car>> GetCars10()
        //// public IActionResult GetCars10() //This method should be plural since we may call only one entry on the api/allcars/id:(check next method)
        // {
        //     //var all = _context.Car.Where(x => x.Price > 100).ToList();
        //     //return Ok(all);

        //         //create a variable 
        //         var all = await _context.Car.ToListAsync().ConfigureAwait(false);


        //         return Ok(all);  //Return the var --> in this case the id

        // }
        //[HttpGet("api/[controller]/[action]")] //api/allcars -->this method calls all the cars:
        //[HttpGet("api/[controller]/[action]")]

        //USE THISONE:
        //[HttpGet]
        //public IEnumerable<Car> GetCars() //This method should be plural since we may call only one entry on the api/allcars/id:(check next method)
        //{
        //    return _context.Car.ToList();
        //}

        // GET: Cars


        //Make sure you type CarId instead of Id. This should match your model's name:
        //    api/allcars/1 -> This will call one entry (by id):
        //Thisone is not IEnumerable since it's only one value (not a collection of values):
        [HttpGet("{carId}")]
        public async Task<ActionResult<Car>> GetCar(int carId)
        {
            //create a variable 
            var car = await _context.Car.FindAsync(carId);

            if (car == null)
            {
                return NotFound(); //if CarId is not found the return NorFound error(404)
            }

            return car;  //Return the var --> in this case the id
        }

        [HttpPost] // api/AllCarsController/CreateCar
        public Car CreateCar(Car car) //You create a resource, so just apply the Add and Save Methods
                                      //Car  is the model and car is made up to return something (we are not passing an id like in the 
                                      //GET(Id) API. We generate a new resource here.
        {
            //if (!ModelState.IsValid)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest); 
            _context.Car.Add(car); //first you add it the you save it
            _context.SaveChanges();//Needs to be saved cuz it's a new record(post) that will stay in the db
            return car;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            //var car = await _context.Car.FirstOrDefaultAsync(m => m.CarId == id);
            var car = await _context.Car.FindAsync(id);  // 1. Look for the value 
            if (car == null)             
            {
                return NotFound();
            }
            _context.Car.Remove(car);      //   2.   Remove the value
            await _context.SaveChangesAsync(); //3. Save Changes Async

            return RedirectToAction("Index"); // OR -->return NoContent();

        }
        //  api/allcars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if(id != car.CarId)
            {
                return BadRequest();
            }
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
            
        }





    }
}