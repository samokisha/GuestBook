using System;
using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly IRequestClient<NewCommentModel> _requestClient;
        
        public CommentController(ILogger<CommentController> logger, IRequestClient<NewCommentModel> requestClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _requestClient = requestClient ?? throw new ArgumentNullException(nameof(requestClient));
        }

        [HttpPost]
        public async Task<Guid> Add([FromBody] NewCommentModel comment)
        {
            var response = await _requestClient.GetResponse<SavedCommentIdModel>(comment);

            _logger.LogInformation("Received new comment. Saved with id: {Id}", response.Message.Id);

            return response.Message.Id;
        }
    }
}