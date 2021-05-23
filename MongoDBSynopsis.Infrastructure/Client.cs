using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDBSynopsis.Infrastructure
{
	class Client
	{
		private IMongoDatabase _database;
		private IMongoCollection<BsonDocument> _productCollection;
		private IMongoCollection<BsonDocument> _productSeriesCollection;
		private IMongoCollection<BsonDocument> _manufacturerCollection;


		public void Connect()
		{
			try
			{
				MongoClient client = new MongoClient("mongodb+srv://admin:admin@mongodbsynopsis-cluster.gzxog.mongodb.net/MongoDBSynopsis-Database?retryWrites=true&w=majority");
				_database = client.GetDatabase("MongoDBSynopsis-Database");
				_manufacturerCollection = _database.GetCollection<BsonDocument>("Manufacturers");
			}
			catch (ArgumentOutOfRangeException e)
			{
				throw;
			}
		}

		public BsonDocument Test()
		{
			Connect();
			   var firstDocument = _manufacturerCollection.Find(new BsonDocument()).FirstOrDefault();
			return firstDocument;
		}
	}
}
