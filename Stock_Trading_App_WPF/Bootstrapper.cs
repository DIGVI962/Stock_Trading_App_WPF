using Caliburn.Micro;
using DataLayer;
using DataLayer.APIDataFetch;
using Stock_Trading_App_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stock_Trading_App_WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;

        public Bootstrapper()
        {
            Container = new SimpleContainer();
            Initialize();
        }

        public SimpleContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainWindowViewModel>();
        }

        protected override void Configure()
        {
            Container.Singleton<IWindowManager, WindowManager>();
            Container.Singleton<MainWindowViewModel>();
            Container.Singleton<SecurityListViewModel>();
            Container.Singleton<BSEMethods>();
            Container.Singleton<StockContext>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return Container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            Container.BuildUp(instance);
        }
    }
}
