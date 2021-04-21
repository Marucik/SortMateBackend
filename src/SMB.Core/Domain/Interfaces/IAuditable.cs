namespace SMB.Core.Domain
{
	public class IAuditable
	{
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset ModifiedAt { get; set; }
	}
}