using Produtos.Domain.Abstractions;

namespace Produtos.Domain.Entities
{
    public class PrePreparo : Entity
    {
        public Guid PrePreparoId { get; set; } = new Guid();
        public decimal Rendimento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; } = new Produto();
        public ICollection<ProdutoPrePreparo> Produtos { get; set; } = new List<ProdutoPrePreparo>();

    }
}
