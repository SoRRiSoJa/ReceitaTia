using Produtos.Domain.Abstractions;

namespace Produtos.Domain.Entities
{
    public class Marca : Entity
    {
        public Guid MarcaId { get; set; }
        public string Nome { get; set; }
    }
}
