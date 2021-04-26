using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SMB.Core.Domain;
using SMB.Infrastructure.Mongo;

namespace SMB.Infrastructure.Repositories
{
	public class SegregationTypeRepository : ISegregationTypeRepository
	{
		private readonly IMongoCollection<SegregationType> _collection;
		private readonly MongoDbSettings _mongoDbSettings;
		public SegregationTypeRepository(IMongoClient client, MongoDbSettings mongoDbSettings)
		{
			_mongoDbSettings = mongoDbSettings;
			var database = client.GetDatabase(_mongoDbSettings.DatabaseName);
			_collection = database.GetCollection<SegregationType>("segregation_types");
		}

		public async Task<IEnumerable<SegregationType>> GetAllAsync()
		{
			return await _collection.AsQueryable().ToListAsync();

		}

		public async Task InsertAsync(SegregationType entity)
		{
			await _collection.InsertOneAsync(entity);

		}
	}
}