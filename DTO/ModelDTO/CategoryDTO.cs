using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ModelDTO
{
    public class CategoryDTO
    {
        public int IDCat { get; set; }
        public string TypeProduct { get; set; } 
        public bool IsBlocked { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

       
    }
}
