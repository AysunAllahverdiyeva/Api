using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories
{
    public class EfUsersRoleRepository : IUsersRoleRepository

    { private readonly JewelryStoreContext _context;
        public EfUsersRoleRepository(JewelryStoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UsersRole usersRole)
        {
            await _context.UsersRoles.AddAsync(usersRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int usersId, int roleId)
        {
            var usersRole = await _context.UsersRoles
                                     .FirstOrDefaultAsync(ur => ur.UsersId == usersId && ur.RoleId == roleId);
            if (usersRole != null)
            {
                _context.UsersRoles.Remove(usersRole);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(UsersRole usersRole)
        {

            _context.UsersRoles.Update(usersRole);
            await _context.SaveChangesAsync();
        }
    }
}
