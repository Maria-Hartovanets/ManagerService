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
    public class UnitTestSupplier
    {
        IModelDAL<SupplierDTO> products = new SupplierDAL("test");

        [TestMethod]
        public void TestMethod_AddNewValue()
        {

            SupplierDTO tempSupplier = new SupplierDTO();
            tempSupplier.ProductId = 1;
            string nameM = "MARIA";
            tempSupplier.NameSupplier = nameM;
            DateTime dateTime = new DateTime();
            tempSupplier.ArrivingTime = dateTime.Date;

            products.AddObj(tempSupplier);
            var tempObj = products.GetProducts().Find(x => x.NameSupplier == nameM);
            Assert.IsNotNull(tempObj);
        }
        [TestMethod]
        public void TestMethod_RemoveValue()
        {

            SupplierDTO tempSupplier = new SupplierDTO();
            tempSupplier.ProductId = 3;
            string nameM = "YURA";
            tempSupplier.NameSupplier = nameM;
            DateTime dateTime = new DateTime();
            tempSupplier.ArrivingTime = dateTime.Date;

            var tempObj = products.GetProducts().Find(x => x.NameSupplier == nameM);
            products.DeleteObject(tempObj.Id);
            var tempObjDel = products.GetProducts().Find(x => x.NameSupplier == nameM);
            Assert.IsNull(tempObjDel);
        }
      
    }
}
