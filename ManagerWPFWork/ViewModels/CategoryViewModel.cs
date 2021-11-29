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

namespace ManagerWPFWork.ViewModels
{
    public class CategoryViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private Category _selectedCategory;
      
        private IServiceCategory _serviceCategory;
        public IEnumerable<Category> Categories { get; set; }
     
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public IEnumerable<Category> CategoriesAllInfo
        {
            get => Categories;
            set
            {
                Categories = value;
                OnPropertyChanged("CategoriesAllInfo");
            }
        }
        public CategoryViewModel( IServiceCategory serviceCategory)
        {
           
            _serviceCategory = serviceCategory;
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

            Categories = _serviceCategory.GetProducts();

        }
    }
}
