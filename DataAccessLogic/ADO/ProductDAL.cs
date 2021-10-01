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
    public class ProductDAL : IModelDAL<ProductDTO>
    {
        List<ProductDTO> products;
        private string connectionStr="Data Source=DESKTOP-LRMIV19;Initial Catalog=ManagerService;Integrated Security=True";

        public ProductDAL()
        {
            products = new List<ProductDTO>();
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
                        comm.CommandText = "select ProductId, ProductName, PriceIn, PriceOut," +
                          " CategoryId from Product";


                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            ProductDTO tempProduct = new ProductDTO();
                            tempProduct.Id = (int)reader["ProductId"];
                            tempProduct.NameObj = (string)reader["ProductName"];
                            var temp = reader["PriceIn"];
                            tempProduct.PriceIn = Convert.ToInt32( temp);
                            tempProduct.PriceOut = (int)reader["PriceOut"];
                            tempProduct.Category = (int)reader["CategoryId"];
                            products.Add(tempProduct);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
        }

        public List<ProductDTO> GetProducts()
        {
            return products;

        }
        public void AddObj(ProductDTO tempObj)
        {
            products.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Product(ProductName, PriceIn, PriceOut," +
                      " CategoryId) values(@fname,@priceInn, @priceOutt, @categor)";
                   // comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@fname", tempObj.NameObj);
                    comm.Parameters.AddWithValue("@priceInn", tempObj.PriceIn);
                    comm.Parameters.AddWithValue("@priceOutt", tempObj.PriceOut);
                    comm.Parameters.AddWithValue("@categor", tempObj.Category);
                }
            }
        }

        public void DeleteObject(int id)
        {
            var tempObj = products.Where(x => x.Id == id).SingleOrDefault();
            products.Remove(tempObj);
           
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                   
                        //delete from Product where ProductId=1
                    connectionSql.Open();
                    comm.CommandText = "delete from Product where ProductId=@productId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@productId", tempObj.Id);
                }
            }


        }

        public ProductDTO GetObj(int index)
        {
            return products[index];
        }
    }
}
