using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Data.Dtos.PedidoDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CreatePedidoDto, Pedido>();
            CreateMap<PutPedidoDto, Pedido>();
            CreateMap<Pedido, ReadPedidoDto>();
        }
    }
}
