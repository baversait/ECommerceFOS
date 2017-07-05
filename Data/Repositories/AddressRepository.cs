using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IAddressRepository : IRepository<Address>
    {

    }
}
