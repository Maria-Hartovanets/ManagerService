using BLLServiceManager.IService;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.ViewModels
{
    public class ProductViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private Product _selectedProduct;
        private IServiceProduct _serviceProduct;
        private IServiceCategory _serviceCategory;
        private ObservableCollection<Tuple<Product, string>> _Products_Category = new ObservableCollection<Tuple<Product, string>>();
        public ICommand GetBooks { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IServiceProduct serviceProduct { get => _serviceProduct; }
        public IServiceCategory serviceCategory { get => _serviceCategory; }
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ObservableCollection<Tuple<Product, string>> Products_Category
        {
            get => _Products_Category;
            set
            {
                _Products_Category = value;
                OnPropertyChanged("Products_Category");
            }
        }
        public ProductViewModel(/*IServiceProduct serviceProduct, IServiceCategory serviceCategory*/)
        {
            _serviceProduct = serviceProduct;
            _serviceCategory = serviceCategory;
           
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
