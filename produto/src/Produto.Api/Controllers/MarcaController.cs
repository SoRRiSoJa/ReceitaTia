using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.Marca;
using Produto.Application.DTOs;
using Produto.Application.Queries.MarcaQueries;

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
        [HttpGet]
        public async Task<IEnumerable<MarcasDto>> ListarTodos()
        {
            return await _mediator.Send(new ObterTodasAsMarcasQuery());
        }
        [HttpGet("{id}")]
        public async Task<MarcasDto> Obter(Guid id)
        {
            return await _mediator.Send(new ObterMarcaPorIdQuery() { MarcaId = id });
        }
    }
}
