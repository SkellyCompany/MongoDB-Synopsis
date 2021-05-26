using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IProductSeriesRepository
	{
		ProductSeries Create(ProductSeries productSeries);

		ProductSeries Read(string id);

		IEnumerable<ProductSeries> ReadAll();

		IEnumerable<ProductSeries> ReadAllByManufacturer(string manufacturerId);

		bool Update(ProductSeries productSeries);

		bool Delete(string id);
	}
}
