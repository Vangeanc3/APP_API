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
            CreateMap<Orcamento, ReadOrcamentoDto>();
        }
    }
}