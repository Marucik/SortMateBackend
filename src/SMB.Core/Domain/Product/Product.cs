using System;
using System.Collections.Generic;
using SMB.Core.Domain.Interfaces;

namespace SMB.Core.Domain
{

  public class Product : IAuditable, IProduct, IEntity
  {
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string SegregationType { get; set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ModifiedAt { get; private set; }

    public Product(string name, string code, string description, string segregationTypes)
    {
      Id = Guid.NewGuid();
      Name = name;
      Code = code;
      Description = description;
      SegregationType = segregationTypes;
      CreatedAt = DateTime.Now;
      ModifiedAt = DateTime.Now;
    }

    public Product(IProductRequest productRequest)
    {
      Id = Guid.NewGuid();
      Name = productRequest.Name;
      Code = productRequest.Code;
      Description = productRequest.Description;
      SegregationType = productRequest.SegregationType;
      CreatedAt = DateTime.Now;
      ModifiedAt = DateTime.Now;
    }
  }
}