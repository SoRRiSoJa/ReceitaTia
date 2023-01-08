using Estoque.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Marca : Entity
    {
        public Guid MarcaId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
    }
}
