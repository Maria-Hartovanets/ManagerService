using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Model;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLogic.Interfaces
{
    public interface IProductDAL
    {
        List<Product> GetProducts();
        void AddObj(Product tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Product GetObj(int idT);
        int GetMostExpensiveObj();
        void ChangeValueObj(int id, string newName);
    }
}
