using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using ManagerWpf.Windows;
using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace ManagerWPFWork.Windows
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public static UnityContainer Container;
        public WindowMain()
        {
            ConfigureUnity();
            InitializeComponent();
            DataContext = Container.Resolve<MainViewModel>();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowLog mainW = new WindowLog();
            mainW.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IServiceCategory, ServiceCategory>()
                     .RegisterType<IServiceSupplier, ServiceSupplier>()
                     .RegisterType<IServiceProduct, ServiceProduct>()
                     .RegisterType<IServiceManager, ServiceManager>()
                     .RegisterType<ICategoryDAL, CategoryDAL>()
                     .RegisterType<ISupplierDAL, SupplierDAL>()
                     .RegisterType<IProductDAL, ProductDAL>()
                     .RegisterType<IManagerDAL, ManagerDAL>();
        }
    }
}
