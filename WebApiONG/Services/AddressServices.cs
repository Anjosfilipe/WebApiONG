using System.Collections.Generic;
using MongoDB.Driver;
using WebApiONG.Models;
using WebApiONG.Utils;

namespace WebApiONG.Services
{
    public class AddressServices
    {
        private IMongoCollection<Address> _address;

        public AddressServices(IDatabaseSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public List<Address> Get() => _address.Find(address => true).ToList();

        public Address Get(string ID) => _address.Find<Address>(addres => addres.Id == ID).FirstOrDefault();

        public void Update(string ID, Address AddressIN)
        {
            _address.ReplaceOne(address => address.Id == ID, AddressIN);
        }

        public void Remove(Address AddressIN) => _address.DeleteOne(address => address.Id == address.Id);
    }
}
