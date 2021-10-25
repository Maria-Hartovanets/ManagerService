using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Category
    {
        public int IDCat { get; set; }
        public string TypeProduct { get; set; } = "";
        public bool IsBlocked { get; set; } = false;
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public void ChangeObjName(string nameNew)
        {
            TypeProduct = nameNew;

        }

        public string InfoString()
        {
            return $"Id: {IDCat}\tCategory: {TypeProduct}\tIsBlocked: {IsBlocked}\tInsert Time: {RowInsertTime}\tUpdate: {RowUpdateTime}";
        }
    }
}
