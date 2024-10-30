using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories;

public class EFRoleRepository : IRoleRepository
{
    private readonly JewelryStoreContext _context;

    public EFRoleRepository( JewelryStoreContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }
}
