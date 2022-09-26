using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class OrderManagement
    {
        IOrderRepository orderRepository;

        public OrderManagement(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // > 0 asc ; < 0 desc
        public List<Order> reportSalesByDate(DateTime startDate, DateTime endDate, int orderBy)
        {
            return null;
        }
        public int delete(Order order)
        {
            return orderRepository.Delete(order);
        }
        public int update(int id, Order order)
        {
            return orderRepository.Update(id,order);
        }
        public List<Order> getAll()
        {
            return orderRepository.ReadAll();
        }
        public int add(Order order)
        {
            return orderRepository.Create(order);   
        }
    }
}
