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
            CreateMap<PutLinhaDto, Linha>();
            CreateMap<Linha, ReadLinhaDto>()
                .ForMember(l => l.Produtos, opts => opts
                .MapFrom(l => l.Produtos
                .Select(p => new { p.Nome, p.Descricao, p.PrecoParceiro, p.PrecoCliente, p.LinkImg, p.LinkPdfManual, p.QuantEstoque})));
        }
    }
}
