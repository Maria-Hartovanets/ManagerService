using DTO.Model;
using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.Command
{
    public class AddItemCategoryCommand: ICommand
    {
        private MainViewModel _mainViewModel;
        private CategoryViewModel _catViewModel;

        public AddItemCategoryCommand(CategoryViewModel catViewModel, MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
            this._catViewModel = catViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Category temp = new Category();
            temp.TypeProduct = this._catViewModel.SelectedCategory.TypeProduct;
            temp.IsBlocked = this._catViewModel.SelectedCategory.IsBlocked;
            temp.RowInsertTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;
            this._mainViewModel.ServiceCategory.AddObj(temp);
        }
    }
}
