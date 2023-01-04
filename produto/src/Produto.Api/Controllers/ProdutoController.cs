using Microsoft.AspNetCore.Mvc;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        }
        
        [HttpGet]
        public async Task<IEnumerable<Produto>> ListarTodos()
        {
            return  await _produtoRepository.ObterTodos(null);
        }
        [HttpGet("{id}")]
        public async Task<Produto> Obter(Guid id)
        {
            var produto = await _produtoRepository.Obter(id);
            return produto;
        }
        [HttpPost]
        public async Task<Produto> Inserir([FromBody] Produto produto)
        {
            //Produto prod = new Produto() { Nome="Sprite lata",Descricao="Refrigerante Sprite Lata 320ml",CEST= "03.011.00",NCM= "2202.10.00", QtdItensContidos=1,CodigoBarras= "7894900010015", Tipo=ETipoProduto.MERCADORIA,MarcaId=new Guid("749b0477-379e-476c-86a7-b4f2e5db7ec3") };
            produto.ProdutoId=await _produtoRepository.Inserir(produto);
            return produto;
        }

    }
}
