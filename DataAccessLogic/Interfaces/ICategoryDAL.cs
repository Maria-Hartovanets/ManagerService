using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLogic.Interfaces
{
    public interface ICategoryDAL
    {
        List<Category> GetProducts();
        void AddObj(Category tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Category GetObj(int idT);
        void ChangeValueObj(int id, string newName);
    }
}
