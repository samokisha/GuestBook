using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageContracts.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StorageService.Data;

namespace StorageService.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ILogger<CommentRepository> _logger;
        private readonly GuestBookContext _context;

        public CommentRepository( ILogger<CommentRepository> logger, GuestBookContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> AddAsync(Comment comment)
        {
            var entry = await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            
            _logger.LogDebug("Added new comment. Id: {Id}", entry.Entity.Id);
            
            return entry.Entity.Id;
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);

            _logger.LogDebug("Find comment by id {Id}. Found: {Status}", id, comment != null);
            
            return comment;
        }

        public async Task<ICollection<Comment>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();

            _logger.LogDebug("Get all comments. Count: {Count}", comments.Count);

            return comments;
        }
    }
}