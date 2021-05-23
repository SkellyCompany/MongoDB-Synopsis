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

		public ProductSeries Read(int id)
		{
			return _productSeriesRepository.Read(id);
		}

		public ProductSeries Create(ProductSeries productSeries)
		{
			return _productSeriesRepository.Create(productSeries);
		}

		public ProductSeries Update(ProductSeries productSeries)
		{
			return _productSeriesRepository.Update(productSeries);
		}

		public ProductSeries Delete(int id)
		{
			return _productSeriesRepository.Delete(id);
		}
	}
}
