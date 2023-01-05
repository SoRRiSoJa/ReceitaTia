using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.ProdutoCommands;
using Produto.Application.DTOs;
using Produto.Application.Queries.ProdutosQueries;

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
        public async Task<IEnumerable<ProdutosDto>> ListarTodos()
        {
            return await _mediator.Send(new ObterTodosOsProdutosQuery());
        }
        [HttpGet("{id}")]
        public async Task<ProdutosDto> Obter(Guid id)
        {
            return await _mediator.Send(new ObterProdutoPorIdQuery() { ProdutoId = id });
        }
        [HttpPost]
        public async Task<Guid> Inserir([FromBody] AdcionarProdutoCommand produto)
        {
            var produtoId = await _mediator.Send(produto);
            return produtoId;
        }

    }
}
