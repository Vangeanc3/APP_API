using APP_API.Data.Dtos.LinhaDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class LinhaProfile : Profile
    {
        public LinhaProfile()
        {
            CreateMap<CreateLinhaDto, Linha>();
            CreateMap<Linha, ReadLinhaDto>();
        }
    }
}
