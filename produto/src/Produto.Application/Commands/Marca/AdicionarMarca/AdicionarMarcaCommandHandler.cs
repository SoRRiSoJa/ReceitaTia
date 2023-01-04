using MediatR;

namespace Produto.Application.Commands.Marca.AdicionarMarca
{
    public class AdicionarMarcaCommandHandler : IRequestHandler<AdicionarMarcaCommand, Guid>
    {
        private readonly IMediator _mediator;
        public AdicionarMarcaCommandHandler(IMediator _mediator)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }
        
        public Task<Guid> Handle(AdicionarMarcaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
