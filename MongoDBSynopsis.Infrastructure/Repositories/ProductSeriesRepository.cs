using MongoDB.Bson;
using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure.Repositories
{
	public class ProductSeriesRepository : IProductSeriesRepository
	{
		private readonly Client _client;


		public ProductSeriesRepository(Client client)
		{
			_client = client;
		}

		public ProductSeries Create(ProductSeries productSeries)
		{
			BsonArray productsBsonArray = new BsonArray();
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "ManufacturerId", productSeries.Manufacturer.Id},
				{ "Products", productsBsonArray},
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			_client.Create("ProductSeries", bsonDocument);
			return productSeries;
		}

		public bool Delete(string id)
		{
			bool success = _client.Delete("ProductSeries", id);
			return success;
		}

		public ProductSeries Read(string id)
		{
			return _client.Read<ProductSeries>("ProductSeries", id);
		}

		public IEnumerable<ProductSeries> ReadAll()
		{
			return _client.ReadAll<ProductSeries>("ProductSeries");
		}

		public bool Update(ProductSeries productSeries)
		{
			BsonArray productsBsonArray = new BsonArray();
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "ManufacturerId", productSeries.Manufacturer.Id},
				{ "Products", productsBsonArray},
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			bool success = _client.Update("ProductSeries", productSeries.Id, bsonDocument);
			return success;
		}
	}
}
