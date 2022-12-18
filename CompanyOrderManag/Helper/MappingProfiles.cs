using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Models;
using System.Diagnostics.Metrics;

// An AutoMapper to creat methods

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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
