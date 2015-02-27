using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Domain.Concrete
{
    public class EFImageRepository : IImageRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Image> Images
        {
            get
            {
                return context.Images;
            }
        }

        public void SaveImage(Image image)
        {
            if (image.ImageID != null || image.ImageID != "")
            {
                if (context.ExistImage(image))
                {
                    context.ChangeImage(image);
                }
                else
                {
                    context.Images.Add(image);
                }
            }
            else
            {
                image.ImageID = Guid.NewGuid().ToString();
                while (context.ExistImage(image)) {image.ImageID = Guid.NewGuid().ToString();}
                context.Images.Add(image);
            }
            context.SaveChanges();
        }

        public Image GetAvatar(string userId)
        {
             var qeury = Images.Where(x => x.ImageID == userId);
             if (qeury.Count() != 0)
             {
                 return qeury.First();
             }
             return null;
        }
    }
}
