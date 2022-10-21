using MongoDB.Bson.Serialization.Attributes;

namespace WebApiONG.Models
{
    public class Animals
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Family { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public Person Person { get; set; }

    }
}
