using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SMB.Core.Domain.User;
using SMB.Infrastructure.Mongo;

namespace SMB.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        private readonly MongoDbSettings _mongoDbSettings;

        public UserRepository(IMongoClient client, MongoDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
            var database = client.GetDatabase(_mongoDbSettings.DatabaseName);
            _collection = database.GetCollection<User>("users");
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _collection.AsQueryable().Where(x => x.Login == login).FirstAsync();
        }

        public async Task InsertAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }
    }
}