using MediatR;

namespace Produto.Application.Commands.Marca.AdicionarMarca
{
    public class AdicionarMarcaCommand : IRequest<Guid>
    {
        public string Nome { get; set; } = "";
    }
}
