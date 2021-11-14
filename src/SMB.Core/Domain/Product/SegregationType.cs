using System;
using SMB.Core.Domain.Interfaces;

namespace SMB.Core.Domain
{
  /// <summary>
  /// Klasa przeedstawiająca typ segregacji.
  /// </summary>
  public class SegregationType : IEntity, IAuditable, ISegregationType
  {
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ModifiedAt { get; private set; }
    /// <summary>
    /// Konstruktor nowego typu segregacji.
    /// </summary>
    /// <param name="name"></param>
    public SegregationType(string name)
    {
      Id = Guid.NewGuid();
      Name = name;
      CreatedAt = DateTimeOffset.Now;
      ModifiedAt = DateTimeOffset.Now;
    }
  }
}