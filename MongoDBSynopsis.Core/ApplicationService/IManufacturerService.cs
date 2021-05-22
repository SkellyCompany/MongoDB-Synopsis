using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService
{
	public interface IManufacturerService
	{
		Manufacturer Create(Manufacturer manufacturer);

		Manufacturer Read(int id);

		IEnumerable<Manufacturer> ReadAll();

		Manufacturer Update(Manufacturer manufacturer);

		Manufacturer Delete(int id);
	}
}
