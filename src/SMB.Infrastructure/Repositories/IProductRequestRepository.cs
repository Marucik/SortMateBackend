using System;
using System.Threading.Tasks;
using SMB.Core.Domain.ProductRequest;

namespace SMB.Infrastructure.Repositories
{
  public interface IProductRequestRepository : IRepository<ProductRequest>
  {
    Task<ProductRequest> FindAndDeleteByIdAsync(Guid id);
  }
}