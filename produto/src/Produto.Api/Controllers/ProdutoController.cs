using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.ProdutoCommands;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }
        
        [HttpGet]
        public async Task<IEnumerable<Produtos.Domain.Entities.Produto>> ListarTodos()
        {
            return  null;
        }
        [HttpGet("{id}")]
        public async Task<Produtos.Domain.Entities.Produto> Obter(Guid id)
        {
            return null;
        }
        [HttpPost]
        public async Task<Guid> Inserir([FromBody] AdcionarProdutoCommand produto)
        {
            var produtoId = await _mediator.Send(produto);
            return produtoId;
        }

    }
}
