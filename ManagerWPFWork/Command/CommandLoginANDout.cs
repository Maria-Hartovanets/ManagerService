using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;
using ManagerWpf.Windows;
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
        
        public CommandLoginANDout(IManagerDAL serviceManager)
        {
            _serviceManager = new ServiceManager(serviceManager);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (IsLogIn(parameter.ToString(), parameter.ToString()) == true)
            {
                WindowMain mainW = new WindowMain();
                mainW.Show();
                
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
