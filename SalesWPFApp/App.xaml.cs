
using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.Service;
using Microsoft.Extensions.DependencyInjection;
using SalesWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModels;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<FStoreContext>();
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepositoryImpl));
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepositoryImpl));
            services.AddSingleton(typeof(IOrderDetailRepository), typeof(OrderDetailRepositoryImpl));
            services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepositoryImpl));
            services.AddSingleton<OrderManagement>();

            services.AddSingleton<MemberManagement>();


            services.AddSingleton(typeof(ILoginManagement), typeof(LoginManagement));
            services.AddSingleton<ProductManagement>();



            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(s => new LoginView()
            {
                DataContext = s.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<OrderManagementViewModel>();
            services.AddSingleton<OrderManagementView>(s => new OrderManagementView()
            {
                DataContext = s.GetRequiredService<OrderManagementViewModel>()
            });

            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(s => new LoginView()
            {
                DataContext = s.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<ProductManagementViewModel>();
            services.AddSingleton<ProductManagementView>(s => new ProductManagementView()
            {
                DataContext = s.GetRequiredService<ProductManagementViewModel>()
            });
            services.AddSingleton<MemberManagementViewModel>();
            services.AddSingleton<MemberManagementView>(s => new MemberManagementView()
            {
                DataContext = s.GetRequiredService<MemberManagementViewModel>()
            });


        }
        public void OnStartUp(object sender, StartupEventArgs e)
        {
            var loginManagementView = serviceProvider.GetRequiredService<LoginView>();
            var productManagementView = serviceProvider.GetRequiredService<ProductManagementView>();
            var memberManagementView = serviceProvider.GetRequiredService<MemberManagementView>();


            var orderManagementView = serviceProvider.GetRequiredService<OrderManagementView>();


            loginManagementView.Show();
        }


    }
}
