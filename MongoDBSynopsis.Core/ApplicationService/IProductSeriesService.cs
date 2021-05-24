using MongoDBSynopsis.Entities;
using System.Collections.Generic;

namespace MongoDBSynopsis.Core.ApplicationService
{
	public interface IProductSeriesService
	{
		ProductSeries Create(ProductSeries productSeries);

		ProductSeries Read(string id);

		IEnumerable<ProductSeries> ReadAll();

		ProductSeries Update(ProductSeries productSeries);

		ProductSeries Delete(string id);
	}
}
