using Dapper;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Infra.Data;

namespace Produtos.Infra.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DbSession _session;
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
            var query = @"update marca set Excluido=true where marcaid=@id";
            var rows = await _session.Connection.ExecuteAsync(query, new { id }, _session.Transaction);
            return rows > 0;
        }

        public async Task<Guid> Inserir(Marca marca)
        {
            var query = @"INSERT INTO marca(marcaid,nome,dataalteracao,datacadastro,excluido) VALUES(@marcaid, @nome, @dataalteracao ,@datacadastro, @excluido)";
            var idMarca = Guid.NewGuid();
            var rows = await _session.Connection.ExecuteAsync(query, new { MarcaId = idMarca, marca.Nome, DataAlteracao = DateTime.Now, DataCadastro = DateTime.Now, Excluido = false }, _session.Transaction);
            return rows > 0 ? idMarca : Guid.Empty;
        }

        public async Task<Marca> Obter(Guid id)
        {
            var query = @"SELECT * FROM marca M WHERE M.marcaid = @id";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Marca>(query, new { id });
            return result;
        }

        public async Task<IEnumerable<Marca>> ObterTodos()
        {
            var query = @"SELECT * FROM marca";
            var result = await _session.Connection.QueryAsync<Marca>(query, null, _session.Transaction);
            return result;
        }
    }
}
