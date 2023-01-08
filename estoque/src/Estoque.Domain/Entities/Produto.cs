using Estoque.Domain.Abstractions;
using Estoque.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Produto:Entity
    {
        public Guid ProdutoId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CEST { get; set; }
        public string NCM { get; set; }
        public int QtdItensContidos { get; set; }
        public string CodigoBarras { get; set; }
        public Guid? MarcaId { get; set; }
        public Marca Marca { get; set; } = new();
        public ETipoProduto Tipo { get; set; }
        public EUnidadeMedida UnidadeMedida { get; set; }
    }
}
