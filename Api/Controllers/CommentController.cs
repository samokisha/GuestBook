using System;
using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IRequestClient<Comment> _requestClient;
        
        public CommentController(IRequestClient<Comment> requestClient)
        {
            _requestClient = requestClient ?? throw new ArgumentNullException(nameof(requestClient));
        }

        [HttpPost]
        public async Task<Guid> Get([FromBody] Comment comment)
        {
            var response = await _requestClient.GetResponse<CommentSaved>(comment);
            return response.Message.Id;
        }
    }
}