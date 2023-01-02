using Produtos.Domain.Abstractions;

namespace Produtos.Domain.Entities
{
    public class Marca : Entity
    {
        public Guid MarcaId { get; set; }
        public int Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
