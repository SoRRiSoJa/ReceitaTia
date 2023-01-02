using Dapper;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Infra.Data;

namespace Produtos.Infra.Repositories
{
    internal class MarcaRepository : IMarcaRepository
    {
        private DbSession _session;
        public MarcaRepository(DbSession _session)
        {
            this._session = _session ?? throw new ArgumentNullException(nameof(_session));
        }
        public Task<Marca> Atualizar(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Inserir(Marca marca)
        {
            var query = @"INSERT INTO Marca(MarcaId,Nome,DataAlteracao,DataCadastro,Excluido) VALUES(@MarcaId, @Nome, @DataAlteracao ,@DataCadastro, @Excluido)";
            var idMarca = Guid.NewGuid();
            _ = await _session.Connection.ExecuteAsync(query, new { MarcaId = idMarca, marca.Nome, DataAlteracao = DateTime.Now, DataCadastro = DateTime.Now, Excluido = false }, _session.Transaction);
            return idMarca;
        }

        public Task<Marca> Obter(Guid id)
        {
            var query = @"SELECT * FROM Marca M
                                           WHERE M.MarcaId = @id";
            var result = _session.Connection.QuerySingleAsync<Marca>(query, new { id });
            return result;
        }

        public Task<IEnumerable<Marca>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
