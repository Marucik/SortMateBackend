using System;

namespace SMB.Core.Domain.Interfaces
{
  /// <summary>
  /// Interfejs pojedynczego typu segregacji.
  /// </summary>
  public interface ISegregationType
  {
    Guid Id { get; }
    string Name { get; set; }
  }
}