using AutoMapper;
using Produto.Application.Commands.ProdutoCommands;
using Produto.Application.DTOs;

namespace Produto.Application.Mappers
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produtos.Domain.Entities.Produto, ProdutosDto>().ReverseMap();
            CreateMap<AdcionarProdutoCommand, Produtos.Domain.Entities.Produto>().ReverseMap();
        }
    }
}
