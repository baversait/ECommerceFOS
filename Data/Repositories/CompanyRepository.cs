using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory, IAddressRepository addressRepository) : base(dbFactory)
        {
            this.addressRepository = addressRepository;
        }

        private readonly IAddressRepository addressRepository;
        public override void Add(Company entity)
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

        public override void Update(Company entity)
        {
            addressRepository.Update(entity.Address);
            addressRepository.Save();
            base.Update(entity);
        }
    }

    public interface ICompanyRepository : IRepository<Company>
    {

    }
}
