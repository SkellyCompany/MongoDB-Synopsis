using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;


		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public IEnumerable<Product> ReadAll()
		{
			return _productRepository.ReadAll();
		}

		public Product Read(string id)
		{
			return _productRepository.Read(id);
		}

		public Product Create(Product product)
		{
			return _productRepository.Create(product);
		}

		public bool Update(Product product)
		{
			return _productRepository.Update(product);
		}

		public bool Delete(string id)
		{
			return _productRepository.Delete(id);
		}

	}
}
