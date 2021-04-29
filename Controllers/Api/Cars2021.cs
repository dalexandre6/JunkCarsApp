using JunkCarsApp.Data;
using JunkCarsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JunkCarsApp.Controllers.Api
{
    //Routing convention: api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class Cars2021 : ControllerBase
    {
        private readonly CarsContext _context;
        public Cars2021(CarsContext carsContext)
        {
            _context = carsContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GiveMeAll()
        {
            
            var all = await _context.Car.ToListAsync();
            return all;
        }
        [HttpGet]
        [Route("hola")]//  api/Cars2021/hola
        public async Task<ActionResult<IEnumerable<Car>>> GetOnlyNissan()
        {
            var nissan = from c in  _context.Car.Where(c => c.Make == "Nissan")
                select c;
            return nissan.ToList();

        }

    }
}
