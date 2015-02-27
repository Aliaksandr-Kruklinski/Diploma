using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Domain.Abstract
{
    public interface IImageRepository
    {
        IQueryable<Image> Images { get; }

        void SaveImage (Image image);

        Image GetAvatar(string userId);
    }
}
