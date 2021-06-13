using SMB.Core.Domain.Interfaces;

namespace SMB.Core.Domain.UserCredentials
{
  public class UserCredentials : IUserCredentials
  {
    public string Login { get; set; }
    public string Password { get; set; }
  }
}