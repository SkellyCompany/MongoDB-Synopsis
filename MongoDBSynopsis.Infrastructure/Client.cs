using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
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

		public bool Delete(string collectionName, string id)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			DeleteResult result = collection.DeleteOne(filter);
			if (result.DeletedCount > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
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

		public bool Update(string collectionName, string id, BsonDocument bsonDocument)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			ReplaceOneResult result = collection.ReplaceOne(filter, bsonDocument);
			if (result.ModifiedCount > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
