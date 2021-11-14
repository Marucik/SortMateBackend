namespace SMB.Core.Domain.Interfaces
{
  /// <summary>
  /// Interfejs pośiwdczeń użytkownika.
  /// </summary>
  public interface IUserCredentials
  {
    string Login { get; set; }
    string Password { get; set; }
  }
}