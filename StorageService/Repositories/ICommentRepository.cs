using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageContracts.Comments;

namespace StorageService.Repositories
{
    public interface ICommentRepository
    {
        Task<Guid> AddAsync(NewCommentModel entity);

        Task<SavedCommentIdModel> GetAsync(Guid id);

        Task<ICollection<SavedCommentIdModel>> GetAllAsync();
    }
}