using MongoDB.Bson.Serialization.Attributes;

namespace WebApiONG.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }

    }
}
