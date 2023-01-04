using MediatR;

namespace Produto.Application.Commands.Marca
{
    public class AdcionarMarcaCommand : IRequest<Guid>
    {
        public string Nome { get; set; } = "";
    }
}
