using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Interfaces;

public interface IUsersRoleRepository 
{
    Task AddAsync(UsersRole usersRole);
    Task UpdateAsync(UsersRole usersRole);
    Task DeleteAsync(int usersId, int roleId);
}
