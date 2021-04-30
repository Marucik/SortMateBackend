using System.Collections.Generic;

namespace SMB.Infrastructure.Dto
{
	public class NewProductRequestDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> SegregationTypes { get; set; }
		public string ProductImage { get; set; }
	}
}