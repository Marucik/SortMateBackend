using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMB.Core.Domain.Interfaces;

namespace SMB.Infrastructure.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task InsertAsync(T entity);
    }
}