using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string NameSupplier { get; set; }
        public DateTime ArrivingTime { get; set; }
        public DateTime RowUpdateTime { get; set; }


        public void ChangeObjName(string nameNew)
        {
            NameSupplier = nameNew;
        }
        public string InfoString()
        {
            return $"Id: {Id}\tSupplier: {NameSupplier}\tTime arriving: {ArrivingTime}\tUpdate: {RowUpdateTime}";
        }
    }
}
