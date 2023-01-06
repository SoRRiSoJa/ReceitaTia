using Produtos.Domain.Abstractions;
using Produtos.Domain.Enums;

namespace Produtos.Domain.Entities
{
    public class ProdutoFichaTecnica : Entity
    {
        public Guid ProdutoFichaTecnicaId { get; set; }= Guid.NewGuid();
        public Produto Produto { get; set; } = new();
        public Produto ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public EUnidadeMedida UnidadeMedida { get; set; }
    }
}
