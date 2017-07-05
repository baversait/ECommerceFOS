using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        private IImageRepository imageRepository;
        public SubCategoryRepository(IDbFactory dbFactory, IImageRepository imageRepository) : base(dbFactory)
        {
            this.imageRepository = imageRepository;
        }

        public override void Add(SubCategory entity)
        {
            if (entity.Images.Count != 0)
            {
                foreach (var image in entity.Images)
                {
                    imageRepository.Add(image);
                }
                imageRepository.Save();
            }
            base.Add(entity);
        }
    }

    public interface ISubCategoryRepository : IRepository<SubCategory>
    {

    }
}
