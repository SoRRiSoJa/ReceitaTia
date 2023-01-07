using MediatR;
using Produtos.Domain.Entities;

namespace Produto.Application.Commands.PrePreparoCommands
{
    public class AdicionarPrePreparoCommand : IRequest<Guid>
    {
        public decimal Rendimento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produtos.Domain.Entities.Produto Produto { get; set; }
        public IEnumerable<ProdutoPrePreparo> Produtos { get; set; } = new List<ProdutoPrePreparo>();
    }
}
