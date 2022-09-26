using BusinessObject.Models;

using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels;

namespace SalesWPFApp.ViewModels
{
    public class OrderManagementViewModel
    {
        public ICommand searchCommand { get; set; }
        OrderManagement orderManagement;
        public ICommand createCommand { get; set; }
        public ICommand updateCommand { get; set; }
        public ICommand deleteCommand { get; set; }

        public ObservableCollection<Order> orderList { get; set; }
        public OrderManagementViewModel(OrderManagement orderManagement)
        {
            this.orderManagement = orderManagement;

            orderList = new ObservableCollection<Order>();

            loadOrderList();
            loadCommand();


        }
        public void loadCommand()
        {
            searchCommand = new RelayCommand<Object>(p => true, p =>
            {


            });
            createCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                int MemberId = 0;
                DateTime Orderdate = DateTime.Now;
                DateTime RequiredDate = DateTime.Now;
                DateTime ShippedDate = DateTime.Now;
                decimal Freight = 0;
                Boolean isAllValid = true;
                try
                {
                    foreach (var i in p)
                    {
                        TextBox tb = i as TextBox;
                        if (tb != null)
                        {

                            switch (tb.Name)
                            {

                                case "MemberId":
                                    MemberId = Int32.Parse(tb.Text);
                                    break;
                                case "Orderdate":
                                    Orderdate = DateTime.Parse(tb.Text);
                                    break;
                                case "RequiredDate":
                                    RequiredDate = DateTime.Parse(tb.Text);
                                    break;
                                case "ShippedDate":
                                    ShippedDate = DateTime.Parse(tb.Text);
                                    break;
                                case "Freight":
                                    Freight = decimal.Parse(tb.Text);
                                    break;
                            }


                        }

                    }
                }
                catch (Exception ex)
                {
                    isAllValid = false;
                }
                if (isAllValid == true)
                {
                    orderManagement.add(new Order(MemberId,
                        Orderdate, RequiredDate, ShippedDate, Freight));
                    loadOrderList();
                }
                else
                    return;
            });
            updateCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                int OrderId = 0;
                int MemberId = 0;
                DateTime Orderdate = DateTime.Now;
                DateTime RequiredDate = DateTime.Now;
                DateTime ShippedDate = DateTime.Now;
                decimal Freight = 0;
                Boolean isAllValid = true;
                try
                {
                    foreach (var i in p)
                    {
                        TextBox tb = i as TextBox;
                        if (tb != null)
                        {

                            switch (tb.Name)
                            {
                                case "OrderId":
                                    OrderId = Int32.Parse(tb.Text);
                                    break;
                                case "MemberId":
                                    MemberId = Int32.Parse(tb.Text);
                                    break;
                                case "Orderdate":
                                    Orderdate = DateTime.Parse(tb.Text);
                                    break;
                                case "RequiredDate":
                                    RequiredDate = DateTime.Parse(tb.Text);
                                    break;
                                case "ShippedDate":
                                    ShippedDate = DateTime.Parse(tb.Text);
                                    break;
                                case "Freight":
                                    Freight = decimal.Parse(tb.Text);
                                    break;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    isAllValid = false;
                }
                if (isAllValid == true)
                {
                    orderManagement.update(OrderId, new Order(OrderId, MemberId,
                        Orderdate, RequiredDate, ShippedDate, Freight));
                    loadOrderList();
                }
                else
                    return;
            });
            deleteCommand = new RelayCommand<Object>(p => true, p =>
            {
                Order o = p as Order;
                if (o != null)
                {
                    orderManagement.delete(o);
                    loadOrderList();
                }
                else return;
            });
        }
        public void loadOrderList()
        {
            orderList.Clear();
            List<Order> orders = orderManagement.getAll();
            foreach (Order order in orders)
                orderList.Add(order);
        }
    }
}
