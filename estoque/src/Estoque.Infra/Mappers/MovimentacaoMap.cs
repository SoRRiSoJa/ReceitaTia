
using Dapper.FluentMap.Dommel.Mapping;
using Estoque.Domain.Entities;

namespace Estoque.Infra.Mappers
{
    public class MovimentacaoMap:DommelEntityMap<Movimentacao>
    {
        public MovimentacaoMap()
        {
            ToTable("movimentacao");
            Map((movimentacao) => (movimentacao).MovimentacaoId).ToColumn("movimentacaoid").IsKey();
            Map((movimentacao) => (movimentacao).Quantidade).ToColumn("quantidade");
            Map((movimentacao) => (movimentacao).CustoUnitario).ToColumn("custounitario");
            Map((movimentacao) => (movimentacao).DataMovimentacao).ToColumn("datamovimentacao");
            Map((movimentacao) => (movimentacao).UsuarioId).ToColumn("userid");
            Map((movimentacao) => (movimentacao).ProdutoId).ToColumn("produtoid");
            Map((movimentacao) => (movimentacao).Tipo).ToColumn("tipo");
            Map((movimentacao) => (movimentacao).NaturezaOperacao).ToColumn("naturezaoperacao");
        }
    }
}
