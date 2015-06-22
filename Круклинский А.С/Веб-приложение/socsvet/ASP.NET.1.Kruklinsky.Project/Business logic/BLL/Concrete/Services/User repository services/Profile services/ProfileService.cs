﻿using AmbientDbContext.Interface;
using BLL.Concrete.ExceptionsHelpers;
using BLL.Interface.Abstract;
using BLL.Interface.Entities;
using DAL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProfileService : RepositoryService<IUserRepository>, IProfileService
    {
        public ProfileService(IUserRepository userRepository, IDbContextScopeFactory dbContextScopeFactory) : base(userRepository, dbContextScopeFactory) { }

        #region IProfileService

        public Profile GetUserProfile(string id)
        {
            UserExceptionsHelper.GetIdExceptions(id);
            Profile result = null;
            using (var context = dbContextScopeFactory.CreateReadOnly())
            {
                var profile = this.repository.GetUserProfile(id);
                if (profile != null)
                {
                    result = profile.ToBll();
                }
            }
            return result;
        }
        public void UpdateUserProfile(string id, Profile profile)
        {
            UserExceptionsHelper.GetIdExceptions(id);
            if (profile == null)
            {
                throw new System.ArgumentNullException("profile", "Profile is null.");
            }
            using (var context = dbContextScopeFactory.Create())
            {
                var user = this.repository.GetUser(id);
                if (user != null)
                {
                    DAL.Interface.Entities.Image avatar = null;
                    if (profile.Avatar != -1 && user.Images != null)
                    {
                        avatar = user.Images.Value.Where(i => i.Id == profile.Avatar).First();
                    }
                    this.repository.UpdateUserProfile(id, profile.ToDal(avatar));
                    context.SaveChanges();
                }
            }
        }

        #endregion
    }
}
