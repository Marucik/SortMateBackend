using System;
using SMB.Core.Domain.Interfaces;

namespace SMB.Core.Domain.User
{
    /// <summary>
    /// Klasa implementująca poświadczenia użytkownika.
    /// </summary>
    public class User : IEntity, IUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}