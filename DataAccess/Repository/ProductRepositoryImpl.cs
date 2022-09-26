using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private FStoreContext _context;

        public ProductRepositoryImpl(FStoreContext context)
        {
            _context = context;
        }

        public int Create(Product Product)
        {
            _context.Add(Product);
            return _context.SaveChanges();
        }

        public int Delete(Product Product)
        {
            _context.Remove(Product);
            return _context.SaveChanges();
        }

        public List<Product> ReadAll()
        {
            return _context.Products.ToList();
        }

        public int Update(int id, Product Product)
        {
            Product.ProductId = id;
            _context.Update(Product);
            return _context.SaveChanges();
        }



    }
}
