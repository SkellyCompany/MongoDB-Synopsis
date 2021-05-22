using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IManufacturerRepository
	{
		Manufacturer Create(Manufacturer manufacturer);

		Manufacturer Read(int id);

		IEnumerable<Manufacturer> ReadAll();

		Manufacturer Update(Manufacturer manufacturer);

		Manufacturer Delete(int id);
	}
}
