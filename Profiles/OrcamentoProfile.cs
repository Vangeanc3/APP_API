using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP_API.Data.Dtos.OrcamentoDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class OrcamentoProfile : Profile
    {
        public OrcamentoProfile()
        {
            CreateMap<CreateOrcamentoDto, Orcamento>();
            CreateMap<PutOrcamentoDto, Orcamento>();
            CreateMap<Orcamento, ReadOrcamentoDto>()
                .ForMember(o => o.Instalador, opts => opts
                .MapFrom(o => new { o.Instalador.Nome, o.Instalador.Email }))
                .ForMember(o => o.DetalhesOrcamentos, opts => opts
                .MapFrom(o => o.DetalhesOrcamentos
                .Select(de => new { de.Produto.Nome, de.QuantProdutos })));
        }
    }
}