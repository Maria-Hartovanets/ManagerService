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
                                                command.Write("Category");
                                                Console.Write("\nChoose the id of category to show all product of it:");
                                                int idCat = Convert.ToInt32(Console.ReadLine());
                                                command.WriteOneCategoryTypeProduct(idCat);
                                            }
                                            break;
                                        case 3:
                                            {
                                                command.EditNameProduct();
                                            }
                                            break;
                                        case 4:
                                            {
                                               
                                                command.Write("Category");
                                                Console.Write("\nChoose the id of category to add new  product after pressing enter:");
                                                int categoryId = Convert.ToInt32(Console.ReadLine());
                                                command.AddProductToCategory(categoryId);
                                            }
                                            break;
                                        case 5:
                                            {
                                                command.RemoveProduct();
                                            }
                                            break;
                                        case 6:
                                            {
                                                command.ShowTheMostExpensiveProduct();
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
                                               command.EditNameCategory();
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
                                bool operationShowSupp = true;
                                do
                                {
                                    MenuConsole.ShowSupplierMenu();
                                    int ans = Convert.ToInt32(Console.ReadLine());
                                    switch (ans)
                                    {
                                        case 1:
                                            {
                                                command.Write("Supplier");
                                            }
                                            break;
                                        case 2:
                                            {
                                                 command.EditNameSupplier();
                                            }
                                            break;
                                        case 3:
                                            {

                                              command.AddSupplier();
                                            }
                                            break;
                                        case 4:
                                            {
                                                command.RemoveSupplier();
                                            }
                                            break;
                                        case 5:
                                            {
                                                operationShowSupp = false;
                                            }
                                            break;
                                    }
                                } while (operationShowSupp);
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
