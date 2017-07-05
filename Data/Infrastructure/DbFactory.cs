using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        ECommerceEntities dbContext;

        public ECommerceEntities Init()
        {
            return dbContext ?? (dbContext = new ECommerceEntities());
        }

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
