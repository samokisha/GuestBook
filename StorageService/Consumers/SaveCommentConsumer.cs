using System;
using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Comments;
using StorageService.Repositories;

namespace StorageService.Consumers
{
    public class SaveCommentConsumer : IConsumer<Comment>
    {
        private readonly ICommentRepository _repository;

        public SaveCommentConsumer(ICommentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Consume(ConsumeContext<Comment> context)
        {
            var commentId = await _repository.AddAsync(context.Message);
            await context.RespondAsync<CommentSaved>(new CommentSaved {Id = commentId});
        }
    }
}