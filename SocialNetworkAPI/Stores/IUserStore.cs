using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Stores
{
    public interface IUserStore
    {
        List<User> StoreUsers { get; }
    }
}
