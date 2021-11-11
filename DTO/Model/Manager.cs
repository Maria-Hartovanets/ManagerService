﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public bool Equals(Manager obj)
        {
            return obj != null
                && obj.ID == this.ID
                && obj.Name == this.Name
                && obj.TimeUpdate == this.TimeUpdate
                && obj.TimeInsert == this.TimeInsert;
        }
        public static byte[] hash(string pass, string salt)
        {
            var algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(pass + salt));
        }
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
