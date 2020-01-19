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
    }
}
