using AutoMapper;
using Produto.Application.Commands.PrePreparoCommands;
using Produto.Application.DTOs;
using Produtos.Domain.Entities;

namespace Produto.Application.Mappers
{
    public class PrePreparoMapper : Profile
    {
        public PrePreparoMapper()
        {
            CreateMap<PrePreparo,AdicionarPrePreparoCommand>().ReverseMap();
            CreateMap<PrePreparo, PrePreparosDto>().ReverseMap();
            //TODO:Criar os comandos de atualização e exclusão
            //CreateMap<Domain.Entities.PrePreparo, Commands.PrePreparoCommands.AtualizarPrePreparoCommand>()
            //    .ReverseMap();
            //CreateMap<Domain.Entities.PrePreparo, Commands.PrePreparoCommands.ExcluirPrePreparoCommand>()
            //    .ReverseMap();
            //CreateMap<Domain.Entities.PrePreparo, Queries.PrePreparoQueries.ObterPrePreparoQuery>()
            //    .ReverseMap();
            //CreateMap<Domain.Entities.PrePreparo, Queries.PrePreparoQueries.ObterTodosPrePreparoQuery>()
            //    .ReverseMap();
        }
    }
}
