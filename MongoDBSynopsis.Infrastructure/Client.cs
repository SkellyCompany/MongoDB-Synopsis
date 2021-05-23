using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBSynopsis.Infrastructure
{
	class Client
	{
		private IMongoDatabase _database;
		private IMongoCollection<BsonDocument> _productCollection;
		private IMongoCollection<BsonDocument> _documentCollection;

		public bool IsConnected { get; private set; }


		public void Connect()
		{
			try
			{
				MongoClient client = new MongoClient("mongodb+srv://admin:skelly@mongodbsynopsis-cluster.gzxog.mongodb.net/MongoDBSynopsis-Database?retryWrites=true&w=majority");
				_database = client.GetDatabase("MongoDBSynopsis-Database");
				_productCollection = _database.GetCollection<BsonDocument>("Manufacturer");
				_productCollection = _database.GetCollection<BsonDocument>("Product");
				_documentCollection = _database.GetCollection<BsonDocument>("ProductSeries");
				IsConnected = true;
			}
			catch (ArgumentOutOfRangeException e)
			{
				throw e;
			}
		}	
	}
}
