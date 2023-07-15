using APP_API.Data.Dtos.ProdutoDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, ReadProdutoDto>()
                .ForMember(p => p.Categoria, opts => opts
                .MapFrom(p => p.Categoria.Nome ))
                .ForMember(p => p.Linha, opts => opts
                .MapFrom(p => p.Linha.Nome));
        }
    }
}
