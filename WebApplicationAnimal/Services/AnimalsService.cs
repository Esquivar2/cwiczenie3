using System.Xml.Linq;
using WebApplicationAnimal.Models;
using WebApplicationAnimal.Repositories;

namespace WebApplicationAnimal.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsService(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        public IEnumerable<AnimalDTO> GetAnimals(string orderBy)
        {
            var animals = _animalsRepository.FetchAnimals(orderBy);

            return animals;
        }

        public int AddAnimal(Animal newAnimal)
        {
            return _animalsRepository.AddAnimal(newAnimal);
        }

        public int UpdateAnimal(int id, Animal animal) 
        {
            var animalDTO = new AnimalDTO
            {
                Id = id,
                Name = animal.Name,
                Description = animal.Description,
                Category = animal.Category,
                Area = animal.Area,
            };
            return _animalsRepository.UpdateAnimal(animalDTO);
        }

        public int DeleteAnimal(int id)
        {
            return _animalsRepository.DeleteAnimal(id); 
        }
    }
}
