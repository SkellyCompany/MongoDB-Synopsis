namespace MongoDBSynopsis.Entities
{
	public class ProductSeries
	{
		public int Id { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}
}
