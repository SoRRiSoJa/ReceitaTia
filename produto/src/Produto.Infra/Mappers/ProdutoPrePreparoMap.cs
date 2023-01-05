using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public class ProdutoPrePreparoMap : DommelEntityMap<ProdutoPrePreparo>
    {
        public ProdutoPrePreparoMap()
        {
            ToTable("produtoprepreparo");
            Map((produtoprepreparo) => (produtoprepreparo).ProdutoPrePreparoId).ToColumn("produtoprepreparoid").IsKey();
            Map((produtoprepreparo) => (produtoprepreparo).ProdutoId).ToColumn("produtoid");
            Map((produtoprepreparo) => (produtoprepreparo).Quantidade).ToColumn("quantidade");
            Map((produtoprepreparo) => (produtoprepreparo).DataAlteracao).ToColumn("dataalteracao");
            Map((produtoprepreparo) => (produtoprepreparo).DataCadastro).ToColumn("datacadastro");
            Map((produtoprepreparo) => (produtoprepreparo).Excluido).ToColumn("excluido");
            Map((produtoprepreparo) => (produtoprepreparo).UnidadeMedida).ToColumn("unidademedida");
        }
    }
}
