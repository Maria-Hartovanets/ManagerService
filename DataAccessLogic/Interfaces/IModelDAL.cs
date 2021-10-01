using System;
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
        void DeleteObject(T tempObj);
        void ReadFromDataBase();
        int GetIdObj(T tempObj);
        T GetObj(int index);
        //ProductDTO update
        //ProductDTO create
    }
}
