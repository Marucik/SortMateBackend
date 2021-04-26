using System;

namespace SMB.Core.Domain
{
	public interface ISegregationType
	{
		Guid Id { get; }
		string Name { get; set; }
	}
}