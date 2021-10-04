using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string NameSupplier { get; set; }
        public DateTime ArrivingTime { get; set; }

        public void ChangeObjName(string nameNew)
        {
            NameSupplier = nameNew;
        }
        public string InfoString()
        {
            return $"Id: {Id}\tProductId: {ProductId}\tSupplier: {NameSupplier}\tTime arriving: {ArrivingTime}";
        }
    }
}
