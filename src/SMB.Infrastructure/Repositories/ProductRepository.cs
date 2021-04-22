using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SMB.Core.Domain;
using SMB.Infrastructure.Mongo;

namespace SMB.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoCollection<Product> _collection;
		private readonly MongoDbSettings _mongoDbSettings;

		public ProductRepository(IMongoClient client, MongoDbSettings mongoDbSettings)
		{
			_mongoDbSettings = mongoDbSettings;
			var database = client.GetDatabase(_mongoDbSettings.DatabaseName);
			_collection = database.GetCollection<Product>("products");
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _collection.AsQueryable().ToListAsync();
		}

		public Task<IProduct> GetByCodeAsync(string code)
		{
			throw new System.NotImplementedException();
		}

		public async Task InsertAsync(Product entity)
		{
			await _collection.InsertOneAsync(entity);
		}
	}
}