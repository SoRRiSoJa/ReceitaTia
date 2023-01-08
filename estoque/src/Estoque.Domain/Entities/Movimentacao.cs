using Estoque.Domain.Enums;

namespace Estoque.Domain.Entities
{
    public class Movimentacao
    {
        public Guid MovimentacaoId { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal CustoUnitario { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public ENaturezaOperacao NaturezaOperacao{ get; set; }
    }
}
