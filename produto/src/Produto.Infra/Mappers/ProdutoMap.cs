using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public  class ProdutoMap : DommelEntityMap<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            Map((produto) => (produto).ProdutoId).ToColumn("ProdutoId").IsKey();
            Map((produto) => (produto).Nome).ToColumn("Nome");
            Map((produto) => (produto).Descricao).ToColumn("Descricao");
            Map((produto) => (produto).CEST).ToColumn("CEST");
            Map((produto) => (produto).NCM).ToColumn("NCM");
            Map((produto) => (produto).QtdItensContidos).ToColumn("QtdItensContidos");
            Map((produto) => (produto).CodigoBarras).ToColumn("CodigoBarras");
            Map((produto) => (produto).Tipo).ToColumn("Tipo");
            Map((produto) => (produto).DataAlteracao).ToColumn("DataAlteracao");
            Map((produto) => (produto).DataCadastro).ToColumn("DataCadastro");
            Map((produto) => (produto).Excluido).ToColumn("Excluido");
            Map((produto) => (produto).MarcaId).ToColumn("MarcaId");
            Map((produto) => (produto).UnidadeMedida).ToColumn("UnidadeMedida");
        }
    }
}
