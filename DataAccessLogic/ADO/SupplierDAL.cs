using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DataAccessLogic.ADO
{
    public class SupplierDAL : IModelDAL<SupplierDTO>
    {
        List<SupplierDTO> suppliers;
        private string connectionStr;

        public SupplierDAL(string test1="")
        {
            suppliers = new List<SupplierDTO>();
            
            if (test1 == "test")
            {
                connectionStr = "Data Source=DESKTOP-LRMIV19;Initial Catalog=UTestManagerService;Integrated Security=True";
            }
            else
            {
                connectionStr = "Data Source=DESKTOP-LRMIV19;Initial Catalog=ManagerService;Integrated Security=True";
            }
            ReadFromDataBase();
        }
     
        public void ReadFromDataBase()
        {
            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select SupplierId, ProductId, SupplierName, ArrivingTime from Supplier";


                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            SupplierDTO tempSupplier = new SupplierDTO();
                            tempSupplier.Id = (int)reader["SupplierId"];
                            tempSupplier.ProductId = (int)reader["ProductId"];
                            tempSupplier.NameSupplier = (string)reader["SupplierName"];
                            tempSupplier.ArrivingTime = Convert.ToDateTime(reader["ArrivingTime"]);
                            suppliers.Add(tempSupplier);
                            bool t = true;

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
            
        }
        public void AddObj(SupplierDTO tempObj)
        {
            suppliers.Add(tempObj);
            
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Supplier(ProductId,SupplierName,ArrivingTime) " +
                      "values(@productId,@supplierName,@dataArriving)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@productId", tempObj.ProductId);
                    comm.Parameters.AddWithValue("@supplierName", tempObj.NameSupplier);
                    comm.Parameters.AddWithValue("@dataArriving", tempObj.ArrivingTime);
                   // int rowAffected = comm.ExecuteNonQuery();
                    bool t = true;

                }
            }
        }

        public void DeleteObject(int id)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            if (tempObj != null)
            {
                suppliers.Remove(tempObj);
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "delete from Supplier where SupplierId=@supplierId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@supplierId", tempObj.Id);
                        bool t = true;
                    }
                }
            }
        }

        public List<SupplierDTO> GetProducts()
        {
            return suppliers;
        }
        public SupplierDTO GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < suppliers.Count; i++)
            {
                if (suppliers[i].ProductId == idT)
                {
                    index = i;
                }
            }
            return suppliers[index];
        }

        public int GetMostExpensiveObj()
        {
            throw new NotImplementedException();
        }

        public void ChangeValueObj(int id, string newName)
        {
            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            foreach (var cat in suppliers)
            {
                if (id == cat.Id)
                {
                    cat.ChangeObjName(newName);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Supplier set SupplierName=@newNameTemp where SupplierId=@suplId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@suplId", tempObj.Id);
                    int row = comm.ExecuteNonQuery();
                    // bool t = true;
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
        }
        
    }
}
