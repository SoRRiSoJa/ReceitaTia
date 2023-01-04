using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories
{
    public interface IMarcaRepository
    {
        public Task<Marca> Obter(Guid id);
        public Task<IEnumerable<Marca>> ObterTodos();
        public Task<Guid> Inserir(Marca marca);
        public Task<Marca> Atualizar(Marca marca);

        public Task<bool> Excluir(long id);

    }
}
