using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.DomainService
{
	public interface IProductSeriesRepository
	{
		ProductSeries Create(ProductSeries productSeries);

		ProductSeries Read(int id);

		IEnumerable<ProductSeries> ReadAll();

		ProductSeries Update(ProductSeries productSeries);

		ProductSeries Delete(int id);
	}
}
