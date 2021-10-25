using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ModelDTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string NameSupplier { get; set; }
        public DateTime ArrivingTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

    }
}
