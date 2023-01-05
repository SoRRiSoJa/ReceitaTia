using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public class PrePreparoMap : DommelEntityMap<PrePreparo>
    {
        public PrePreparoMap()
        {
            ToTable("prepreparo");
            Map((produtoprepreparo) => (produtoprepreparo).PrePreparoId).ToColumn("prepreparoid").IsKey();
            Map((produtoprepreparo) => (produtoprepreparo).ProdutoId).ToColumn("produtoid");
            Map((produtoprepreparo) => (produtoprepreparo).Reindimento).ToColumn("quantidade");
            Map((produtoprepreparo) => (produtoprepreparo).DataAlteracao).ToColumn("dataalteracao");
            Map((produtoprepreparo) => (produtoprepreparo).DataCadastro).ToColumn("datacadastro");
            Map((produtoprepreparo) => (produtoprepreparo).Excluido).ToColumn("excluido");
            
        }
    }
}
