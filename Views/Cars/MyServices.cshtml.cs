using JunkCarsApp.Models;
using JunkCarsApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JunkCarsApp.Views.Cars
{
    public class MyServices : PageModel
    {

        private readonly ILogger<MyServices> _logger;
        public JsonFileProductService ProductService; //you need this declaration dm3
        public IEnumerable<Car> Cars { get; private set; }

        //You dont make a logger , you ask for one (dM3): YOu list it into the arguments
        //I wanna be able to Log this to a file 
        // You can list more services ( like the JosnFileProductSerrvice below or more:
        public MyServices(ILogger<MyServices> logger,
            JsonFileProductService productService)

        {
            _logger = logger;
            ProductService = productService;//NEEDS TO BE SET FOR THE ONE ON BELOW:
        }

        public void OnGet()
        {
            Cars = ProductService.GetCars();
        }

    }
}
