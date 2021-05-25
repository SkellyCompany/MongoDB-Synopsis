using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService
{
	public interface IManufacturerService
	{
		Manufacturer Create(Manufacturer manufacturer);

		Manufacturer Read(string id);

		IEnumerable<Manufacturer> ReadAll();

		bool Update(Manufacturer manufacturer);

		bool Delete(string id);
	}
}
