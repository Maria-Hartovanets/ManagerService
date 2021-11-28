using DTO.Model;
using System.Collections.Generic;

namespace DataAccessLogic.Interfaces
{
    public interface IManagerDAL
    {
        List<Manager> GetProducts();
        List<Manager> GetProductsWithoutPassword();
        void AddObj(Manager tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Manager GetObj(string idT);

        Manager GetObjById(int id); 
    }
}
