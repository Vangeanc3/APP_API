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
            CreateMap<Pedido, ReadPedidoDto>()
                .ForMember(p => p.Instalador, opts => opts
                .MapFrom(p => new { p.Instalador.Nome, p.Instalador.Email }))
                .ForMember(p => p.DetalhePedidos, opts => opts
                .MapFrom(p => p.DetalhePedidos
                .Select(dp => new { dp.Produto.Nome, dp.QuantProduto })));
        }
    }
}
