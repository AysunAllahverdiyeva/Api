using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Interfaces;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellation=default);
    void RollBack();
    TRepository SetRepository<TRepository>();
    TRepository GetRepository<TRepository>() where TRepository : class;
    Task CommitTransaction();

    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    ISubCategoryRepository SubCategoryRepository { get; }
    IProductDetailRepository ProductDetailRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    IDesignersRepository DesignersRepository { get; }
    IImagesRepository ImagesRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IUserDetailRepository UserDetailRepository { get; }
    IUserRepository UserRepository { get; }
    IUsersRoleRepository UsersRoleRepository { get; }
    IRoleRepository RoleRepository { get; }

}
