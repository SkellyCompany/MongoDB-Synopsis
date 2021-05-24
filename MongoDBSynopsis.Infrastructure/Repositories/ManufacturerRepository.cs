using MongoDB.Bson;
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

		public Manufacturer Create(Manufacturer manufacturer)
		{
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "Name", manufacturer.Name},
				{ "Image", manufacturer.Image}
			};
			_client.Create("Manufacturers", bsonDocument);
			return manufacturer;
		}

		public Manufacturer Delete(string id)
		{
			_client.Delete("Manufacturers", id);
			return null;
		}

		public Manufacturer Read(string id)
		{
			return _client.Read<Manufacturer>("Manufacturers", id);
		}

		public IEnumerable<Manufacturer> ReadAll()
		{
			return _client.ReadAll<Manufacturer>("Manufacturers");
		}

		public Manufacturer Update(Manufacturer manufacturer)
		{
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "Name", manufacturer.Name},
				{ "Image", manufacturer.Image}
			};
			_client.Update("Manufacturers", manufacturer.Id, bsonDocument);
			return manufacturer;
		}
	}
}
