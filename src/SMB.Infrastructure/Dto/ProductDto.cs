using System;
using System.Collections.Generic;
using SMB.Core.Domain;

namespace SMB.Infrastructure.Dto
{
	public class ProductDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> SegregationTypes { get; set; } = new List<string>();
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset ModifiedAt { get; set; }

		public static ProductDto FromProduct(Product product)
		{
			return new ProductDto
			{
				Code = product.Code,
				Description = product.Description,
				Name = product.Name,
				SegregationTypes = product.SegregationTypes,
				CreatedAt = product.CreatedAt,
				ModifiedAt = product.ModifiedAt
			};
		}
	}
}