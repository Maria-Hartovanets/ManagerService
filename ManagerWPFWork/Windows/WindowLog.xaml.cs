using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using ManagerWPFWork.Command;
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
    /// Interaction logic for WindowLog.xaml
    /// </summary>
    public partial class WindowLog : Window
    {
        CommandLoginANDout login;
        IManagerDAL manager ;
        public WindowLog()
        {
            manager = new ManagerDAL();
            login = new CommandLoginANDout(manager);
            InitializeComponent();
        }

        private void button_SingIn_Click(object sender, RoutedEventArgs e)
        {

            if (textBox_Login.Text == "")
            {
                MessageBox.Show("input e-mail", "Error");
                return;
            }
            if (textBox_Pass.Text == "")
            {
                MessageBox.Show("input password", "Error");
                return;
            }
           
            if (IsLog(textBox_Login.Text, textBox_Pass.Text) == false)
            {
                MessageBox.Show("Coudnt find u", "Error");
                return;
            }
            else
            {
               
                WindowMain mainW = new WindowMain();
                mainW.Show();
                this.Close();
            }
        }
        private bool IsLog(string em,string pass)
        {
            return login.IsLogIn(em, pass);

        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister mainW = new WindowRegister();
            mainW.Show();
            this.Close();
        }
    }
}
