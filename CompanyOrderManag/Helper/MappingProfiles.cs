﻿using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Models;
using System.Diagnostics.Metrics;

namespace CompanyOrderManag.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
