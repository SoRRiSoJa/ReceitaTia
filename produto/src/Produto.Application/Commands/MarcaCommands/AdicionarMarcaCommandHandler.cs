using MediatR;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.Marca
{
    public class AdicionarMarcaCommandHandler : IRequestHandler<AdcionarMarcaCommand, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IMarcaRepository _marcaRepository;
        public AdicionarMarcaCommandHandler(IMediator _mediator, IMarcaRepository _marcaRepository)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
        }
        public async Task<Guid> Handle(AdcionarMarcaCommand request, CancellationToken cancellationToken)
        {
            Produtos.Domain.Entities.Marca marca = new() { Nome = request.Nome };
            var idMarca = await _marcaRepository.Inserir(marca);
            return idMarca;
        }
    }
}
