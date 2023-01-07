using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Application.DTOs
{
    public class PrePreparosDto
    {
        public Guid PrePreparoId { get; set; } 
        public decimal Rendimento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produtos.Domain.Entities.Produto Produto { get; set; }
        public ICollection<ProdutoPrePreparo> Produtos { get; set; } = new List<ProdutoPrePreparo>();
    }
}
