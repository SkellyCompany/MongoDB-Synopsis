using MongoDB.Bson;
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

		public Product Create(Product product)
		{
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "SerialNumber", product.SerialNumber},
				{ "ConditionStatus", product.ConditionStatus},
				{ "ConditionStatus", product.RegistrationDate},
				{ "ConditionStatus", product.WarrantyDuration}
			};
			_client.Create("Products", bsonDocument);
			return product;
		}

		public Product Delete(string id)
		{
			_client.Delete("Products", id);
			return null;
		}

		public Product Read(string id)
		{
			return _client.Read<Product>("Products", id);
		}

		public IEnumerable<Product> ReadAll()
		{
			return _client.ReadAll<Product>("Products");
		}

		public Product Update(Product product)
		{
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "SerialNumber", product.SerialNumber},
				{ "ConditionStatus", product.ConditionStatus},
				{ "ConditionStatus", product.RegistrationDate},
				{ "ConditionStatus", product.WarrantyDuration}
			};
			_client.Update("Products", product.Id, bsonDocument);
			return product;
		}
	}
}
