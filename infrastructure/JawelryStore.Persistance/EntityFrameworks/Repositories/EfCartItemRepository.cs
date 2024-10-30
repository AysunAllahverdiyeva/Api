using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories;

public class EfCartItemRepository : EfGenericRepository<CartItems>, ICartItemRepository
{
    public EfCartItemRepository(JewelryStoreContext dbContext) : base(dbContext)
    {
    }
}
