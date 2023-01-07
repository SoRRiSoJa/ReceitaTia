using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.PrePreparoQueries
{
    public class ObterPrePreparoPorId : IRequest<PrePreparosDto>
    {
        public Guid PrePreparoId { get; set; }
    }
}
