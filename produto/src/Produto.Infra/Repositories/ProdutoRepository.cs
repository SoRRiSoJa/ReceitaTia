using Dapper;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Infra.Data;

namespace Produtos.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSession _session;
        public ProdutoRepository(DbSession _session)
        {
            this._session = _session ?? throw new ArgumentNullException(nameof(_session));
        }
        public Task<Produto> Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Inserir(Produto produto)
        {

            var query = @"INSERT INTO Produto(ProdutoId, Nome, Descricao, CEST, NCM, QtdItensContidos, CodigoBarras, Tipo, DataAlteracao, DataCadastro, Excluido,	MarcaId, UnidadeMedida) 
                                       VALUES(@ProdutoId, @Nome, @Descricao, @CEST, @NCM, @QtdItensContidos, @CodigoBarras, @Tipo, @DataAlteracao, @DataCadastro, @Excluido, @MarcaId, @UnidadeMedida)";
            var idProduto = Guid.NewGuid();
            var rows = await _session.Connection.ExecuteAsync(query, new
            {
                ProdutoId = idProduto,
                produto.Nome,
                produto.Descricao,
                produto.CEST,
                produto.NCM,
                produto.QtdItensContidos,
                produto.CodigoBarras,
                produto.Tipo,
                DataAlteracao = DateTime.Now,
                DataCadastro = DateTime.Now,
                Excluido = false,
                produto.MarcaId,
                produto.UnidadeMedida
            }, _session.Transaction);
            return rows > 0 ? idProduto : Guid.Empty;
        }
        public async Task<Produto> Obter(long id)
        {
            var query = @"SELECT * FROM Produto P WHERE P.ProdutoId = @id";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Produto>(query, new { id });
            return result;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var query = @"SELECT * FROM Produto P left join Marca M on P.MarcaId=m.MarcaId";
            var result = await _session.Connection.QueryAsync<Produto>(query, null, _session.Transaction);
            return result;
        }
    }
}
