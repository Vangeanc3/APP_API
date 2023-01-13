using APP_API.Data.Dtos.UsuarioDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            //CreateMap<LogarUsuarioDto, Usuario>();
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
