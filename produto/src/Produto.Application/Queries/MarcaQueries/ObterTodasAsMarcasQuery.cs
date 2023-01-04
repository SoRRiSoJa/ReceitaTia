using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.MarcaQueries
{
    public class ObterTodasAsMarcasQuery : IRequest<List<MarcasDto>>
    {
    }
}
