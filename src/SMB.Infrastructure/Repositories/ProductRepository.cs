using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

		public async Task<Product> GetByCodeAsync(string code)
		{
			return await _collection.AsQueryable().Where(x => x.Code == code).FirstAsync();
		}

		public async Task InsertAsync(Product entity)
		{
			await _collection.InsertOneAsync(entity);
		}
	}
}