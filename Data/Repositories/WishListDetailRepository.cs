using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class WishListDetailRepository : RepositoryBase<WishListDetail>, IWishListDetailRepository
    {
        public WishListDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IWishListDetailRepository : IRepository<WishListDetail>
    {

    }
}
