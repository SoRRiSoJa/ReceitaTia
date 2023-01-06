using Microsoft.AspNetCore.Mvc;
using Produto.Application.Commands.Marca;
using Produto.Application.DTOs;
using Produto.Application.Queries.MarcaQueries;
using Produtos.Domain.Entities;
using Produtos.Domain.Enums;
using Produtos.Domain.Repositories;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrePreparoController : ControllerBase
    {
        private readonly IPrePreparoRepository _prePreparoRepository;
        public PrePreparoController(IPrePreparoRepository _prePreparoRepository)
        {
            this._prePreparoRepository = _prePreparoRepository ?? throw new ArgumentNullException(nameof(_prePreparoRepository));
        }
        [HttpPost]
        public async Task<Guid> Inserir([FromBody] AdcionarMarcaCommand marca)
        {
            
            return Guid.Empty;
        }
        [HttpGet]
        public async Task<IEnumerable<PrePreparo>> ListarTodos()
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
            return await _prePreparoRepository.ObterTodos(null);
        }
        [HttpGet("{id}")]
        public async Task<PrePreparo> Obter(Guid id)
        {
            return await _prePreparoRepository.Obter(id);
        }
    }
}
