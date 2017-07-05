using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class CartDetailRepository : RepositoryBase<CartDetail>, ICartDetailRepository
    {
        public CartDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public CartDetail GetByTwoId(int cartID, int productDetailId)
        {
            CartDetail cd = this.dbSet.Find(cartID, productDetailId);
            return cd;
        }
    }

    public interface ICartDetailRepository : IRepository<CartDetail>
    {
        CartDetail GetByTwoId(int cartID, int productDetailId);
    }
}
