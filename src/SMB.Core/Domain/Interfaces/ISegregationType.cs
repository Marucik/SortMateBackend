using System;

namespace SMB.Core.Domain.Interfaces
{
	public interface ISegregationType
	{
		Guid Id { get; }
		string Name { get; set; }
	}
}