using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService
{
	public interface IProductService
	{
		Product Create(Product product);

		Product Read(string id);

		IEnumerable<Product> ReadAll();

		bool Update(Product product);

		bool Delete(string id);
	}
}
