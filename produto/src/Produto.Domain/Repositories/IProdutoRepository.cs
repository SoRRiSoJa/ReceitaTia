using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        public Task<Produto> Obter(Guid id);
        public Task<IEnumerable<Produto>> ObterTodos(Guid? produto);
        public Task<Guid> Inserir(Produto produto);
        public Task<Produto> Atualizar(Produto produto);
        public Task<bool> Excluir(Guid id);
    }
}
