namespace Produtos.Domain.Entities
{
    public class PrePreparoProdutoPrePreparo
    {
        public Guid PrePreparoProdutoPrePreparoId { get; set; } = new Guid();
        public Guid PrePreparoId { get; set; }
        public Guid ProdutoPrePreparoId { get; set; }
        
    }
}
