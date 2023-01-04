using Produtos.Domain.Entities;
using Produtos.Domain.Enums;

namespace Produto.Application.DTOs
{
    public class ProdutosDto
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string CEST { get; set; } = "";
        public string NCM { get; set; } = "";
        public int QtdItensContidos { get; set; }
        public string CodigoBarras { get; set; } = "";
        public Guid? MarcaId { get; set; }
        public Marca Marca { get; set; }
        public ETipoProduto Tipo { get; set; }
        public EUnidadeMedida UnidadeMedida { get; set; }
    }
}
