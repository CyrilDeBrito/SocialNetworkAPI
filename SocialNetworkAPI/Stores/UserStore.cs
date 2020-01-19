using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkAPI.Stores
{
    public class UserStore : IUserStore
    {
        public UserStore() { }

        public List<User> Store { get; } = new List<User>();

        public int AddUser(User user)
        {
            user.Id = Store.Any() ? (Store.Max(b => b.Id) + 1) : 1;
            Store.Add(user);
            return user.Id;
        }

        public int DeleteUser(User user)
        {
            var userItem = Store.FirstOrDefault(u => u.Id == user.Id);
            if (userItem == null)
            {
                return -1;
            }
            Store.RemoveAt(user.Id);
            return user.Id;
        }
    }
}
