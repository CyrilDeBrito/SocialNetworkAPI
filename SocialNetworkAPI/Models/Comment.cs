using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Comment model
/// int Id
/// String Commentary
/// </summary>

namespace SocialNetworkAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Commentary { get; set; }
    }
}
