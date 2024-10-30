using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Jewelry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories;

public class EfReviewRepository : EfGenericRepository<Review>, IReviewRepository
{
    public EfReviewRepository(JewelryStoreContext dbContext) : base(dbContext)
    {
    }
}
