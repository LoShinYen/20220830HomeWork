using SqlModels.Models;
using AutoMapper;
using SqlModels.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class ServicesMapper : Profile
    {
        public ServicesMapper()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductPrice, p => p.MapFrom(x => x.UnitPrice))
                .ForMember(d => d.ProductStock, p => p.MapFrom(x => x.UnitsInStock))
                .ForMember(d => d.CategoryID, p => p.MapFrom(x => x.Category.CategoryId))
                .ForMember(d => d.CategoryName, p => p.MapFrom(x => x.Category.CategoryName));
        }
    }
}
