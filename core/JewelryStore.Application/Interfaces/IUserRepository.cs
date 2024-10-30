using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddUsers(Users users);
        void UpdateUsers(Users users);
        Task<Users?> GetUserWithDetail(string email);
    }
}
