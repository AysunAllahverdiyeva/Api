    using JewelryStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Domain.Entities.Jewelry
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; }= string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public int? ImagesId { get; set; }
        public Images Images { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
