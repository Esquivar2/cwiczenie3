using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAnimal.Models;
using WebApplicationAnimal.Services;

namespace WebApplicationAnimal.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsService _animalService;

        public AnimalsController(IAnimalsService animalService)
        {
            _animalService = animalService;
        }


        [HttpGet]
        public IActionResult GetAnimals(string orderBy = "name")
        {
            var validValues = new[] { "name", "description", "category", "area" };
            if(!validValues.Contains(orderBy))
            {
                return BadRequest("Invalid orderBy parameter. Available values: name, description, category, area.");
            }


            var animals = _animalService.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddAnimal(Animal newAnimal)
        {
            var affectedCount = _animalService.AddAnimal(newAnimal);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{idAnimal:int}")]
        [Consumes("application/json")]
        public IActionResult UpdateAnimal(int idAnimal, Animal animal)
        {
            var affectedCount = _animalService.UpdateAnimal(idAnimal, animal);
            return NoContent();
        }
        
        [HttpDelete("{idAnimal:int}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            var affectedCount = _animalService.DeleteAnimal(idAnimal);
            return NoContent();
        }
    }
}
