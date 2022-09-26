using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepositoryImpl : IOrderDetailRepository
    {
        private FStoreContext _context;

        public OrderDetailRepositoryImpl(FStoreContext context)
        {
            _context = context;
        }

        public int Create(OrderDetail OrderDetail)
        {
            _context.Add(OrderDetail);
            return _context.SaveChanges();
        }

        public int Delete(OrderDetail OrderDetail)
        {
            _context.Remove(OrderDetail);
            return _context.SaveChanges();
        }

        public List<OrderDetail> ReadAll()
        {
            return _context.OrderDetails.ToList();
        }

        public int ReadAll(OrderDetail member)
        {
            throw new NotImplementedException();
        }

        public int Update(int OrderId, int ProductId, OrderDetail OrderDetail)
        {
            OrderDetail.ProductId = ProductId;
            OrderDetail.OrderId = OrderId;
            _context.Update(OrderDetail);
            return _context.SaveChanges();
        }

    
    }
}
