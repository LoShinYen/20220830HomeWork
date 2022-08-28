using SqlModels.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductService
    {
        public List<ProductDTO> ProductList();
        public ProductItemDTO EditProduct(int id);
        public ChangeResponseDTO CreateProduct(ProductVM.ProductDato model);
        public ChangeResponseDTO EditProduct(ProductVM model);
        public ChangeResponseDTO DeleteProduct(int id);
    }
}
