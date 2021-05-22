using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IProductRepository
	{
		Product Create(Product product);

		Product Read(int id);

		IEnumerable<Product> ReadAll();

		Product Update(Product product);

		Product Delete(int id);
	}
}
