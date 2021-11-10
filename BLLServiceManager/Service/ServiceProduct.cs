﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLServiceManager.IService;
using DTO.Model;
using DataAccessLogic.Interfaces;


namespace BLLServiceManager.Service
{
    public class ServiceProduct : IServiceProduct
    {
        readonly private IProductDAL _products;

        public ServiceProduct(IProductDAL products)
        {
            _products = products;
        }
        public void AddObj(Product temp)
        {
            _products.AddObj(temp);
        }

        public void ChangeValueObj(int id, string name)
        {
            _products.ChangeValueObj(id,name);
        }

        public void DeleteObject(int id)
        {
           _products.DeleteObject(id);
            
        }

        public Product GetObj(int id)
        {
            return _products.GetObj(id);
        }

        public List<Product> GetProducts()
        {
            return _products.GetProducts();
        }

        public void ReadFromDataBase()
        {
             _products.ReadFromDataBase();
        }
    }
}
