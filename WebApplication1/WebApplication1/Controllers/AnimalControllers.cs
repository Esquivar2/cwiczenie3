namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalControllers : ControllerBase
    {
        private IAnimalsService _animalService;
        
        public AnimalControllers(IAnimalService animalService) {
            _animalService = animalService;
        }  
            
    }
}
