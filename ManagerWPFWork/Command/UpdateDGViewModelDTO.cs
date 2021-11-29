using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLLServiceManager.IService;
using ManagerWPFWork.ViewModels;

namespace ManagerWPFWork.Command
{
    public class UpdateDGViewModelDTO : ICommand
    {
        private MainViewModel _mainViewModel;
        public UpdateDGViewModelDTO(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Categories")
            {
                _mainViewModel.SelectedViewModel = new CategoryViewModel(_mainViewModel.ServiceCategory);
            }
            else if (parameter.ToString() == "Products")
            {
                _mainViewModel.SelectedViewModel = new ProductViewModel(_mainViewModel.ServiceProduct, _mainViewModel.ServiceCategory, _mainViewModel.ServiceSupplier);
            }
            else if (parameter.ToString() == "Suppliers")
            {
                _mainViewModel.SelectedViewModel = new SupplierViewModel(_mainViewModel.ServiceSupplier);
            }
            else if (parameter.ToString() == "BlockedCat")
            {
                _mainViewModel.SelectedViewModel = new CategoryBlockedViewModel(_mainViewModel.ServiceCategoryBlocked);
            }
            else
            {
                _mainViewModel.SelectedViewModel = new ManagerViewModel(_mainViewModel.ServiceManager);
            }
        }
    }
}