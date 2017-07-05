using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class CouponRepository : RepositoryBase<Coupons>, ICouponRepository
    {
        public CouponRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICouponRepository : IRepository<Coupons>
    {

    }
}
