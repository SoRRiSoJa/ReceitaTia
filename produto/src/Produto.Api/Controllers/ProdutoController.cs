using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Produtos.Domain.Entities.Produto> Inserir([FromBody] Produtos.Domain.Entities.Produto produto)
        {
            return null;
        }

    }
}
