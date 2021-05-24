using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IProductRepository
	{
		Product Create(Product product);

		Product Read(string id);

		IEnumerable<Product> ReadAll();

		Product Update(Product product);

		Product Delete(string id);
	}
}
