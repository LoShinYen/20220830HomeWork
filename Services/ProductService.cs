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
            var product = Repostiory.GetAll<Product>().ProjectToList<ProductDTO>(Mapper.ConfigurationProvider);

            return product;
        }

        public ProductItemDTO EditProduct(int id)
        { 
            var product = Repostiory.FindBy<Product>(x=>x.ProductId == id).ProjectToSingleOrDefault<ProductItemDTO>(Mapper.ConfigurationProvider);

            return product;
        }

        public bool EditProduct(ProductVM model)
        {
            var data = model.EditProduct;
            var product = Repostiory.FindBy<Product>(x => x.ProductId == data.ProductId).FirstOrDefault();
            product.ProductName = data.ProductName;
            product.CategoryId = data.CategoryID;
            product.UnitsInStock = (short?)data.ProductStock;
            product.UnitPrice = data.ProductPrice;
            try
            {
                Update<Product>(product);
                return true;
            }
            catch (Exception ex)
            { 
                return false ;
            }

        }



    }
}
