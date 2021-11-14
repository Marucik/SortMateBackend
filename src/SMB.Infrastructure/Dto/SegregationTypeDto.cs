using System;
using SMB.Core.Domain;

namespace SMB.Infrastructure.Dto
{
	public class SegregationTypeDto
	{
		public string Name { get; set; }
		public DateTimeOffset CreatedAt { get; private set; }
		public DateTimeOffset ModifiedAt { get; private set; }

		public static SegregationTypeDto FromSegregationType(SegregationType segregationType)
		{
			return new SegregationTypeDto
			{
				Name = segregationType.Name,
				CreatedAt = segregationType.CreatedAt,
				ModifiedAt = segregationType.ModifiedAt
			};
		}
	}
}