using AutoMapper;
using RP.Application.Querys;
using RP.Domain.Custom;
using RP.Domain.DTO.Product;
using RP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RP.Application.Querys.GetProductQuery;

namespace RP.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {


            CreateMap(typeof(PagedList<>), typeof(MetaData<>)).ConvertUsing(typeof(ConverterPaging<,>));

            /* Mapping queries and parameters. */
            CreateMap<GetAllProductQuery, GetAllProductParameter>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<CreateProductDTO, ProductDTO>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, ProductDTO>().ReverseMap();
            CreateMap<DeleteProductDTO, Product>().ReverseMap();
            CreateMap<DeleteProductDTO, ProductDTO>().ReverseMap();       



        }
            
    }
}
