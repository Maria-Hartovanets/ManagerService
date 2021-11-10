﻿using BLLServiceManager.IService;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLogic.Interfaces;

namespace BLLServiceManager.Service
{
    public class ServiceSupplier : IServiceSupplier
    {
        readonly private ISupplierDAL _suppliers;
        public ServiceSupplier(ISupplierDAL suppliers)
        {
            _suppliers = suppliers;
        }
        public void AddObj(Supplier tempObj)
        {
            _suppliers.AddObj(tempObj);
        }

        public void ChangeValueObj(int id, string newName)
        {
            _suppliers.ChangeValueObj(id,newName);
        }

        public void DeleteObject(int id)
        {
            _suppliers.DeleteObject(id);
        }

        public Supplier GetObj(int idT)
        {
            return _suppliers.GetObj(idT);
        }

        public List<Supplier> GetProducts()
        {
            return _suppliers.GetProducts();
        }

        public void ReadFromDataBase()
        {
            _suppliers.ReadFromDataBase();
        }
    }
}
