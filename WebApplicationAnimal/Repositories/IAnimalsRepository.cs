using WebApplicationAnimal.Models;

namespace WebApplicationAnimal.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> FetchAnimals(string orderBy);
        int AddAnimal (Animal animal);
    }
}
