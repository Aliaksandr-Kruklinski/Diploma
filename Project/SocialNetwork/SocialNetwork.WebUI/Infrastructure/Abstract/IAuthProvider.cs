using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, bool rememberMe);
        bool Register(
                string username,
                string password,
                string email,
                string passwordQuestion,
                string passwordAnswer,
                bool isApproved,
                object providerUserKey,
                out string error
            );
        void LogOut();
    }
}
