using APP_API.Data.Dtos.DetalhePedidoDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class DetalhePedidoProfile : Profile
    {
        public DetalhePedidoProfile()
        {
            CreateMap<DetalhePedido, ReadDetalhePedidoDto>();
        }
    }
}
