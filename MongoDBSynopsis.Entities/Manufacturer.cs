using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSynopsis.Entities
{
	public class Manufacturer
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}
}
