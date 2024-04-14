namespace WebApplication1
{
    public interface IAnimalsService
    {
        public IEnumerable<AnimalDTO>  GetAnimal(string id);
    }
}
