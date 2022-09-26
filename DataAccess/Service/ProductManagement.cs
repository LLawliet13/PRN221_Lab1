using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductManagement
    {
        private IProductRepository ProductRepository;

        public ProductManagement(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public List<Product> searchProductByID(int id)
        {
            return null;
        }
        public List<Product> searchProductByName(string id)
        {
            return null;
        }
        public List<Product> searchProductByUnitPrice(decimal price)
        {
            return null;
        }
        public List<Product> searchProductByUnitInStock(int UnitInStock)
        {
            return null;
        }

        public int delete(Product Product)
        {
            return ProductRepository.Delete(Product);
        }
        public int update(int id, Product Product)
        {
            return ProductRepository.Update(id, Product);
        }
        public List<Product> getAll()
        {
            return ProductRepository.ReadAll();
        }
        public int add(Product Product)
        {
            return ProductRepository.Create(Product);
        }
    }
}
