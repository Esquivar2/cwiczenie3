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

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            var animals = _animalsRepository.FetchAnimals(orderBy);

            return animals;
        }

        public int AddAnimal(Animal newAnimal)
        {
            return _animalsRepository.AddAnimal(newAnimal);
        }


    }
}
