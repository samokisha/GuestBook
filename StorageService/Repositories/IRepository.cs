using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StorageService.Model;

namespace StorageService.Repositories
{
    public interface IRepository<TEntity, TId>
    {
        Task<Guid> AddAsync(TEntity entity);

        Task<Comment> GetAsync(TId id);

        Task<ICollection<Comment>> GetAllAsync();
    }
}