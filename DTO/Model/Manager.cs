using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Manager
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "";
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public string Email { get; set; } = "";
        public DateTime TimeInsert { get; set; }
        public DateTime TimeUpdate { get; set; }

        public Manager CopyElem()
        {
            Manager other = new Manager();
            other.Email = this.Email;
            other.ID = this.ID;
            other.Name = this.Name;
            other.Password = null;
            other.Salt = Guid.Empty;
            other.TimeInsert = this.TimeInsert;
            other.TimeUpdate = this.TimeUpdate;
            return other;
        }
    }
}
