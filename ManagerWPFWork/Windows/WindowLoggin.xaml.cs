using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
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
    /// Interaction logic for WindowLoggin.xaml
    /// </summary>
    public partial class WindowLoggin : Window
    {
        public static UnityContainer Container;

        public WindowLoggin()
        {
                
            InitializeComponent();
          
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_SingIn_Click(object sender, RoutedEventArgs e)
        {

        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IServiceManager, ServiceManager>()
                     .RegisterType<IManagerDAL, ManagerDAL>();
        }
    }
}
