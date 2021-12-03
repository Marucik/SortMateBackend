using System;

namespace SMB.Core.Domain.Interfaces
{
    /// <summary>
    /// Interfejs pośiwdczeń użytkownika.
    /// </summary>
    public interface IUser
    {
        Guid Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}