using System.Collections.Generic;
using MongoDB.Driver;
using WebApiONG.Models;
using WebApiONG.Utils;

namespace WebApiONG.Services
{
    public class PersonServices
    {
        private readonly IMongoCollection<Person> _person;

        public PersonServices(IDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _person = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public Person Create(Person person)
        {
            _person.InsertOne(person);
            return person;
        }

        public List<Person> Get() => _person.Find(person => true).ToList();

        public Person Get(string Id) => _person.Find<Person>(p => p.Id == Id).FirstOrDefault();

        public void Update(string Id, Person person)
        {
            _person.ReplaceOne(p => p.Id == Id, person);
        }

        public void Remove(Person personIN) => _person.DeleteOne(p => p.Id == personIN.Id);
    }
}
