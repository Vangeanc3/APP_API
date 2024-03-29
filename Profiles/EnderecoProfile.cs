﻿using APP_API.Data.Dtos.EnderecoDto;
using APP_API.Data.Dtos.LinhaDto;
using APP_API.Models;
using AutoMapper;

namespace APP_API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<PutEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>()
                .ForMember(e => e.Usuario, opts => opts
                .MapFrom(e => new { e.Usuario.Nome, e.Usuario.Role, e.Usuario.Email }));
        }
    }
}
