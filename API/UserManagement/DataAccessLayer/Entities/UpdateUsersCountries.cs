using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UpdateUsersCountries
    {
        public String Country_Code { get; set; } = String.Empty;
        public Guid User_id { get; set; }
    }
}
