using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly Client _client;


		public ProductRepository(Client client)
		{
			_client = client;
		}

		public IEnumerable<Product> ReadAll()
		{
			IEnumerable<BsonDocument> documents = _client.ReadAll<Product>("Products");
			List<Product> objects = new();
			foreach (BsonDocument document in documents)
			{
				objects.Add(BsonSerializer.Deserialize<Product>(document));
			}
			return objects;
		}

		public Product Read(string id)
		{
			BsonDocument document = _client.Read<Product>("Products", id);
			return BsonSerializer.Deserialize<Product>(document);
		}

		public Product Create(Product product)
		{
			BsonDocument bsonDocument = new()
			{
				{ "_id", ObjectId.GenerateNewId()},
				{ "SerialNumber", product.SerialNumber},
				{ "ConditionStatus", product.ConditionStatus},
				{ "RegistrationDate", product.RegistrationDate},
				{ "WarrantyDuration", product.WarrantyDuration}
			};
			_client.CreateSubcollection("ProductSeries", "Products", product.ProductSeries.Id, bsonDocument);
			return product;
		}

		public bool Update(Product product)
		{
			BsonDocument bsonDocument = new()
			{
				{ "SerialNumber", product.SerialNumber},
				{ "ConditionStatus", product.ConditionStatus},
				{ "RegistrationDate", product.RegistrationDate},
				{ "WarrantyDuration", product.WarrantyDuration}
			};
			bool success = _client.Update("Products", product.Id, bsonDocument);
			return success;
		}

		public bool Delete(string id)
		{
			bool success = _client.Delete("Products", id);
			return success;
		}
	}
}
