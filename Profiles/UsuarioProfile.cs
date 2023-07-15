using APP_API.Data.Dtos.UsuarioDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<PutUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>()
                .ForMember(u => u.Enderecos, opts => opts
                .MapFrom(u => u.Enderecos
                .Select(e => new { e.Cep, e.Bairro, e.Rua })));
        }
    }
}
