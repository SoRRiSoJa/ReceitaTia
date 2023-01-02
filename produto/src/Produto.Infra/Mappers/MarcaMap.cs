using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public class MarcaMap : DommelEntityMap<Marca>
    {
        public MarcaMap()
        {
            ToTable("Marca");
            Map((marca) => (marca).MarcaId).ToColumn("").IsKey();
            Map((marca) => (marca).Nome).ToColumn("Nome");
            Map((marca) => (marca).DataAlteracao).ToColumn("DataAlteracao");
            Map((marca) => (marca).DataCadastro).ToColumn("DataCadastro");
            Map((marca) => (marca).Excluido).ToColumn("Excluido");
        }
    }
}
