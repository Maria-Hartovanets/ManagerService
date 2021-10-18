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
    public class CategoryDAL : IModelDAL<CategoryDTO>
    {
        List<CategoryDTO> categories;
        private string connectionStr;
        List<ProductDTO> product;
        public CategoryDAL(string test1="")
        {
            categories = new List<CategoryDTO>();
            product = new List<ProductDTO>();
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
                        comm.CommandText = "select CategoryId, CategoryType from Category";

                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            CategoryDTO tempCategory = new CategoryDTO();
                            tempCategory.IDCat = (int)reader["CategoryId"];
                            tempCategory.TypeProduct = (string)reader["CategoryType"];
                            categories.Add(tempCategory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
        }
        public void AddObj(CategoryDTO tempObj)
        {
            categories.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Category (CategoryType) values(@categoryName)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@categoryName", tempObj.TypeProduct);
                   comm.ExecuteNonQuery();
                }
            }
        }

        public void DeleteObject(int id)
        {
            var tempObj = categories.Where(x => x.IDCat == id).SingleOrDefault();
            if (tempObj != null)
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();

                       
                        comm.CommandText = "update Product set CategoryId=@newTemp where CategoryId=@productId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@newTemp", 8);
                        comm.Parameters.AddWithValue("@productId", tempObj.IDCat);
                        int row = comm.ExecuteNonQuery();

                    }
                }
                categories.Remove(tempObj);

                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                       
                        //delete from Product where ProductId=1
                       
                        comm.CommandText = "delete from Category where CategoryId=@categId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@categId", tempObj.IDCat);
                        comm.ExecuteNonQuery();
                    }
                }
            }
        }

      

        public List<CategoryDTO> GetProducts()
        {
            return categories;
        }

        public CategoryDTO GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].IDCat == idT)
                {
                    index = i;
                }
            }
            return categories[index];
        }

        public int GetMostExpensiveObj()
        {
            throw new NotImplementedException();
        }

        public void ChangeValueObj(int id, string newName)
        {
            var tempObj = categories.Where(x => x.IDCat == id).SingleOrDefault();
            foreach (var cat in categories)
            {
                if (id == cat.IDCat)
                {
                    cat.ChangeObjName(newName);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Category set CategoryType=@newNameTemp where CategoryId=@categorId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@categorId", tempObj.IDCat);
                    int row = comm.ExecuteNonQuery();
                    // bool t = true;
                }
            }
        }
    }
}
