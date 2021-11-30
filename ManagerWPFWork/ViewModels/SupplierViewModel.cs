using BLLServiceManager.IService;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagerWPFWork.ViewModels
{
    public class SupplierViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private Supplier _selectedSupplier;
      
        private IServiceSupplier _serviceSupplier;
        public IEnumerable<Supplier> Suppliers { get; set; }
       // public IServiceSupplier serviceSupplier { get => _serviceSupplier; }
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged("SelectedSupplier");
            }
        }
        public IEnumerable<Supplier> SuppliersAllInfo
        {
            get => Suppliers;
            set
            {
                Suppliers = value;
                OnPropertyChanged("SuppliersAllInfo");
            }
        }
        public SupplierViewModel( IServiceSupplier serviceSupplier)
        {

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

            Suppliers = _serviceSupplier.GetProducts();

        }
    }
}
