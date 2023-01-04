using AutoMapper;
using FluentValidation;
using MediatR;
using Produtos.Domain.Repositories;
using System.Reflection;

namespace Produto.Application.Commands.Marca
{
    public class AdicionarMarcaCommandHandler : IRequestHandler<AdcionarMarcaCommand, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IValidator<AdcionarMarcaCommand> _validator;

        public AdicionarMarcaCommandHandler(IMediator _mediator,IValidator<AdcionarMarcaCommand> _validator, IMapper _mapper, IMarcaRepository _marcaRepository)
        {
            this._mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._validator = _validator ?? throw new ArgumentNullException(nameof(_validator));
        }
        public async Task<Guid> Handle(AdcionarMarcaCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var marca = _mapper.Map<Produtos.Domain.Entities.Marca>(request);
            var idMarca = await _marcaRepository.Inserir(marca);
            return idMarca;
        }
    }
}
