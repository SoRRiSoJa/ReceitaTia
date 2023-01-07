using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.PrePreparoCommands;
using Produto.Application.DTOs;
using Produto.Application.Queries.PrePreparoQueries;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrePreparoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PrePreparoController(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }
        [HttpPost]
        public async Task<Guid> Inserir([FromBody] AdicionarPrePreparoCommand prePreparo)
        {
            return await _mediator.Send(prePreparo);
        }
        [HttpGet]
        public async Task<IEnumerable<PrePreparosDto>> ListarTodos()
        {
            //var brigadeiroPrePreparo = new PrePreparo() {PrePreparoId=Guid.NewGuid(),ProdutoId=new Guid("39b22a52-bdc6-4198-9d26-e144691639ab"),Rendimento=180, };
            //var listaProdutos = new List<ProdutoPrePreparo>() 
            //{
            //    new ProdutoPrePreparo() { ProdutoId = new Guid("d6216ce1-7f3d-45ff-aef5-7565484df037"),Quantidade=50,UnidadeMedida=EUnidadeMedida.Grama},
            //    new ProdutoPrePreparo() { ProdutoId = new Guid("137e6539-84ac-49bc-82d4-16a3262184cb"),Quantidade=30,UnidadeMedida=EUnidadeMedida.Grama },
            //    new ProdutoPrePreparo() { ProdutoId = new Guid("567809c1-c9a1-4d9a-8ef7-f746791b14ed"),Quantidade=100,UnidadeMedida=EUnidadeMedida.Grama },
            //};
            //brigadeiroPrePreparo.Produtos = listaProdutos;
            //var prepreparoId=await _prePreparoRepository.Inserir(brigadeiroPrePreparo);
            return await _mediator.Send(new ObterTodosPrePreparosQuery());

        }
        [HttpGet("{id}")]
        public async Task<PrePreparosDto> Obter(Guid id)
        {
            return null;
        }
    }
}
