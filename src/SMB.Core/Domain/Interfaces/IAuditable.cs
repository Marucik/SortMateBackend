using System;

namespace SMB.Core.Domain
{
	public interface IAuditable
	{
		DateTimeOffset CreatedAt { get; }
		DateTimeOffset ModifiedAt { get; }
	}
}