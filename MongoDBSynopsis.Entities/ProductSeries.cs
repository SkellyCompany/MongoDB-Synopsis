using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSynopsis.Entities
{
	public class ProductSeries
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}
}
