﻿using DTO.Model;
using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.Command
{
    public class AddItemSupplierCommand:ICommand
    {
        //private MainViewModel _mainViewModel;
        private SupplierViewModel _supplierViewModel;

        public AddItemSupplierCommand( SupplierViewModel supplierViewModel)
        {
           
            _supplierViewModel = supplierViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Supplier temp = new Supplier();
            temp.NameSupplier = _supplierViewModel.EnteredNameSupplier;
            temp.ArrivingTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;
            _supplierViewModel.serviceSupplier.AddObj(temp);
            _supplierViewModel.EnteredNameSupplier= "...";
        }
    }
}
