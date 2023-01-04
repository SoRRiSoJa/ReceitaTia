using MediatR;
using Produto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Application.Queries.MarcaQueries
{
    public class ObterTodasAsMarcasQuery : IRequest<List<MarcasDto>>
    {
        public Guid MarcaId { get; set; }
        public string Nome { get; set; }
    }
}
