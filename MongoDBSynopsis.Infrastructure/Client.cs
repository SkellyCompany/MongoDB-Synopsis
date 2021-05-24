using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure
{
	public class Client
	{
		private readonly MongoClient _mongoClient;


		public Client(MongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public void Create(string collectionName, BsonDocument bsonDocument)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			collection.InsertOne(bsonDocument);
		}

		public void Delete(string collectionName, string id)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			collection.DeleteOne(filter);
		}

		public T Read<T>(string collectionName, string id)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			BsonDocument document = collection.Find(filter).FirstOrDefault();
			return BsonSerializer.Deserialize<T>(document);
		}

		public List<T> ReadAll<T>(string collectionName)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			IEnumerable<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
			List<T> objects = new List<T>();
			foreach (BsonDocument item in documents)
			{
				objects.Add(BsonSerializer.Deserialize<T>(item));
			}
			return objects;
		}

		public void Update(string collectionName, string id, BsonDocument bsonDocument)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			collection.ReplaceOne(filter, bsonDocument);
		}
	}
}
