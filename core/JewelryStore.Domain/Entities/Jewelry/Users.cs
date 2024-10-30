using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class Users
    {
        public int Id { get; set; }
        public string Email  { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public ICollection<Review> Reviews { get; set; }=new HashSet<Review>();
        public ICollection<UsersRole> UsersRoles { get; set; } = new HashSet<UsersRole>();
        public UserDetail UserDetail { get; set; }
    }
}
