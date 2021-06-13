using System;
using System.Collections.Generic;
using SMB.Core.Domain.Interfaces;

namespace SMB.Core.Domain.ProductRequest
{
  public class ProductRequest : IEntity, IProductRequest
  {
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string SegregationType { get; set; }

    public ProductRequest(string name, string code, string description, string segregationTypes)
    {
      Name = name;
      Code = code;
      Description = description;
      SegregationType = segregationTypes;
    }
  }
}