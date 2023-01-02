using Produtos.Domain.Abstractions;

namespace Produtos.Domain.Entities
{
    public class PrePreparo : Entity
    {
        public Guid PrePreparoId { get; set; }
        public decimal Reindimento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public ICollection<ProdutoPrePreparo> Produtos { get; set; }

    }
}
