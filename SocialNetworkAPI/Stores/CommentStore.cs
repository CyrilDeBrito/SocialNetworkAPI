using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Stores
{
    public class CommentStore : ICommentStore
    {
        public CommentStore() { }

        public List<Comment> Store { get; } = new List<Comment>();

        public int AddComment(Comment comment)
        {
            comment.Id = Store.Any() ? (Store.Max(b => b.Id) + 1) : 1;
            Store.Add(comment);
            return comment.Id;
        }

        public int DeleteComment(Comment comment)
        {
            var commentItem = Store.FirstOrDefault(u => u.Id == comment.Id);
            if (commentItem == null)
            {
                return -1;
            }
            Store.RemoveAt(comment.Id);
            return comment.Id;
        }
    }
}
