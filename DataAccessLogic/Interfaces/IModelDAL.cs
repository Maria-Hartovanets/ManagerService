﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;

namespace DataAccessLogic.Interfaces
{
    public interface IModelDAL<T>
    {
        List<T> GetProducts();
        void AddObj(T tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        T GetObj(int id);
        //ProductDTO update
        //ProductDTO create
    }
}
