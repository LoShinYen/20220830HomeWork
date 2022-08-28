using AutoMapper;
using SqlModels.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlModels.DTOModels.ProductVM;

namespace Services.Mappers
{
    public class ControllerMapper : Profile
    {
        public ControllerMapper()
        {
            CreateMap<ProductDTO, ProductDato>();
            CreateMap<ProductItemDTO, ProductDato>();
        }

    }
}
