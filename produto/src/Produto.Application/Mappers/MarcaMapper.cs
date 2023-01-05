using AutoMapper;
using Produto.Application.Commands.Marca;
using Produto.Application.DTOs;
using Produtos.Domain.Entities;

namespace Produto.Application.Mappers
{
    public class MarcaMapper : Profile
    {
        public MarcaMapper()
        {
            CreateMap<Marca, MarcasDto>().ReverseMap();
            CreateMap<AdcionarMarcaCommand, Marca>().ReverseMap();
        }
    }


}
