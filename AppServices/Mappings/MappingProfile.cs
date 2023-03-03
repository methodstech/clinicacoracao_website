// ----------------------------------------------------------------------------
// AppServices.MappingProfile.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using AppServices.Dtos;
using AppServices.Filters;
using AutoMapper;
using Domain.Entities;
using Domain.Filters;

namespace AppServices.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<UsuarioFilterDto, UsuarioFilter>().ReverseMap();

            CreateMap<RitmoDto, Ritmo>().ReverseMap();
            CreateMap<RitmoFilterDto, RitmoFilter>().ReverseMap();

            CreateMap<MedicoDto, Medico>().ReverseMap();
            CreateMap<MedicoFilterDto, MedicoFilter>().ReverseMap();

            CreateMap<ConclusaoDto, Conclusao>().ReverseMap();
            CreateMap<ConclusaoFilterDto, ConclusaoFilter>().ReverseMap();

            CreateMap<ConvenioDto, Convenio>().ReverseMap();
            CreateMap<ConvenioFilterDto, ConvenioFilter>().ReverseMap();

            CreateMap<PacienteDto, Paciente>().ReverseMap();
            CreateMap<PacienteFilterDto, PacienteFilter>().ReverseMap();

            CreateMap<LaudoDto, Laudo>().ReverseMap();
            CreateMap<LaudoFilterDto, LaudoFilter>().ReverseMap();

            CreateMap<RelatorioHistoricoPacienteDto, RelatorioHistoricoPaciente>().ReverseMap();
            CreateMap<RelatorioHistoricoPacienteFilterDto, RelatorioHistoricoPacienteFilter>().ReverseMap();

            CreateMap<RelatorioRitmoConclusaoDto, RelatorioRitmoConclusao>().ReverseMap();
            CreateMap<RelatorioRitmoConclusaoFilterDto, RelatorioRitmoConclusaoFilter>().ReverseMap();

            CreateMap<RelatorioRitmoConclusaoDetalhesDto, RelatorioRitmoConclusaoDetalhes>().ReverseMap();

            CreateMap<BlogPostDto, BlogPost>().ReverseMap();
            CreateMap<BlogPostFilterDto, BlogPostFilter>().ReverseMap();
        }
    }
}
