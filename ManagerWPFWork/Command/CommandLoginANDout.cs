using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerWPFWork.Command
{
    public class CommandLoginANDout
    {
       IServiceManager _serviceManager;
       
        public CommandLoginANDout(IManagerDAL serviceManager)
        {
            _serviceManager = new ServiceManager(serviceManager);
        }
        public bool IsLogIn(string email, string pass)
        {
           return _serviceManager.IsLogin(email, pass);
        }
      
    }
}
