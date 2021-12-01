using ManagerWPFWork.Windows;
using System;
using System.Collections.Generic;
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

namespace ManagerWpf.Windows
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void ButtonOpen_Log_Click(object sender, RoutedEventArgs e)
        {
            WindowLoggin mainW = new WindowLoggin();
            mainW.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                MessageBox.Show("input first name");
                return;
            }
            if (textBoxEmail.Text == "...@gmail.com")
            {
                MessageBox.Show("input e-mail");
                return;
            }
            if (passwordBox.Text == "password")
            {
                MessageBox.Show("input password");
                return;
            }
           
        }
    }
}
