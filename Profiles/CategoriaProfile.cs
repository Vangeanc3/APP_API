using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<PutCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadLinhaDto>();
        }
    }
}
