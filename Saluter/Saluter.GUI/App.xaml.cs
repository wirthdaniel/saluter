using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using Saluter.Data;
using Saluter.GUI.Views;
using Saluter.GUI.ViewModels;
using AutoMapper;
using Saluter.Models;
using Saluter.GUI.Models;
using Saluter.Services.PdfServices;

namespace Saluter.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        
        Container container = new Container();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            container.Register<MainWindow>();

            container.Register<MainViewModel>();

            container.Register<StartViewModel>();

            container.Register<OfferViewModel>();

            container.Register<SelectedProductsViewModel>();

            container.Register<IProductData, InMemoryProductData>(Lifestyle.Singleton);

            container.Register<ICustomerData, InMemoryCustomerData>(Lifestyle.Singleton);

            container.Register<IPdfExporter, PdfExporter>();

            container.RegisterInstance(GetMapper());

            container.GetInstance<MainWindow>().Show();
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, SelectedProductDisplayModel>();
                cfg.CreateMap<SelectedProductDisplayModel, SelectedProduct>();
            });

            return config.CreateMapper();            
        }

    }
}
