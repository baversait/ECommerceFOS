using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    
    public class FeaturedProductsRepository : RepositoryBase<FeaturedProduct>, IFeaturedProductsRepository
    {
        public FeaturedProductsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IFeaturedProductsRepository : IRepository<FeaturedProduct>
    {

    }
}
