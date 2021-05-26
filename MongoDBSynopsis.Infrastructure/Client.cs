using MongoDB.Bson;
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

		public IEnumerable<BsonDocument> ReadAll<T>(string collectionName, string filterField = "", string filterValue = "")
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			if (!string.IsNullOrEmpty(filterField) && !string.IsNullOrEmpty(filterValue))
			{
				FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(filterField, filterValue);
				IEnumerable<BsonDocument> documents = collection.Find(filter).ToList();
				return documents;
			}
			else
			{
				IEnumerable<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
				return documents;
			}
		}

		public BsonDocument Read<T>(string collectionName, string id)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			BsonDocument document = collection.Find(filter).FirstOrDefault();
			return document;
		}

		public void Create(string collectionName, BsonDocument bsonDocument)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			collection.InsertOne(bsonDocument);
		}

		public void CreateSubcollection(string collectionName, string subCollectionName, string id, BsonDocument bsonDocument)
		{
			IMongoDatabase database = _mongoClient.GetDatabase("MongoDBSynopsis-Database");
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
			var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
			var update = Builders<BsonDocument>.Update.Push(subCollectionName, bsonDocument);
			collection.FindOneAndUpdate(filter, update);
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
	}
}
