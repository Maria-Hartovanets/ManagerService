using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestManager
{
    [TestClass]
    public class UnitTestCategory
    {

        IModelDAL<CategoryDTO> products = new CategoryDAL("test");


        [TestMethod]
        public void TestMethod_AddNewValue()
        {

            CategoryDTO temp = new CategoryDTO();
            string nameM = "fruits";
            temp.TypeProduct = nameM;

            products.AddObj(temp);
            var tempObj = products.GetProducts().Find(x => x.TypeProduct == nameM);
            Assert.IsNotNull(tempObj);
        }
        [TestMethod]
        public void TestMethod_RemoveValue()
        {
            CategoryDTO temp = new CategoryDTO();
            string nameM = "sweets";
            temp.TypeProduct = nameM;

            var tempObj = products.GetProducts().Find(x => x.TypeProduct == nameM);
            products.DeleteObject(tempObj.IDCat);
            var tempObjDel = products.GetProducts().Find(x => x.TypeProduct == nameM);
            Assert.IsNull(tempObjDel);
        }
        [TestMethod]
        public void TestMethod_GetObject()
        {
            CategoryDTO temp = new CategoryDTO();
            string nameM = "daily product";
            temp.TypeProduct = nameM;
            temp.IDCat = 1;//current

            CategoryDTO exepObj = products.GetObj(temp.IDCat);
            Assert.AreEqual(exepObj.IDCat, temp.IDCat);
        }
    }
}
