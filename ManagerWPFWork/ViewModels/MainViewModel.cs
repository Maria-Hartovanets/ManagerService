using BLLServiceManager.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.ViewModels
{
    public class MainViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private IServiceCategory _serviceCategory;
        private IServiceProduct _serviceProduct;
        private ViewModelBase _selectedViewModel;
        public MainViewModel(/*IServiceCategory serviceCategory, IServiceProduct serviceProduct*/)
        {
            //this._serviceCategory = serviceCategory;
            //this._serviceProduct = serviceProduct;
            this._selectedViewModel = new ProductViewModel();
            //UpdateViewCommand = new UpdateViewCommand(this);

        }

        public ViewModelBase SelectedViewModel
        {
            get => this._selectedViewModel;
            set
            {
                this._selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        public IServiceCategory ServiceCategory
        {
            get => this._serviceCategory;
            set => this._serviceCategory = value;
        }
        public IServiceProduct ServiceProduct
        {
            get => this._serviceProduct;
            set => this._serviceProduct = value;
        }
    }
}
