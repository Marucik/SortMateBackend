namespace SMB.Core.Domain.Interfaces
{
  public interface IUserCredentials
  {
    string Login { get; set; }
    string Password { get; set; }
  }
}