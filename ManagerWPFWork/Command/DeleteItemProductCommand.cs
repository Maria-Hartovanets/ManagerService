﻿using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagerWPFWork.Command
{
    class DeleteItemProductCommand : ICommand
    {

        private ProductViewModel _productViewModel;

        public DeleteItemProductCommand(ProductViewModel productViewModel)
        {

            this._productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _productViewModel.serviceProduct.DeleteObject(_productViewModel.SelectedProduct.Id);
          
                MessageBox.Show("Successfully delete product!", "Information");
            

        }
    }
}
