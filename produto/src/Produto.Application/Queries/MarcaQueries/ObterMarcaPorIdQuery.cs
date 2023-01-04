using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.MarcaQueries
{
    public class ObterMarcaPorIdQuery : IRequest<MarcasDto>
    {
        public Guid MarcaId { get; set; }
    }
}
