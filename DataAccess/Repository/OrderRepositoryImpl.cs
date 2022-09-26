using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private FStoreContext _context;

        public OrderRepositoryImpl(FStoreContext context)
        {
            _context = context;
        }

        public int Create(Order Order)
        {
            _context.Add(Order);
            return _context.SaveChanges();
        }

        public int Delete(Order Order)
        {
            _context.Remove(Order);
            return _context.SaveChanges();
        }

        public List<Order> ReadAll()
        {
            return _context.Orders.ToList();
        }

        public int Update(int id, Order Order)
        {
            Order.OrderId = id;
            Order oldOrder = _context.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            oldOrder.OrderId = id;
            oldOrder.OrderDate = Order.OrderDate;
            oldOrder.MemberId = Order.MemberId;
            oldOrder.RequiredDate = Order.RequiredDate;
            oldOrder.ShippedDate = Order.ShippedDate;   
            oldOrder.Freight = Order.Freight;
            oldOrder.Member = _context.Members.Where(m => m.MemberId == Order.MemberId).FirstOrDefault();
            _context.Update(oldOrder);
            return _context.SaveChanges();
        }



    }
}
