using SocialNetworkAPI.Models;
using System.Collections.Generic;


namespace SocialNetworkAPI.Stores
{
    public interface IUserStore
    {
        List<User> Store { get; }

        int AddUser(User user);
        // int Delete(int id);
        // int Update(int id, User user);
    }
}
