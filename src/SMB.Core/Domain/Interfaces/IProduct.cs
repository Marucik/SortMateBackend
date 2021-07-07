using System;
using System.Collections.Generic;

namespace SMB.Core.Domain.Interfaces
{
  /// <summary>
  /// Interfejs pojedynczego produktu.
  /// </summary>
  public interface IProduct
  {
    Guid Id { get; }
    string Name { get; set; }
    string Code { get; set; }
    string Description { get; set; }
    string SegregationType { get; set; }
  }
}