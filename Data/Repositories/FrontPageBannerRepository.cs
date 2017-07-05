using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class FrontPageBannerRepository : RepositoryBase<FrontPageBanner>, IFrontPageBannerRepository
    {
        private readonly IImageRepository imageRepository;

        public FrontPageBannerRepository(IDbFactory dbFactory,
            IImageRepository imageRepository) : base(dbFactory)
        {
            this.imageRepository = imageRepository;
        }

        public override void Add(FrontPageBanner entity)
        {
            if (entity.Images.Count != 0)
            {
                foreach (var image in entity.Images)
                {
                    image.FrontPageBannerID = entity.FrontPageBannerID;
                    imageRepository.Add(image);
                }
            }
            base.Add(entity);
        }

        public override void Update(FrontPageBanner entity)
        {
            if (entity.Images.Count != 0)
            {
                foreach (var image in entity.Images)
                {
                    imageRepository.Update(image);
                }
            }
            base.Update(entity);
        }

        public override void Delete(FrontPageBanner entity)
        {
            if (entity.Images.Count != 0)
            {
                imageRepository.Delete(entity.Images.ToList()[0]);
            }
            base.Delete(entity);
        }
    }

    public interface IFrontPageBannerRepository : IRepository<FrontPageBanner>
    {

    }
}
