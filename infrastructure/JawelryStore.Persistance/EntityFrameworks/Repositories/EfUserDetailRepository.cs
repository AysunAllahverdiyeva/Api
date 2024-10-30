using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories;

public class EfUserDetailRepository : IUserDetailRepository
{
    private readonly JewelryStoreContext _context;
    public EfUserDetailRepository( JewelryStoreContext context)
    {
        _context = context;
    }
    public async Task AddAsync(UserDetail userDetail)
    {
        await _context.UserDetails.AddAsync(userDetail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userDetail = await _context.UserDetails.FindAsync(id);
        if (userDetail != null)
        {
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(UserDetail userDetail)
    {
        _context.UserDetails.Update(userDetail);
        await _context.SaveChangesAsync();
    }
}
