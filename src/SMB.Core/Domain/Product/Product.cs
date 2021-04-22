using System;
using System.Collections.Generic;

namespace SMB.Core.Domain
{

	public class Product : IAuditable, IProduct, IEntity
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> SegregationTypes { get; set; }
		public DateTimeOffset CreatedAt { get; private set; }
		public DateTimeOffset ModifiedAt { get; private set; }

		public Product(string name, string code, string description, IEnumerable<string> segregationTypes)
		{
			Id = Guid.NewGuid();
			Name = name;
			Code = code;
			Description = description;
			SegregationTypes = segregationTypes;
			CreatedAt = DateTime.Now;
			ModifiedAt = DateTime.Now;
		}
	}
}