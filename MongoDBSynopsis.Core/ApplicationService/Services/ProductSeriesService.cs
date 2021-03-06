using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService.Services
{
	public class ProductSeriesService : IProductSeriesService
	{
		private readonly IProductSeriesRepository _productSeriesRepository;


		public ProductSeriesService(IProductSeriesRepository productSeriesRepository)
		{
			_productSeriesRepository = productSeriesRepository;
		}

		public IEnumerable<ProductSeries> ReadAll()
		{
			return _productSeriesRepository.ReadAll();
		}

		public IEnumerable<ProductSeries> ReadAllByManufacturer(string manufacturerId)
		{
			return _productSeriesRepository.ReadAllByManufacturer(manufacturerId);
		}

		public ProductSeries Read(string id)
		{
			return _productSeriesRepository.Read(id);
		}

		public ProductSeries Create(ProductSeries productSeries)
		{
			return _productSeriesRepository.Create(productSeries);
		}

		public bool Update(ProductSeries productSeries)
		{
			return _productSeriesRepository.Update(productSeries);
		}

		public bool Delete(string id)
		{
			return _productSeriesRepository.Delete(id);
		}
	}
}
