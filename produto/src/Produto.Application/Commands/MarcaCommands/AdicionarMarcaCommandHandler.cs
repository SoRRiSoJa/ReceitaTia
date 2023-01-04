using AutoMapper;
using MediatR;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.Marca
{
    public class AdicionarMarcaCommandHandler : IRequestHandler<AdcionarMarcaCommand, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMarcaRepository _marcaRepository;
        public AdicionarMarcaCommandHandler(IMediator _mediator, IMapper _mapper, IMarcaRepository _marcaRepository)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<Guid> Handle(AdcionarMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = _mapper.Map<Produtos.Domain.Entities.Marca>(request);
            var idMarca = await _marcaRepository.Inserir(marca);
            return idMarca;
        }
    }
}
