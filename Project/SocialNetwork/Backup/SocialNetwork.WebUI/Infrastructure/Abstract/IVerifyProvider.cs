using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.WebUI.Infrastructure.Abstract
{
    public interface IVerifyProvider
    {
        bool IsApproved(string username);
        bool Verify(string username, string secretCode);
    }
}
