using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        public Product(int productId, int categoryId, string productName, string weight, decimal unitPrice, int unitInStock)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitInStock = unitInStock;
        }

        public Product(int productId, int categoryId, string productName, string weight, decimal unitPrice, int unitInStock, ICollection<OrderDetail> orderDetails)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitInStock = unitInStock;
            OrderDetails = orderDetails;
        }

        public Product(int categoryId, string productName, string weight, decimal unitPrice, int unitInStock, ICollection<OrderDetail> orderDetails)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitInStock = unitInStock;
            OrderDetails = orderDetails;
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
