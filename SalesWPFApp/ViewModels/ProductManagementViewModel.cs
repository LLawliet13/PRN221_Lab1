using BusinessObject.Models;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.ViewModels
{
    public  class ProductManagementViewModel
    {
        ProductManagement productManagement;
        public ObservableCollection<Product> productList { get; set; }
        public ProductManagementViewModel(ProductManagement productManagement)
        {

            this.productManagement = productManagement;
        }

    }
}
