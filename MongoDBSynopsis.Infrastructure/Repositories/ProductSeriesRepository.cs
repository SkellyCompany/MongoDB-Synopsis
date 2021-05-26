using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

		public IEnumerable<ProductSeries> ReadAll()
		{
			IEnumerable<BsonDocument> documents = _client.ReadAll<ProductSeries>("ProductSeries");
			List<ProductSeries> objects = new();
			foreach (BsonDocument document in documents)
			{
				ProductSeries productSeries = new()
				{
					Name = document.GetValue("Name").AsString,
					Image = document.GetValue("Image").AsString
				};
				objects.Add(productSeries);
			}
			return objects;
		}

		public ProductSeries Read(string id)
		{
			BsonDocument document = _client.Read<ProductSeries>("ProductSeries", id);
			ProductSeries productSeries = new()
			{
				Id = id,
				Name = document.GetValue("Name").AsString,
				Image = document.GetValue("Image").AsString
			};
			return productSeries;
		}

		public IEnumerable<ProductSeries> ReadAllByManufacturer(string manufacturerId)
		{
			IEnumerable<BsonDocument> documents = _client.ReadAll<ProductSeries>("ProductSeries", "ManufacturerId", manufacturerId);
			List<ProductSeries> objects = new();
			foreach (BsonDocument document in documents)
			{
				ProductSeries productSeries = new()
				{
					Name = document.GetValue("Name").AsString,
					Image = document.GetValue("Image").AsString
				};
				objects.Add(productSeries);
			}
			return objects;
		}

		public ProductSeries Create(ProductSeries productSeries)
		{
			BsonArray productsBsonArray = new();
			BsonDocument bsonDocument = new()
			{
				{ "ManufacturerId", productSeries.Manufacturer.Id},
				{ "Products", productsBsonArray},
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			_client.Create("ProductSeries", bsonDocument);
			return productSeries;
		}

		public bool Update(ProductSeries productSeries)
		{
			BsonArray productsBsonArray = new();
			BsonDocument bsonDocument = new()
			{
				{ "ManufacturerId", productSeries.Manufacturer.Id},
				{ "Products", productsBsonArray},
				{ "Name", productSeries.Name},
				{ "Image", productSeries.Image}
			};
			bool success = _client.Update("ProductSeries", productSeries.Id, bsonDocument);
			return success;
		}

		public bool Delete(string id)
		{
			bool success = _client.Delete("ProductSeries", id);
			return success;
		}
	}
}
