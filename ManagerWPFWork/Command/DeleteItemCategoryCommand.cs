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
    public class DeleteItemCategoryCommand : ICommand
    {
        
        private CategoryViewModel _catViewModel;

        public DeleteItemCategoryCommand(CategoryViewModel catViewModel)
        {
            
            this._catViewModel = catViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine();
        }
    
    }
}
