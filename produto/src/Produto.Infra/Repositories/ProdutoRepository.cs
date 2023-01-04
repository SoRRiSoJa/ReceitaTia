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

        public  Task<Produtos.Domain.Entities.Produto> Atualizar(Produtos.Domain.Entities.Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Inserir(Produtos.Domain.Entities.Produto produto)
        {

            var query = @"INSERT INTO produto(produtoid, nome, descricao, cest, ncm, qtditenscontidos, codigobarras, tipo, dataalteracao, datacadastro, excluido, marcaId, unidademedida) 
                                       VALUES(@produtoid, @nome, @descricao, @cest, @ncm, @qtditenscontidos, @codigobarras, @tipo, @dataalteracao, @datacadastro, @excluido, @marcaId, @unidademedida)";
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
        public async Task<Produtos.Domain.Entities.Produto> Obter(Guid id)
        {
            var query = @"select * from produto pr left join marca ma on pr.marcaid = ma.marcaid where pr.produtoId = @id";

            var result = await _session.Connection.QueryAsync<Produtos.Domain.Entities.Produto, Marca, Produtos.Domain.Entities.Produto>(query, (produto, marca) => {
                produto.Marca = marca;
                return produto;
            }, splitOn: "marcaid", 
            param: new
            {
                id
            });
            return result.First();
        }

        public async Task<IEnumerable<Produtos.Domain.Entities.Produto>> ObterTodos(Guid? marcaid)
        {
            var query = @"select * from produto pr left join marca ma on pr.marcaid = ma.marcaid ";

            if (marcaid.HasValue)
            {
                query += "where pr.marcaid =@marcaid";
            }
            var result = await _session.Connection.QueryAsync<Produtos.Domain.Entities.Produto, Marca, Produtos.Domain.Entities.Produto>(query, (produto, marca) => {
                produto.Marca = marca;
                return produto;
            }, splitOn: "marcaid", 
            param: new
            {
                marcaid
            });
            return result;
        }
    }
}
