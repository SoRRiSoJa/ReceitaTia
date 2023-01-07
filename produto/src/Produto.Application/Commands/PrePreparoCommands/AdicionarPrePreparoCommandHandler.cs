using AutoMapper;
using MediatR;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.PrePreparoCommands
{
    public class AdicionarPrePreparoCommandHandler : IRequestHandler<AdicionarPrePreparoCommand, Guid>
    {
        private readonly IPrePreparoRepository _prePreparoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPrePreparoCommandHandler(IPrePreparoRepository _prePreparoRepository, IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            this._prePreparoRepository = _prePreparoRepository ?? throw new ArgumentNullException(nameof(_prePreparoRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
        }
        public async Task<Guid> Handle(AdicionarPrePreparoCommand request, CancellationToken cancellationToken)
        {
            var prePreparo = _mapper.Map<Produtos.Domain.Entities.PrePreparo>(request);
            _unitOfWork.BeginTransaction();
            var idPrePreparo = await _prePreparoRepository.Inserir(prePreparo);
            _unitOfWork.Commit();
            return idPrePreparo;
        }
    }
}
