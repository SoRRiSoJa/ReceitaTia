using authentication.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }
        [HttpPost]
        public async Task<Guid> Post([FromBody] AddNewUserCommand userCommand)
        {
            return await _mediator.Send(userCommand);
        }
    }
}
