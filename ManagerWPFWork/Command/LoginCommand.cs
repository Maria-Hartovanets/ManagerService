using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;
using ManagerWpf.Windows;
using ManagerWPFWork.ViewModels;
using ManagerWPFWork.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.Command
{
    public class LoginCommand:ICommand
    {
      
        LoginViewModel _loginViewModel;
      
        public LoginCommand(LoginViewModel loginViewModel)
        {

            _loginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SingInButton")
            {
                if (_loginViewModel.ServiceManager.IsLogin(_loginViewModel.EnteredEmail, _loginViewModel.EnteredPassword) == true)
                {
                   
                    WindowMain _mainWindow = new WindowMain();
                    _mainWindow.Show();
                    this._loginViewModel.CloseWindow();
                }
            }
        }
        
       
        public bool isUserExists(Manager currManager)
        {
            bool res = false;
            foreach (var manager in _loginViewModel.ServiceManager.GetProducts())
            {
                if (manager.Email == currManager.Email)
                {
                    res = true;
                }
            }
            return res;
        }

    }
}
