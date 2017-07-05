using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LastSeenProductsRepository : RepositoryBase<LastSeenProducts>, ILastSeenProductsRepository
    {
        public LastSeenProductsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ILastSeenProductsRepository : IRepository<LastSeenProducts>
    {

    }
}
