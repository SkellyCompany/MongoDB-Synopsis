using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService.Services
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly IManufacturerRepository _manufacturerRepository;


		public ManufacturerService(IManufacturerRepository manufacturerRepository)
		{
			_manufacturerRepository = manufacturerRepository;
		}

		public IEnumerable<Manufacturer> ReadAll()
		{
			return _manufacturerRepository.ReadAll();
		}

		public Manufacturer Read(string id)
		{
			return _manufacturerRepository.Read(id);
		}

		public Manufacturer Create(Manufacturer manufacturer)
		{
			return _manufacturerRepository.Create(manufacturer);
		}

		public Manufacturer Update(Manufacturer manufacturer)
		{
			return _manufacturerRepository.Update(manufacturer);
		}

		public Manufacturer Delete(string id)
		{
			return _manufacturerRepository.Delete(id);
		}
	}
}
