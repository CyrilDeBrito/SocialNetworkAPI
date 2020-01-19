using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The user model
/// int Id
/// String Firstname
/// String Lastname
/// String Pseudo
/// DateTime BirthDay
/// List<Publication> Publications
/// </summary>

namespace SocialNetworkAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Pseudo { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Publication> Publications { get; set; }
    }
}
