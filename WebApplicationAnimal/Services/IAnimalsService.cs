using WebApplicationAnimal.Models;

namespace WebApplicationAnimal.Services
{
    public interface IAnimalsService
    {
        IEnumerable<AnimalDTO> GetAnimals(string orderBy);
        int AddAnimal(Animal newAnimal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int id);
    }
}
