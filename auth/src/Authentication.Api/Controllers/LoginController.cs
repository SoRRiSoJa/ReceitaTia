using authentication.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }
        [HttpPost]
        public async Task<string> Post([FromBody] LoginCommand loginCommand)
        {
            return await _mediator.Send(loginCommand);
        }
    }
}
