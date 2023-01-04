using Dapper.FluentMap.Dommel.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappers
{
    public  class ProdutoMap : DommelEntityMap<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            Map((produto) => (produto).ProdutoId).ToColumn("produtoid").IsKey();
            Map((produto) => (produto).Nome).ToColumn("nome");
            Map((produto) => (produto).Descricao).ToColumn("descricao");
            Map((produto) => (produto).CEST).ToColumn("cest");
            Map((produto) => (produto).NCM).ToColumn("ncm");
            Map((produto) => (produto).QtdItensContidos).ToColumn("qtditenscontidos");
            Map((produto) => (produto).CodigoBarras).ToColumn("codigobarras");
            Map((produto) => (produto).Tipo).ToColumn("tipo");
            Map((produto) => (produto).DataAlteracao).ToColumn("dataalteracao");
            Map((produto) => (produto).DataCadastro).ToColumn("datacadastro");
            Map((produto) => (produto).Excluido).ToColumn("excluido");
            Map((produto) => (produto).MarcaId).ToColumn("marcaid");
            Map((produto) => (produto).UnidadeMedida).ToColumn("unidademedida");
        }
    }
}
