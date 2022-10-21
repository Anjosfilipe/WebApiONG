using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiONG.Models;
using WebApiONG.Services;

namespace WebApiONG.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AddressServices _addressService;
        private readonly PersonServices _personService;

        public PersonController(PersonServices personServices, AddressServices addressServices)
        {
            _addressService = addressServices;
            _personService = personServices;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get() => _personService.Get();

        [HttpGet("Name",Name = "GetPerson")]
        public ActionResult<Person> Get(string id)
        {
            var client = _personService.Get(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client); 
        }

        [HttpPost]
        public ActionResult<Person> Creat(Person person)
        {
            Address address = _addressService.Create(person.Address);
            person.Address = address;

            _personService.Create(person);
            return CreatedAtRoute("GetPeron", new { id = person.Id.ToString() }, person);
        }

        [HttpPut]
        public ActionResult<Person> Update(string id, Person personIn)
        {
            var client = _personService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _personService.Update(id, personIn);

            client = _personService.Get(id);

            return NoContent();
        }


        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var client = _personService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _personService.Remove(client);

            return NoContent();
        }

    }
}
