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
    public class CommandLoginANDout:ICommand
    {
       IServiceManager _serviceManager;
        WindowMain _mainWindow;
        WindowRegister _registerWindow;
        WindowLog _logWindow;



        public CommandLoginANDout(IManagerDAL serviceManager)
        {
            
          
            _serviceManager =new ServiceManager(serviceManager);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Log")
            {
                _logWindow.Show();

                _registerWindow.Close();
                _mainWindow.Close();
            }
            else if (parameter.ToString() == "Register")
            {
                _registerWindow.Show();

                _logWindow.Close();
                _mainWindow.Close();
            }
            else if (parameter.ToString() == "Main")
            {
                _mainWindow.Show();

                _logWindow.Close();
                _registerWindow.Close();
            }
        }
        
        public bool IsLogIn(string email, string pass)
        {
            
           return _serviceManager.IsLogin(email, pass);
        }
        public bool isUserExists(Manager currManager)
        {
            bool res = false;
            foreach (var manager in _serviceManager.GetProducts())
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
