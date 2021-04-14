using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageContracts.Comments;
using Microsoft.EntityFrameworkCore;
using StorageService.Data;

namespace StorageService.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GuestBookContext _context;

        public CommentRepository(GuestBookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> AddAsync(Comment comment)
        {
            var entry = await _context.Comments.AddAsync(comment);
            return entry.Entity.Id;
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<ICollection<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}