using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public ICollection<UsersRole> UsersRoles { get; set; }

    }
}
