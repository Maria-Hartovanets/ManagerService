using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ModelDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string NameObj { get; set; }
        public int PriceIn { get; set; }
        public int PriceOut { get; set; }
        public int Category { get; set; }
        public int Supplier { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

    }
}
