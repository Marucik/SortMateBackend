using System.Threading.Tasks;
using SMB.Core.Domain;

namespace SMB.Infrastructure.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<Product> GetByCodeAsync(string code);
	}
}