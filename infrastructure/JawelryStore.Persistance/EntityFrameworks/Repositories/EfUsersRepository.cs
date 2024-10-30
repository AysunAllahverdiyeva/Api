using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories;

public class EfUsersRepository : IUserRepository
{
    private readonly JewelryStoreContext _context;
    public EfUsersRepository(JewelryStoreContext context)
    {
        _context = context;
    }
    public async Task AddUsers(Users users)
    {
      await _context.Set<Users>().AddAsync(users);
    }

    public async Task<Users?> GetUserWithDetail(string email)
    {
        return await _context.Set<Users>()
                .Include(x => x.UserDetail)
                .FirstOrDefaultAsync(x => x.Email == email);
    }

    public void UpdateUsers(Users users)
    {
        throw new NotImplementedException();
    }
}
