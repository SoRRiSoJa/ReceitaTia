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

        public async Task<bool> Excluir(long id)
        {
            var query = @"update Marca set Excluido=true where MarcaId=@id";
            var rows = await _session.Connection.ExecuteAsync(query, new { id }, _session.Transaction);
            return rows > 0;
        }

        public async Task<Guid> Inserir(Marca marca)
        {
            var query = @"INSERT INTO Marca(MarcaId,Nome,DataAlteracao,DataCadastro,Excluido) VALUES(@MarcaId, @Nome, @DataAlteracao ,@DataCadastro, @Excluido)";
            var idMarca = Guid.NewGuid();
            var rows = await _session.Connection.ExecuteAsync(query, new { MarcaId = idMarca, marca.Nome, DataAlteracao = DateTime.Now, DataCadastro = DateTime.Now, Excluido = false }, _session.Transaction);
            return rows > 0 ? idMarca : Guid.Empty;
        }

        public async Task<Marca> Obter(Guid id)
        {
            var query = @"SELECT * FROM Marca M WHERE M.MarcaId = @id";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Marca>(query, new { id });
            return result;
        }

        public async Task<IEnumerable<Marca>> ObterTodos()
        {
            var query = @"SELECT * FROM Marca";
            var result = await _session.Connection.QueryAsync<Marca>(query, null, _session.Transaction);
            return result;
        }
    }
}
