using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories
{
    internal interface IFichaTecnicaRepository
    {
        public Task<FichaTecnica> Obter(Guid id);
        public Task<IEnumerable<FichaTecnica>> ObterTodos(Guid? fichaTecnica);
        public Task<Guid> Inserir(FichaTecnica fichaTecnica);
        public Task<FichaTecnica> Atualizar(FichaTecnica fichaTecnica);
        public Task<bool> Excluir(Guid id);
    }
}
