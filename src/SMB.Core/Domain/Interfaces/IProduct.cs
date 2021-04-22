using System;
using System.Collections.Generic;

namespace SMB.Core.Domain
{
	public interface IProduct
	{
		Guid Id { get; }
		string Name { get; set; }
		string Code { get; set; }
		string Description { get; set; }
		IEnumerable<string> SegregationTypes { get; set; }
		DateTimeOffset CreatedAt { get; }
		DateTimeOffset ModifiedAt { get; }
	}
}