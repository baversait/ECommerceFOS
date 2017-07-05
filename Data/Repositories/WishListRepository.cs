using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class WishListRepository : RepositoryBase<WishList>, IWishListRepository
    {
        public WishListRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IWishListRepository : IRepository<WishList>
    {

    }
}
