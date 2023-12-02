using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AddUser
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public byte Type_id { get; set; } = byte.MinValue;
        public List<Countries>? Countries { get; set; }
        public AddUser()
        {
            Countries = new List<Countries>();
        }
    }
}
