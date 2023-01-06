using Produtos.Domain.Abstractions;
using Produtos.Domain.Enums;

namespace Produtos.Domain.Entities
{
    public class ProdutoPrePreparo : Entity
    {
        public Guid ProdutoPrePreparoId { get; set; } = Guid.NewGuid();
        public Produto Produto { get; set; } = new Produto();
        public Guid ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public EUnidadeMedida UnidadeMedida { get; set; }

    }
}
