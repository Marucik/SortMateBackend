using System;

namespace SMB.Core.Domain.Interfaces
{
	public interface IAuditable
	{
		DateTimeOffset CreatedAt { get; }
		DateTimeOffset ModifiedAt { get; }
	}
}