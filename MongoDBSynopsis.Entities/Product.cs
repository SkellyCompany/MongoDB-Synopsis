using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSynopsis.Entities
{
	public class Product
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public ProductSeries ProductSeries { get; set; }
		public string SerialNumber { get; set; }
		public string ConditionStatus { get; set; }
		public double RegistrationDate { get; set; }
		public double WarrantyDuration { get; set; }
	}
}
