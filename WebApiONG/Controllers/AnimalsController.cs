using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiONG.Models;
using WebApiONG.Services;

namespace WebApiONG.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalsServices _animalservices;
        private readonly PersonServices _personService;
        private readonly AddressServices _addressService;


        public AnimalsController(AnimalsServices animalservices, PersonServices personService, AddressServices addressService)
        {
            _animalservices = animalservices;
            _personService = personService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Animals>> Get() => _animalservices.Get();

        [HttpGet("ID",Name = "GetAnimals")]
        public ActionResult<Person> Get(string id)
        {
            var client = _animalservices.Get(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Animals> Creat(Animals animal)
        {
            Person person = _personService.Create(animal.Person);
            animal.Person = person;

            Address add = _addressService.Create(animal.Person.Address);
            animal.Person.Address = add;

            _animalservices.Create(animal);
            return CreatedAtRoute("GetPeron", new { id = animal.Id.ToString() }, animal);
        }

     

        [HttpPut]
        public ActionResult<Person> Update(string id, Animals animalIn)
        {
            var animal = _animalservices.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            _animalservices.Update(id, animalIn);

            animal = _animalservices.Get(id);

            return NoContent();
        }


        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var animal = _animalservices.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            _animalservices.Remove(animal);

            return NoContent();
        }
    }
}
