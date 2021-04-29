using JunkCarsApp.Models;
using Microsoft.AspNetCore.Hosting;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace JunkCarsApp.Services
{



    //The service will tell me HOW TO RETRIVE THIS DATA:
    public class JsonFileProductService
    {
        // I wil create a constructor for this service and inject the IwebHostEnvironment
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        //Create the property to reference the WebHost...
        public IWebHostEnvironment WebHostEnvironment { get; }
        //Add System IO for adding the Path.Combine.....This will go automatically to the 
        //directory and locate this file.
        private string JsonFileName 
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath,
               "Data", "CarsContext.cs");
                //  return path.combine(WebHostEnvironment.WebRootPath,
                //"data", "products.json");
            }
        }
        //Now that we retrieve the Json file (from the API???) 
        //We have to convert that text (returned from API)
        //We are retriveing the products and convert that text to the actual product.
        //Json to Object --> Desirialize:

        public IEnumerable<Car> GetCars()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            }

        }

    }
}
