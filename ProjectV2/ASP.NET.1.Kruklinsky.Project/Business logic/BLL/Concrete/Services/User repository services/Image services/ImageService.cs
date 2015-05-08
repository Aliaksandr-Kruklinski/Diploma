using AmbientDbContext.Interface;
using BLL.Concrete.ExceptionsHelpers;
using BLL.Interface.Abstract;
using DAL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ImageService : RepositoryService<IUserRepository>, IImageService
    {
        public ImageService(IUserRepository userRepository, IDbContextScopeFactory dbContextScopeFactory) : base(userRepository, dbContextScopeFactory) { }

        public void LoadImage(string id, Interface.Entities.Image image)
        {
            UserExceptionsHelper.GetIdExceptions(id);
            if (image == null)
            {
                throw new System.ArgumentNullException("image", "Image is null.");
            }
            using (var context = dbContextScopeFactory.Create())
            {
                this.repository.LoadImage(id, image.ToDal());
                context.SaveChanges();
            }
        }
    }
}
