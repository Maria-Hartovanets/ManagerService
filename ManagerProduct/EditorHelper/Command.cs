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

        public void AddProductToCategory(string categoryStr)
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
                    if (categoryStr == "")
                    {

                        Console.Write("Input category of product: ");
                        categoryStr = Console.ReadLine();
                        CategoryDTO tempCategory = new CategoryDTO();
                        tempCategory.TypeProduct = categoryStr;
                        categories.AddObj(tempCategory);
                    }
                   
                   
                    products.AddObj(temp);
                    Console.WriteLine("sucessfully added a product!\n");
                    Console.ReadKey();

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
            string categoryStr =Console.ReadLine();
            CategoryDTO categoryTemp = new CategoryDTO();
            categoryTemp.TypeProduct = categoryStr;
            categories.AddObj(categoryTemp);

            Console.WriteLine("sucessfully add the category!\n");
            Console.WriteLine("Do u want to add products to new category?\n1. Yes\n2.No");
            int ans = Convert.ToInt32(Console.ReadLine());
            if (ans == 1)
            {
                AddProductToCategory(categoryStr);
            }
            Console.ReadKey();
           
        }

        public void RemoveProduct()
        {
            try
            {

                Console.Write("\nInput the index to remove element:");
                int index = Convert.ToInt32(Console.ReadLine());
                ProductDTO productTemp = products.GetObj(index);
               products.DeleteObject(productTemp);

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
            Console.Write("\nInput the index to remove category of some product:");
            int index = Convert.ToInt32(Console.ReadLine());

            CategoryDTO categoryCurrent = categories.GetObj(index);
            categories.DeleteObject(categoryCurrent);
            foreach (ProductDTO elem in products.GetProducts())
            {
                if (categoryCurrent.IDCat == elem.Category)
                {
                    elem.Category = 0;
                }
            }
            Console.ReadKey();
        }

        //public void EditNameCategory()
        //{
        //    Console.Write("\nInput the index to edit category of some product:");
        //    int index = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("\nInput new name of category of some product:");
        //    string name =Console.ReadLine();
        //    categories.ChangeOb(index, name);

        //    Console.WriteLine("sucessfully remove the product!\n");
        //    Console.ReadKey();
        //}


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
                        //Console.WriteLine(elem.InfoObject());
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
