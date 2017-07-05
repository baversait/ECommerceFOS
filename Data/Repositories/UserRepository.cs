using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IAddressRepository addressRepository;
        private readonly ICartRepository cartRepository;
        private readonly IWishListRepository wishListRepository;

        public UserRepository(IDbFactory dbFactory,
            IAddressRepository addressRepository,
            ICartRepository cartRepository,
            IWishListRepository wishListRepository) : base(dbFactory)
        {
            this.addressRepository = addressRepository;
            this.cartRepository = cartRepository;
            this.wishListRepository = wishListRepository;
        }

        public override void Add(User entity)
        {
            using (var dbContextTransaction = dataContext.Database.BeginTransaction())
            {
                try
                {
                    if (entity.Address != null)
                    {
                        addressRepository.Add(entity.Address);
                        addressRepository.Save();
                    }
                    base.Add(entity);
                    base.Save();

                    Cart cart = new Cart();
                    cart.CustomerID = entity.UserID;
                    cartRepository.Add(cart);
                    cartRepository.Save();

                    WishList wishList = new WishList();
                    wishList.CustomerID = entity.UserID;
                    wishListRepository.Add(wishList);
                    wishListRepository.Save();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }
    }

    public interface IUserRepository : IRepository<User>
    {

    }
}
