using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;

namespace ManagerProductConsole.EditorHelper
{
    class Command
    {


        IModelDAL<CategoryDTO> categories = null;
        IModelDAL<SupplierDTO> suppliers = null;
        IModelDAL<ProductDTO> products = null;
        public Command()
        {

            categories = new CategoryDAL();
            suppliers = new SupplierDAL();
            products = new ProductDAL();
        }

        public void AddProductToCategory(int category)
        {

            bool optionCyc = true;
            do
            {
                try
                {
                    ProductDTO temp = new ProductDTO();
                    Console.Write("Input name of product: ");
                    string nameM = Console.ReadLine();
                    temp.NameObj = nameM;

                    Console.Write("Input priceIn: ");
                    string priceStr = Console.ReadLine();
                    temp.PriceIn = (Convert.ToInt32(priceStr));

                    Console.Write("Input priceout: ");
                    string priceStrOut = Console.ReadLine();
                    temp.PriceOut = (Convert.ToInt32(priceStrOut));
                    foreach (CategoryDTO categoryTemp in  categories.GetProducts())
                    {
                        if (categoryTemp.IDCat == category)
                        {
                            temp.Category = category;
                            products.AddObj(temp);
                            Console.WriteLine("sucessfully added a product!\n");
                            Console.ReadKey();
                        }
                        //else
                        //{
                        //    Console.WriteLine("Sorry there isnt this id of category!");
                        //}
                        
                    }

                }
                catch
                {
                    Console.WriteLine("\t\t\t\tError 404!\n\t\t\tIncorrect option!");
                    Console.ReadKey();

                }
                Console.WriteLine("\t\tTo add one more product to database please enter 'more'\n"
                                              + "\t\t   in another way enter 'nope': ");
                string answer = Console.ReadLine();

                if (answer == "more")
                {
                    optionCyc = true;
                }
                else { optionCyc = false; }
            } while (optionCyc);
            Console.ReadKey();

        }

        public void AddCategory()
        {
            Console.Write("\nInput new name for categories:");
            string categoryStr = Console.ReadLine();
            CategoryDTO categoryTemp = new CategoryDTO();
            categoryTemp.TypeProduct = categoryStr;
            categories.AddObj(categoryTemp);

            Console.WriteLine("sucessfully add the category!\n");
            Console.ReadKey();

        }

        public void AddSupplier()
        {
            Console.Write("\nInput new name of supplier:");
            string supplierName = Console.ReadLine();
            Console.Write("\nInput the id of product he/she give:");
            int idProd = Convert.ToInt32(Console.ReadLine());

            SupplierDTO supplier = new SupplierDTO();
            supplier.NameSupplier = supplierName;
            supplier.ProductId = idProd;
            DateTime dateTime = DateTime.Now;
            supplier.ArrivingTime = dateTime;

            suppliers.AddObj(supplier);

            Console.WriteLine("sucessfully add the supplier!\n");
            Console.ReadKey();

        }

        public void RemoveProduct()
        {
            try
            {
                Write("Product");
               Console.Write("\nInput the id to remove element:");
                int id = Convert.ToInt32(Console.ReadLine());
                products.DeleteObject(id);

                Console.WriteLine("sucessfully remove the product!\n");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error during remove from array: {ex.Message}");

            }
        }

        public void RemoveCategory()
        {
            Console.Write("\nInput the id to remove category of some product:");
            int id = Convert.ToInt32(Console.ReadLine());
            categories.DeleteObject(id);
            foreach (ProductDTO elem in products.GetProducts())
            {
                if (id == elem.Category)
                {
                    elem.Category = 0;
                }
            }
            Console.ReadKey();
        }

        public void RemoveSupplier()
        {
            try
            {
                Console.Write("\nInput the id to remove supplier:");
                int index = Convert.ToInt32(Console.ReadLine());
                suppliers.DeleteObject(index);

                Console.WriteLine("sucessfully remove the product!\n");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during remove from array: {ex.Message}");

            }
        }
        public void ShowTheMostExpensiveProduct()
        {
            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");

            Console.WriteLine(products.GetObj(products.GetMostExpensiveObj()).InfoString());
            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");
            Console.ReadKey();
        }

        public void EditNameCategory()
        {
            Console.Write("\nInput the id to edit category of some product:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new name of category of some product:");
            string name = Console.ReadLine();
            categories.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the category!\n");
            Console.ReadKey();
        }
        public void EditNameProduct()
        {
            Console.Write("\nInput the id to edit category of some product:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new name of category of some product:");
            string name = Console.ReadLine();
            products.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the product!\n");
            Console.ReadKey();
        }
        public void EditNameSupplier()
        {
            Console.Write("\nInput the id to edit category of some product:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new name of category of some product:");
            string name = Console.ReadLine();
            suppliers.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the suppplier!\n");
            Console.ReadKey();
        }

        public void WriteOneCategoryTypeProduct(int idCat)
        {
            Console.WriteLine("---------------------------------------------"
                      + "----------------------------------------------"
                      + "--------------------------");
            foreach (ProductDTO elem in products.GetProducts())
            {
                if (elem.Category == idCat)
                {
                    Console.WriteLine(elem.InfoString());
                }
            }

            Console.WriteLine("---------------------------------------------"
                      + "----------------------------------------------"
                      + "--------------------------");
        }
        public void Write(string temp)
        {
           
            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");
            if (temp == "blockTable")
            {
                foreach (ProductDTO elem in products.GetProducts())
                {
                    if (elem.Category ==0)
                    {
                        Console.WriteLine(elem.InfoString());
                    }
                }

            }
            else if (temp == "Product")
            {
                foreach (ProductDTO elem in products.GetProducts())
                {
                    Console.WriteLine(elem.InfoString());
                }
            }
            else if (temp == "Category")
            {
                foreach (CategoryDTO elem in categories.GetProducts())
                {
                    Console.WriteLine(elem.InfoString());
                }
            }
            else
            {
                foreach (SupplierDTO elem in suppliers.GetProducts())
                {
                    Console.WriteLine(elem.InfoString());
                }
            }

            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");

                Console.ReadKey();
            
        }
      
    }
}
