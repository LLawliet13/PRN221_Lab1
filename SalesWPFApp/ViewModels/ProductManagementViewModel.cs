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
    public class ProductManagementViewModel
    {
        public ICommand searchCommand { get; set; }
        public ICommand createCommand { get; set; }
        public ICommand updateCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        ProductManagement productManagement;
        public ObservableCollection<Product> productList { get; set; }
        public ProductManagementViewModel(ProductManagement productManagement)
        {

            this.productManagement = productManagement;
            productList = new ObservableCollection<Product>();

            loadProductList();
            loadCommand();
        }
        public void loadCommand()
        {
            searchCommand = new RelayCommand<Object>(p => true, p =>
            {


            });
            createCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                int productId = 0;
                int categoryId = 0;
                string ProductName = null;
                string Weight = null;
                decimal UnitPrice = 0;
                int unitInStock = 0;
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
                                    productId = Int32.Parse(tb.Text);
                                    break;
                                case "categoryId":
                                    categoryId = Int32.Parse(tb.Text);
                                    break;
                                case "ProductName":
                                    ProductName = tb.Text;
                                    break;
                                case "Weight":
                                    Weight = tb.Text;
                                    break;
                                case "UnitPrice":
                                    UnitPrice = decimal.Parse(tb.Text);
                                    break;
                                case "unitInStock":
                                    unitInStock = Int32.Parse(tb.Text);
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
                    productManagement.add(new Product(productId, categoryId, ProductName, Weight, UnitPrice, unitInStock));
                    loadProductList();
                }
                else
                    return;
            });
            updateCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                int productId = 0;
                int categoryId = 0;
                string ProductName = null;
                string Weight = null;
                decimal UnitPrice = 0;
                int unitInStock = 0;
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
                                case "ProductId":
                                    productId = Int32.Parse(tb.Text);
                                    break;
                                case "categoryId":
                                    categoryId = Int32.Parse(tb.Text);
                                    break;
                                case "ProductName":
                                    ProductName = tb.Text;
                                    break;
                                case "Weight":
                                    Weight = tb.Text;
                                    break;
                                case "UnitPrice":
                                    UnitPrice = decimal.Parse(tb.Text);
                                    break;
                                case "unitInStock":
                                    unitInStock = Int32.Parse(tb.Text);
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
                    productManagement.update(productId, new Product(productId, categoryId, ProductName, Weight, UnitPrice, unitInStock));
                    loadProductList();
                }
                else
                    return;
            });
            deleteCommand = new RelayCommand<Object>(p => true, p =>
            {
                Product o = p as Product;
                if (o != null)
                {
                    productManagement.delete(o);
                    loadProductList();
                }
                else return;
            });
        }
        public void loadProductList()
        {
            productList.Clear();
            List<Product> products = productManagement.getAll();
            foreach (Product product in products)
                productList.Add(product);
        }

    }
}
