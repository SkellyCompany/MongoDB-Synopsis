using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure.Repositories
{
	public class ManufacturerRepository : IManufacturerRepository
	{
		private readonly MongoClient _mongoClient;

		public ManufacturerRepository(MongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public Manufacturer Create(Manufacturer manufacturer)
		{
			IMongoDatabase _database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> _manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			BsonDocument bsonDocument = new BsonDocument
			{
				{ "Name", manufacturer.Name},
				{ "Image", manufacturer.Image}
			};
			_manufacturerCollection.InsertOne(bsonDocument);
			return manufacturer;
		}

		public Manufacturer Delete(string id)
		{
			IMongoDatabase _database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> _manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			var documentFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			_manufacturerCollection.DeleteOne(documentFilter);
			return null;
		}

		public Manufacturer Read(string id)
		{
			IMongoDatabase _database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> _manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			var documentFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			BsonDocument document = _manufacturerCollection.Find(documentFilter).FirstOrDefault();
			return BsonSerializer.Deserialize<Manufacturer>(document);
		}

		public IEnumerable<Manufacturer> ReadAll()
		{
			IMongoDatabase _database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument>  _manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			IEnumerable<BsonDocument> documents = _manufacturerCollection.Find(new BsonDocument()).ToList();
			List<Manufacturer> t = new List<Manufacturer>();
			foreach (BsonDocument item in documents)
			{
				t.Add(BsonSerializer.Deserialize<Manufacturer>(item));
			}
			return t;
		}

		public Manufacturer Update(Manufacturer manufacturer)
		{
			IMongoDatabase _database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> _manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			var documentFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(manufacturer.Id));
			BsonDocument bsonDocument = new BsonDocument
				{
					{ "Name", manufacturer.Name},
					{ "Image", manufacturer.Image}
				};
			_manufacturerCollection.ReplaceOne(documentFilter, bsonDocument);
			return manufacturer;
		}
	}
}
