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
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			_client.Create("ProductSeries", bsonDocument);
			return productSeries;
		}

		public ProductSeries Delete(string id)
		{
			_client.Delete("ProductSeries", id);
			return null;
		}

		public ProductSeries Read(string id)
		{
			return _client.Read<ProductSeries>("ProductSeries", id);
		}

		public IEnumerable<ProductSeries> ReadAll()
		{
			return _client.ReadAll<ProductSeries>("ProductSeries");
		}

		public ProductSeries Update(ProductSeries productSeries)
		{
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			_client.Update("ProductSeries", productSeries.Id, bsonDocument);
			return productSeries;
		}
	}
}
