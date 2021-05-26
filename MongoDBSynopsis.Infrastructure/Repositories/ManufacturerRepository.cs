using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure.Repositories
{
	public class ManufacturerRepository : IManufacturerRepository
	{
		private readonly Client _client;


		public ManufacturerRepository(Client client)
		{
			_client = client;
		}

		public IEnumerable<Manufacturer> ReadAll()
		{
			IEnumerable<BsonDocument> documents = _client.ReadAll<Manufacturer>("Manufacturers");
			List<Manufacturer> objects = new();
			foreach (BsonDocument document in documents)
			{
				objects.Add(BsonSerializer.Deserialize<Manufacturer>(document));
			}
			return objects;
		}

		public Manufacturer Read(string id)
		{
			BsonDocument document =	_client.Read<Manufacturer>("Manufacturers", id);
			return BsonSerializer.Deserialize<Manufacturer>(document);
		}

		public Manufacturer Create(Manufacturer manufacturer)
		{
			BsonDocument bsonDocument = new()
			{
				{ "Name", manufacturer.Name},
				{ "Image", manufacturer.Image}
			};
			_client.Create("Manufacturers", bsonDocument);
			return manufacturer;
		}

		public bool Update(Manufacturer manufacturer)
		{
			BsonDocument bsonDocument = new()
			{
				{ "Name", manufacturer.Name},
				{ "Image", manufacturer.Image}
			};
			bool result = _client.Update("Manufacturers", manufacturer.Id, bsonDocument);
			return result;
		}

		public bool Delete(string id)
		{
			bool success = _client.Delete("Manufacturers", id);
			return success;
		}
	}
}
