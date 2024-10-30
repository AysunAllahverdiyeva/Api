using JewelryStore.Application.Interfaces;
using JewelryStore.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks.Repositories
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly JewelryStoreContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitOfwork(JewelryStoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _httpContextAccessor = httpContextAccessor;
            _context.Database.BeginTransactionAsync();
            
        }
        public ICategoryRepository CategoryRepository => SetRepository<ICategoryRepository>();

        public IProductRepository ProductRepository => SetRepository<IProductRepository>();

        public ISubCategoryRepository SubCategoryRepository => SetRepository<ISubCategoryRepository>();

        public IProductDetailRepository ProductDetailRepository => SetRepository<IProductDetailRepository>();

        public ICartItemRepository CartItemRepository => SetRepository<ICartItemRepository>();

        public IDesignersRepository DesignersRepository => SetRepository<IDesignersRepository>();

        public IImagesRepository ImagesRepository => SetRepository<IImagesRepository>();

        public IReviewRepository ReviewRepository => SetRepository<IReviewRepository>();

        public IUserDetailRepository UserDetailRepository => SetRepository<IUserDetailRepository>();

        public IUserRepository UserRepository => SetRepository<IUserRepository>();

        public IUsersRoleRepository UsersRoleRepository => SetRepository<IUsersRoleRepository>();
        public IRoleRepository RoleRepository => SetRepository<IRoleRepository>();

        public async Task CommitTransaction()
        {
            await _context.Database.CommitTransactionAsync();
        }


        public async Task Commit(CancellationToken cancellationToken = default)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<EntityEntry<BaseEntity>> entities = _context
              .ChangeTracker
              .Entries<BaseEntity>()
              .ToList();

            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedId = Convert.ToInt32(userId);

                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedId = Convert.ToInt32(userId);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await CommitTransaction();

        }

        
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                { 
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            
            }
        }

        public TRepository SetRepository<TRepository>()
        {
            if (_repositories.ContainsKey(typeof(TRepository)))
            {
                return (TRepository)_repositories[typeof(TRepository)];
            }

            var repositoryType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => !x.IsInterface && x.IsClass && x.IsAssignableTo(typeof(TRepository)));

            var repositoryInstance = (TRepository)Activator.CreateInstance(repositoryType, _context);
            _repositories.Add (typeof(TRepository),repositoryInstance);
            return repositoryInstance;
        }
    }
}
