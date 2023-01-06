using Produtos.Domain.Entities;

namespace Produtos.Domain.Repositories
{
    public interface IPrePreparoRepository
    {
        public Task<PrePreparo> Obter(Guid id);
        public Task<IEnumerable<PrePreparo>> ObterTodos(Guid? prePreparo);
        public Task<Guid> Inserir(PrePreparo prePreparo);
        public Task<PrePreparo> Atualizar(PrePreparo prePreparo);
        public Task<bool> Excluir(Guid id);
    }
}
