using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        public Task<Produto> Obter(long id);
        public Task<IEnumerable<Produto>> ObterTodos();
        public Task<Guid> Inserir(Produto produto);
        public Task<Produto> Atualizar(Produto produto);

        public Task<bool> Excluir(long id); 
    }
}
