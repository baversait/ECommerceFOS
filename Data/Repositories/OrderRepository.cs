using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{    
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory, IAddressRepository addressRepository) : base(dbFactory)
        {
            this.addressRepository = addressRepository;
        }

        private readonly IAddressRepository addressRepository;
        public override void Add(Order entity)
        {
            using (var dbContextTransaction = dataContext.Database.BeginTransaction())
            {
                try
                {
                    if (entity.Address != null)
                    {
                        addressRepository.Add(entity.Address);
                        addressRepository.Save();
                    }
                    base.Add(entity);
                    base.Save();
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        public List<ProductDetail> GetBestSellers()
        {
            var orderDetails = this.GetAll()
                .SelectMany(x => x.OrderDetails)
                .GroupBy(x => x.ProductDetail)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Take(10)
                .ToList();

            return orderDetails;
        }
    }

    public interface IOrderRepository : IRepository<Order>
    {
        List<ProductDetail> GetBestSellers();
    }
}
