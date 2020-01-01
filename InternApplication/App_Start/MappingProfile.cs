using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InternApplication.Dtos;
using InternApplication.Models;

namespace InternApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Candidate, CandidateDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Application, ApplicationDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Race, RaceDto>();
            CreateMap<VeteranStatus, VeteranStatusDto>();


            // Dto to Domain
            CreateMap<CandidateDto, Candidate>()
                .ForMember(c => c.Email, opt => opt.Ignore());

            CreateMap<PositionDto, Position>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<DepartmentDto, Department>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<Gender, GenderDto>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<RaceDto, Race>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<VeteranStatusDto, VeteranStatus>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<ApplicationDto, Application>()
                .ForMember(p => p.Id, opt => opt.Ignore());

        }
    }
}