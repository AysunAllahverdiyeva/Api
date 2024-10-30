using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class UsersRole
    {
        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public Users Users { get; set; }
        public Role Role { get; set; }
    }
}
