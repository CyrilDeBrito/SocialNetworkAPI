using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Stores
{
    public class PublicationStore : IPublicationStore
    {
        public PublicationStore() { }

        public List<Publication> Store { get; } = new List<Publication>();

        public int AddPublication(Publication publication)
        {
            publication.Id = Store.Any() ? (Store.Max(b => b.Id) + 1) : 1;
            Store.Add(publication);
            return publication.Id;
        }

        public int DeletePublication(Publication publication)
        {
            var publicationItem = Store.FirstOrDefault(u => u.Id == publication.Id);
            if (publicationItem == null)
            {
                return -1;
            }
            Store.RemoveAt(publication.Id);
            return publication.Id;
        }
    }
}
