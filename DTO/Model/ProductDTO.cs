using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string NameObj { get; set; }
        public int PriceIn { get; set; }
        public int PriceOut { get; set; }
        public int Category { get; set; }
        public string InfoString()
        {
            return $"Id: {Id}\tName: {NameObj}\tPrice in/out: {PriceIn}/{PriceOut}\tCategoryId: {Category}";
        }
    }
}
