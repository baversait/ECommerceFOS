using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Data.Infrastructure;

namespace Data.Repositories
{

    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICurrencyRepository : IRepository<Currency>
    {

    }
}
