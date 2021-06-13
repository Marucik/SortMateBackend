using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SMB.Core.Domain.ProductRequest;
using SMB.Infrastructure.Mongo;

namespace SMB.Infrastructure.Repositories
{
  public class ProductRequestRepository : IProductRequestRepository
  {
    private readonly IMongoCollection<ProductRequest> _collection;
    private readonly MongoDbSettings _mongoDbSettings;

    public ProductRequestRepository(IMongoClient client, MongoDbSettings mongoDbSettings)
    {
      _mongoDbSettings = mongoDbSettings;
      var database = client.GetDatabase(_mongoDbSettings.DatabaseName);
      _collection = database.GetCollection<ProductRequest>("product_requests"); ;
    }

    public async Task<IEnumerable<ProductRequest>> GetAllAsync()
    {
      return await _collection.AsQueryable().ToListAsync();
    }

    public async Task InsertAsync(ProductRequest entity)
    {
      await _collection.InsertOneAsync(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
      await _collection.DeleteOneAsync(x => x.Id == id);
    }
  }
}