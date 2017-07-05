using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class TownRepository : RepositoryBase<Town>, ITownRepository
    {
        public TownRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ITownRepository : IRepository<Town>
    {

    }
}
