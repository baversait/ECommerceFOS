using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        private readonly IAddressRepository addressRepository;
        private readonly IImageRepository imageRepository;

        public BrandRepository(IDbFactory dbFactory, IAddressRepository addressRepository, IImageRepository imageRepository) : base(dbFactory)
        {
            this.addressRepository = addressRepository;
            this.imageRepository = imageRepository;
        }

        public override void Add(Brand entity)
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

        public override void Delete(Brand entity)
        {
            if (entity.Images.Count > 0)
            {
                imageRepository.Delete(entity.Images.ToList()[0]);
            }
            base.Delete(entity);
        }
    }

    public interface IBrandRepository : IRepository<Brand>
    {

    }
}
