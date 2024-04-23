using WebApplicationAnimal.Models;

namespace WebApplicationAnimal.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<AnimalDTO> FetchAnimals(string orderBy);
        int AddAnimal (Animal animal);
        int UpdateAnimal(AnimalDTO animal);
        int DeleteAnimal(int id);
    }
}
