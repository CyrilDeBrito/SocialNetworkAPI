using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Publication model
/// int Id
/// String Title
/// String Description
/// List<Comment> Comments
/// </summary>

namespace SocialNetworkAPI.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
