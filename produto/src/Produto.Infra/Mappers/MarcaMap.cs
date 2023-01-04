using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public class MarcaMap : DommelEntityMap<Marca>
    {
        public MarcaMap()
        {
            ToTable("marca");
            Map((marca) => (marca).MarcaId).ToColumn("marcaid").IsKey();
            Map((marca) => (marca).Nome).ToColumn("nome");
            Map((marca) => (marca).DataAlteracao).ToColumn("dataalteracao");
            Map((marca) => (marca).DataCadastro).ToColumn("datacadastro");
            Map((marca) => (marca).Excluido).ToColumn("excluido");
        }
    }
}
