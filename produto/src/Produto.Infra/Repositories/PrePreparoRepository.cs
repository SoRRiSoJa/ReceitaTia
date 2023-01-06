using Dapper;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.Repositories
{
    public class PrePreparoRepository : IPrePreparoRepository
    {
        private readonly DbSession _session;
        public PrePreparoRepository(DbSession _session)
        {
            this._session = _session ?? throw new ArgumentNullException(nameof(_session));
        }
        public Task<PrePreparo> Atualizar(PrePreparo prePreparo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Inserir(PrePreparo prePreparo)
        {
            var query = @"INSERT INTO public.prepreparo(prepreparoid, produtoid, rendimento, dataalteracao, datacadastro, excluido) VALUES(@prepreparoid, @produtoid, @rendimento, @dataalteracao, @datacadastro, @excluido);";
            var prePreparoId = prePreparo.PrePreparoId;
            var rows = await _session.Connection.ExecuteAsync(query, new
            {
                prePreparo.PrePreparoId,
                prePreparo.Rendimento,
                prePreparo.ProdutoId,
                DataAlteracao = DateTime.Now,
                DataCadastro = DateTime.Now,
                Excluido = false
            }, _session.Transaction);

            int rowprod = await InserirProdutosDoPrePreparo(prePreparo);

            return (rows > 0 && rowprod > 0) ? prePreparoId : Guid.Empty;
        }

        public Task<PrePreparo> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PrePreparo>> ObterTodos(Guid? prePreparo)
        {
            throw new NotImplementedException();
        }
        private async Task<int> InserirProdutosDoPrePreparo(PrePreparo prePreparo)
        {
            var queryProdutos = @"INSERT INTO public.produtoprepreparo(produtoprepreparoid, produtoid, quantidade, dataalteracao, datacadastro, excluido, unidademedida)
                                                                VALUES(@produtoprepreparoid, @produtoid, @quantidade, @dataalteracao, @datacadastro, @excluido, @unidademedida);";

            var parametros = MontarParametrosInsertListaProdutos(prePreparo);
            var rowprod = await _session.Connection.ExecuteAsync(queryProdutos, parametros, _session.Transaction);

            int rowprodlig = await InserTabelaLigacaoProdutoPrePreparo(prePreparo);

            return (rowprod > 0 && rowprodlig > 0) ? 1 : 0;
        }

        private async Task<int> InserTabelaLigacaoProdutoPrePreparo(PrePreparo prePreparo)
        {
            var queryLigacao = @"INSERT INTO public.prepreparo_produtoprepreparo(prepreparoprodutoprepreparoid, prepreparoid, produtoprepreparoid) 
                                                                          VALUES(@prepreparoprodutoprepreparoid, @prepreparoid, @produtoprepreparoid);";
            var parametrosLIgacao = MontarParametrosInsertListaLigacaoProdutos(prePreparo);
            var rowprodlig = await _session.Connection.ExecuteAsync(queryLigacao, parametrosLIgacao, _session.Transaction);
            return rowprodlig;
        }

        private static IEnumerable<DynamicParameters> MontarParametrosInsertListaLigacaoProdutos(PrePreparo prePreparo)
        {
            return prePreparo.Produtos.Select(pro =>
            {
                var tempParams = new DynamicParameters();
                tempParams.Add("@prepreparoprodutoprepreparoid", Guid.NewGuid(), DbType.Guid, ParameterDirection.Input);
                tempParams.Add("@prepreparoid", prePreparo.PrePreparoId, DbType.Guid, ParameterDirection.Input);
                tempParams.Add("@produtoprepreparoid", pro.ProdutoPrePreparoId, DbType.Guid, ParameterDirection.Input);
                return tempParams;
            });
        }
        private static IEnumerable<DynamicParameters> MontarParametrosInsertListaProdutos(PrePreparo prePreparo)
        {
            return prePreparo.Produtos.Select(pro =>
            {
                var tempParams = new DynamicParameters();
                tempParams.Add("@produtoprepreparoid", pro.ProdutoPrePreparoId, DbType.Guid, ParameterDirection.Input);
                tempParams.Add("@produtoid", pro.ProdutoId, DbType.Guid, ParameterDirection.Input);
                tempParams.Add("@quantidade", pro.Quantidade, DbType.Decimal, ParameterDirection.Input);
                tempParams.Add("@dataalteracao", DateTime.Now, DbType.DateTime2, ParameterDirection.Input);
                tempParams.Add("@datacadastro", DateTime.Now, DbType.DateTime2, ParameterDirection.Input);
                tempParams.Add("@excluido", false, DbType.Boolean, ParameterDirection.Input);
                tempParams.Add("@unidademedida", pro.UnidadeMedida, DbType.Int16, ParameterDirection.Input);
                return tempParams;
            });
        }
    }
}
