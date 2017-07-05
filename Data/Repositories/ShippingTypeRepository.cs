using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class ShippingTypeRepository : RepositoryBase<ShippingType>, IShippingTypeRepository
    {
        public ShippingTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IShippingTypeRepository : IRepository<ShippingType>
    {

    }
}
