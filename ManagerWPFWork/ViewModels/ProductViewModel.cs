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
        private IServiceSupplier _serviceSupplier;
        private IServiceCategory _serviceCategory;
        private ObservableCollection<Tuple<Product,string,string>>  _productsAllInfo = new ObservableCollection<Tuple<Product, string, string>>();
       
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IServiceProduct serviceProduct { get => _serviceProduct; }
        public IServiceSupplier serviceSupplier { get => _serviceSupplier; }
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

        public ObservableCollection<Tuple<Product, string, string>> ProductsAllInfo
        {
            get => _productsAllInfo;
            set
            {
                _productsAllInfo = value;
                OnPropertyChanged("ProductsAllInfo");
            }
        }
        public ProductViewModel(IServiceProduct serviceProduct, IServiceCategory serviceCategory, IServiceSupplier serviceSupplier)
        {
            _serviceProduct = serviceProduct;
            _serviceCategory = serviceCategory;
            _serviceSupplier = serviceSupplier;
            FillInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void FillInfo()
        {
            Products = _serviceProduct.GetProducts();
            Categories = _serviceCategory.GetProducts();
            Suppliers = _serviceSupplier.GetProducts();
            foreach(var product in Products)
            {
                ProductsAllInfo.Add(new Tuple<Product, string,string >
                    (product, this._serviceCategory.GetObj(product.CategoryID).TypeProduct,
                    this._serviceSupplier.GetObj(product.SupplierID).NameSupplier));

            }

        }
    }
}
