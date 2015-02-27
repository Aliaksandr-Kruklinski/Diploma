using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SocialNetwork.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }

        internal void ChangeImage(Image image)
        {
            var qeury = Images.Where(x => x.ImageID == image.ImageID);
            if (qeury.Count() != 0)
            {
                var item = qeury.First();
                item.ImageData = image.ImageData;
                item.ImageMimeType = image.ImageMimeType;
            }
        }

        internal bool ExistImage(Image image)
        {
            var qeury = Images.Where(x => x.ImageID == image.ImageID);
            if (qeury.Count() == 0) return false;
            return true;
        }
    }
}
