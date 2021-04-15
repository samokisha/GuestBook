using System;
using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Comments;
using Microsoft.Extensions.Logging;
using StorageService.Repositories;

namespace StorageService.Consumers
{
    public class SaveCommentConsumer : IConsumer<NewCommentModel>
    {
        private readonly ILogger<SaveCommentConsumer> _logger;
        private readonly ICommentRepository _repository;

        public SaveCommentConsumer(ICommentRepository repository, ILogger<SaveCommentConsumer> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<NewCommentModel> context)
        {
            var commentId = await _repository.AddAsync(context.Message);

            _logger.LogInformation("Consume new comment. Comment saved with id: {Id}", commentId);

            await context.RespondAsync<SavedCommentIdModel>(new {Id = commentId});
        }
    }
}