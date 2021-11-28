using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLServiceManager.IService;

namespace ManagerWPFWork.Command
{
    public class UpdateDGViewModelDTO
    {
        IServiceCategory _serviceCategory;
        IServiceManager _serviceManager;
        IServiceProduct _serviceProduct;
        IServiceSupplier _serviceSupplier;
        string TypeObject = null;
        
        public UpdateDGViewModelDTO(GetObjectModelDTO objectT)
        {
            this.TypeObject = objectT.TypeObject;
            if (TypeObject == "Product")
            {
               
            }
        }


        

    }
}
