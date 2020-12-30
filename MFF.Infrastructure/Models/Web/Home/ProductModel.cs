using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Infrastructure.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Products = new List<ProductItemModel>();
        }
        public List<ProductItemModel> Products { get; set; }
    }
    public class ProductItemModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
        public decimal Quanlity { get; set; }
    }
}
