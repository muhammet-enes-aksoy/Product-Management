using AutoMapper;
using ProductManagement.Common;
using ProductManagement.ProductOperations.Command.CreateProduct;
using ProductManagement.Entities;
using Microsoft.AspNetCore.JsonPatch;
using ProductManagement.ProductOperations.Query;
using ProductManagement.ProductOperations.Command.UpdateProduct;
using ProductManagement.ProductOperations.Command.PatchProduct;
namespace Customer_management.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductsViewModel>().ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => ((Category)src.CategoryId).ToString()));

        CreateMap<Product, GetProductViewModel>()
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => ((Category)src.CategoryId).ToString()));


        CreateMap<CreateProductModel, Product>()
            .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.Category));

        CreateMap<UpdateProductModel, Product>()
            .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(src => ((Category)src.CategoryId).ToString()));

        CreateMap<JsonPatchDocument<PatchProductModel>, PatchProductModel>().ForAllMembers(opt => opt.Ignore());
    }
}