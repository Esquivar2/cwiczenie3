using WebApplicationAnimal.Models;

namespace WebApplicationAnimal.Services
{
    public interface IAnimalsService
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        int AddAnimal(Animal newAnimal);
    }
}
