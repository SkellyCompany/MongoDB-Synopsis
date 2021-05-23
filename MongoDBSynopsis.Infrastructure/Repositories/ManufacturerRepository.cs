using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Infrastructure.Repositories
{
	public class ManufacturerRepository : IManufacturerRepository
	{
		public Manufacturer Create(Manufacturer manufacturer)
		{
			throw new NotImplementedException();
		}

		public Manufacturer Delete(int id)
		{

			throw new NotImplementedException();
		}

		public Manufacturer Read(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Manufacturer> ReadAll()
		{
			Client client = new Client();
			var t = client.Test();
			var ta = client.Test();
			throw new NotImplementedException();
		}

		public Manufacturer Update(Manufacturer manufacturer)
		{
			throw new NotImplementedException();
		}
	}
}
