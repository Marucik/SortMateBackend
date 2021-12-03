using System.Threading.Tasks;
using SMB.Core.Domain.User;

namespace SMB.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);
        // Task InsertAsync(User user);
    }
}