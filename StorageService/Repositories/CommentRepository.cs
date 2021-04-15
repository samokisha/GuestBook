using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MessageContracts.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StorageService.Data;
using StorageService.Data.Entities;

namespace StorageService.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ILogger<CommentRepository> _logger;
        private readonly GuestBookContext _context;
        private readonly IMapper _mapper;

        public CommentRepository( ILogger<CommentRepository> logger, GuestBookContext context, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(NewCommentModel comment)
        {
            var entry = await _context.Comments.AddAsync(_mapper.Map<Comment>(comment));
            await _context.SaveChangesAsync();
            
            _logger.LogDebug("Added new comment. Id: {Id}", entry.Entity.Id);
            
            return entry.Entity.Id;
        }

        public async Task<SavedCommentIdModel> GetAsync(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);

            _logger.LogDebug("Find comment by id {Id}. Found: {Status}", id, comment != null);
            
            return _mapper.Map<SavedCommentIdModel>(comment);
        }

        public async Task<ICollection<SavedCommentIdModel>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();

            _logger.LogDebug("Get all comments. Count: {Count}", comments.Count);

            return _mapper.Map<ICollection<SavedCommentIdModel>>(comments);
        }
    }
}