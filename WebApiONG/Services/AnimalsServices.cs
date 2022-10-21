using System.Collections.Generic;
using MongoDB.Driver;
using WebApiONG.Models;
using WebApiONG.Utils;

namespace WebApiONG.Services
{
    public class AnimalsServices
    {
        private readonly IMongoCollection<Animals> _animal;

        public AnimalsServices(IDatabaseSettings settings)
        {
            var animal = new MongoClient(settings.ConnectionString);
            var database = animal.GetDatabase(settings.DatabaseName);
            _animal = database.GetCollection<Animals>(settings.AnimalsCollectionName);
        }

        public Animals Create(Animals animal)
        {
            _animal.InsertOne(animal);
            return animal;
        }

        public List<Animals> Get() => _animal.Find(animal => true).ToList();

        public Animals Get(string Id) => _animal.Find<Animals>(a => a.Id == Id).FirstOrDefault();

        public void Update(string Id, Animals animals)
        {
            _animal.ReplaceOne(a => a.Id == Id, animals);
        }

        public void Remove(Animals animalIN) => _animal.DeleteOne(a => a.Id == animalIN.Id);
    }
}
