using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class CategoryDTO
    {
        public int IDCat { get; set; }
        public string TypeProduct { get; set; } = "";

        public string InfoString()
        {
            return $"Id: {IDCat}\tCategory: {TypeProduct}";
        }
    }
}
