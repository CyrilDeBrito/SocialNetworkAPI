using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Stores
{
    public interface ICommentStore
    {
        List<Comment> Store { get; }

        int AddComment(Comment comment);

        int DeleteComment(Comment comment);
    }
}
