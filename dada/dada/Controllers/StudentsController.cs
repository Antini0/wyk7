namespace DefaultNamespace;

public class StudentsController
{
        
        
        private static readonly List<Animal> _animals = new List<Animal>
        {
            new Animal { IdAnimal = 1, name = "burek", category = "dog", description = "asd", area = "12" },
            new Animal { IdAnimal = 2, name = "azor", category = "dog", description = "zdg", area = "13" },
            new Animal { IdAnimal = 3, name = "bulek", category = "cat", description = "fh", area = "14" }
        };
        
        [HttpGet]
        public IActionResult GetAnimals() //interfejs moze oznaczac roznego rodzaju zwracane dane z naszego api
        {
            return Ok(_animals); //opakowuje zwracane dane w kod http
        }
    
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id) 
        {
            var animal = _animals.FirstOrDefault((a => a.IdAnimal == id));

            if (animal == null)
            {
                return NotFound(("asd"));
            }
            
            return Ok(animal);
        }
    
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            return StatusCode(StatusCodes.Status201Created);
        }
    
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal) 
        {
            var animalToEdit = _animals.FirstOrDefault((a => a.IdAnimal == id));

            if (animalToEdit == null)
            {
                return NotFound($"animal with id was not found");
            }
        
            _animals.Remove(animalToEdit);
            _animals.Add(animal);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id) 
        {
            var animalToDelete = _animals.FirstOrDefault((a => a.IdAnimal == id));

            if (animalToDelete == null)
            {
                return NotFound($"animal with id was not found");
            }
        
            _animals.Remove(animalToDelete);
            return NoContent();
        }
}