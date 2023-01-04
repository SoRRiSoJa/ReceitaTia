using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.Marca;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarcaController(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }

        [HttpPost]
        public async Task<Guid> Inserir([FromBody] AdcionarMarcaCommand marca)
        {
            var marcaId = await _mediator.Send(marca);
            return marcaId;
        }
    }
}
