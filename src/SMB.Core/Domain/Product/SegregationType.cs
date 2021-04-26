using System;

namespace SMB.Core.Domain
{

	public class SegregationType : IEntity, IAuditable, ISegregationType
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public DateTimeOffset CreatedAt { get; private set; }
		public DateTimeOffset ModifiedAt { get; private set; }

		public SegregationType(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			CreatedAt = DateTimeOffset.Now;
			ModifiedAt = DateTimeOffset.Now;
		}
	}
}