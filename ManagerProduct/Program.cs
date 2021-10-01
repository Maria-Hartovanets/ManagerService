using ManagerProductConsole.EditorHelper;
using System;
using System.Data.SqlClient;

namespace ManagerProductConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Command command = new Command();
            MenuConsole.Introdusing();

            Console.Write("\nInput Password to enter:");
            int password = Convert.ToInt32(Console.ReadLine());
            if (password == 12345)
            {

                while (password == 12345)
                {
                    MenuConsole.ShowMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                bool operationShomProducts = true;
                                do
                                {
                                    MenuConsole.ShowProductMenu();
                                    int ans = Convert.ToInt32(Console.ReadLine());
                                    switch (ans)
                                    {
                                        case 1:
                                            {
                                                command.Write("Product");
                                            }
                                            break;
                                        case 2:
                                            {
                                                //command.Write("");
                                            }
                                            break;
                                        case 3:
                                            {
                                                //command.
                                            }
                                            break;
                                        case 4:
                                            {
                                               
                                                command.Write("Category");
                                                Console.Write("\nChoose category to add product or press enter to create new category with its products:");
                                                string category = Console.ReadLine();
                                                command.AddProductToCategory(category);
                                            }
                                            break;
                                        case 5:
                                            {
                                                command.RemoveProduct();
                                            }
                                            break;
                                        case 6:
                                            {
                                                //command.
                                            }
                                            break;
                                        case 7:
                                            {
                                                operationShomProducts = false;
                                            }
                                            break;
                                    }
                                } while (operationShomProducts);

                            }
                            break;
                        case 2:
                            {
                                bool operationShomCateg = true;
                                do
                                {
                                    MenuConsole.ShowCategoryMenu();
                                    int ans = Convert.ToInt32(Console.ReadLine());
                                    switch (ans)
                                    {
                                        case 1:
                                            {
                                                command.Write("Category");
                                            }
                                            break;
                                        case 2:
                                            {
                                               // command.EditNameCategory();
                                            }
                                            break;
                                        case 3:
                                            {

                                                command.AddCategory();
                                            }
                                            break;
                                        case 4:
                                            {
                                                command.RemoveCategory();
                                            }
                                            break;
                                        case 5:
                                            {
                                                operationShomCateg = false;
                                            }
                                            break;
                                    }
                                } while (operationShomCateg);
                            }
                            break;
                        case 3:
                            {

                            }
                            break;
                        case 4:
                            {
                                password = 1;
                                Console.WriteLine("\nYou logged out!");
                            }
                            break;


                    }

                }
            }
            else
            {
                Console.WriteLine("Error! Wrong password!");
            }

        }
    }
}

//string connStr = "Data Source=DESKTOP-LRMIV19;Initial Catalog=ManagerService;Integrated Security=True";
//using (SqlConnection sql = new SqlConnection(connStr))
//{
//    using (SqlCommand comm = sql.CreateCommand())
//    {
//        sql.Open();
//        string name = "apple";
//        float priceIn = 12;
//        float priceout = 16;
//        int catId = 2;
//        comm.CommandText = "insert into Product(ProductName, PriceIn, PriceOut," +
//           " CategoryId) values(@fname,@priceInn, @priceOutt, @categor)";
//        comm.Parameters.Clear();
//        comm.Parameters.AddWithValue("@fname", name);
//        comm.Parameters.AddWithValue("@priceInn", priceIn);
//        comm.Parameters.AddWithValue("@priceOutt", priceout);
//        comm.Parameters.AddWithValue("@categor", catId);

//        int rowAff=comm.ExecuteNonQuery();
//        Console.WriteLine($"row added:  {rowAff}");


//        comm.CommandText = "select ProductId, ProductName, PriceIn, PriceOut," +
//            " CategoryId from Product";


//        SqlDataReader reader= comm.ExecuteReader();
//        while (reader.Read())
//        {
//            Console.WriteLine($"{reader["ProductId"]}\t{reader["ProductName"]}\t" +
//                $"{reader["PriceIn"]}\t{reader["PriceOut"]}\t{reader["CategoryId"]}");
//        }
//    }
//}