using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagerWPFWork.View
{
    /// <summary>
    /// Interaction logic for ViewProduct.xaml
    /// </summary>
    public partial class ViewProduct : UserControl
    {
        public ViewProduct()
        {
            InitializeComponent();
        }
        private void name_texbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(name_texbox.Text))
            {
                MessageBox.Show("Invalid Input. Start only with letter!", "Error");
            }
        }
        private void price_texbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(e.Text))
            {
                MessageBox.Show("Invalid input. Only letter allowed!","Error");
            }
        }
    }
}
