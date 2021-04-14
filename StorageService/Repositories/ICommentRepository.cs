using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageContracts.Comments;

namespace StorageService.Repositories
{
    public interface ICommentRepository
    {
        Task<Guid> AddAsync(Comment entity);

        Task<Comment> GetAsync(Guid id);

        Task<ICollection<Comment>> GetAllAsync();
    }
}