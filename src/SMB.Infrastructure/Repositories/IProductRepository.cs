using System.Threading.Tasks;
using SMB.Core.Domain;
using SMB.Core.Domain.Interfaces;

namespace SMB.Infrastructure.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<Product> GetByCodeAsync(string code);
	}
}