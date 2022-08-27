using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class ProductVM
    {
        public List<ProductDato> ProductList { get; set; }
        public class ProductDato {
            [Display(Name ="產品ID")]
            public int ProductId { get; set; }
            [Display(Name = "產品名稱")]
            public string ProductName { get; set; }
            [Display(Name = "產品價格")]
            public decimal? ProductPrice { get; set; }
            [Display(Name = "產品庫存數")]
            public int ProductStock { get; set; }
            [Display(Name = "產品類別ID")]
            public int CategoryID { get; set; }
            [Display(Name = "產品類別")]
            public string CategoryName { get; set; }
        } 

    }
}
