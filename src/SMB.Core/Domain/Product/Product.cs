namespace SMB.Core.Domain
{
	public class Product : IAuditable
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public Type[] SegregationType { get; set; }
	}
}