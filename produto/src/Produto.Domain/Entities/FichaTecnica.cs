using Produtos.Domain.Abstractions;

namespace Produtos.Domain.Entities
{
    public class FichaTecnica : Entity
    {
        public Guid FichaTecnicaId { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public ICollection<ProdutoFichaTecnica> Produtos { get; set; }
    }
}
