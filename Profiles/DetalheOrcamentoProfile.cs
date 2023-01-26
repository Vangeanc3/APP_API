using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP_API.Data.Dtos.DetalheOrcamentoDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class DetalheOrcamentoProfile : Profile
    {
        public DetalheOrcamentoProfile()
        {
            CreateMap<DetalheOrcamento, ReadDetalheOrcamentoDto>();
        }
    }
}