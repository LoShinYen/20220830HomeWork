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

        public ChangeResponseDTO CreateProduct(ProductVM.ProductDato model)
        {
            var nameIsRepeat = Repostiory.FindBy<Product>(x => x.ProductName == model.ProductName).FirstOrDefault();
            
            if (nameIsRepeat != null)
            {
                return ResponseMsg(false, "產品名稱重複");
            }

            var categoryIsReat = Repostiory.FindBy<Category>(x => x.CategoryId == model.CategoryID).FirstOrDefault();
            if (categoryIsReat == null)
            {
                return ResponseMsg(false, "無此類別");
            }

            Product product = new Product() { 
                ProductName = model.ProductName,
                CategoryId = model.CategoryID,
                UnitPrice = model.ProductPrice,
                UnitsInStock = (short?)model.ProductStock,
            };

            try
            {
                Create<Product>(product);
                return ResponseMsg(true, "新增成功");
            }
            catch (Exception ex)
            {
                return ResponseMsg(false, $"{ex}");
            }

        }

        public ProductItemDTO EditProduct(int id)
        { 
            var product = Repostiory.FindBy<Product>(x=>x.ProductId == id).ProjectToSingleOrDefault<ProductItemDTO>(Mapper.ConfigurationProvider);

            return product;
        }

        public ChangeResponseDTO EditProduct(ProductVM model)
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
                return ResponseMsg(true, "更改成功");
            }
            catch (Exception ex)
            { 
                return ResponseMsg(false, $"{ex}"); 
            }
        }

        public ChangeResponseDTO DeleteProduct(int id)
        { 
            var product = Repostiory.FindBy<Product>(x=>x.ProductId == id).FirstOrDefault();
            try
            {
                Delete<Product>(product);
                return ResponseMsg(true, "成功刪除"); ;
            }
            catch (Exception ex)
            {
                return ResponseMsg(false, $"{ex}"); ;
            }
        }

        public ChangeResponseDTO ResponseMsg(bool isSuccess, string msg)
        {
            var result = new ChangeResponseDTO()
            {
                Success = isSuccess,
                msg = msg
            };
            return result;
        }
    }
}
