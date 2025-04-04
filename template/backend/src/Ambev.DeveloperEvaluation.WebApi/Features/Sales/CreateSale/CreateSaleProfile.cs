using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, Sale>()
                .ForMember(dest => dest.SaleNumber, opt => opt.MapFrom(src => GenerateSaleNumber()))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => false));

            CreateMap<CreateSaleItemRequest, SaleItem>();

            CreateMap<Sale, CreateSaleResponse>();
            CreateMap<SaleItem, CreateSaleItemResponse>();
        }

        private string GenerateSaleNumber()
        {
            return $"SALE-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
} 