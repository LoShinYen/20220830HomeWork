using SqlModels.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public List<ProductDTO> ProductList()
        {
            //var productList = Repostiory.GetAll<Product>().Include(x => x.Category).Select(item => new ProductDTO
            //{ 
            //    ProductId = item.ProductId,
            //    ProductName = item.ProductName,
            //    CategoryID = item.Category.CategoryId,
            //    CategoryName = item.Category.CategoryName,
            //    ProductPrice = item.UnitPrice,
            //    ProductStock = (int)item.UnitsInStock
            //}).ToList();
            var productList = Repostiory.GetAll<Product>().ProjectToList<ProductDTO>(Mapper.ConfigurationProvider);

            return productList;
        }


    }
}
