namespace MongoDBSynopsis.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public ProductSeries ProductSeries { get; set; }
		public int SerialNumber { get; set; }
		public int ConditionStatus { get; set; }
		public float RegistrationDate { get; set; }
		public float WarrantyDuration { get; set; }
	}
}
