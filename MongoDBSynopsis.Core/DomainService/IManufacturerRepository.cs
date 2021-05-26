using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IManufacturerRepository
	{
		Manufacturer Create(Manufacturer manufacturer);

		IEnumerable<Manufacturer> ReadAll();


		Manufacturer Read(string id);


		bool Update(Manufacturer manufacturer);

		bool Delete(string id);
	}
}
