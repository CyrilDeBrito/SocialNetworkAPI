using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Stores
{
    public class UserStore : IUserStore
    {
        public UserStore() { }

        public List<User> Store { get; } = new List<User>();
    }
}
