using SocialNetworkAPI.Models;
using System.Collections.Generic;

namespace SocialNetworkAPI.Stores
{
    public interface IPublicationStore
    {
        List<Publication> Store { get; }

        int AddPublication(Publication publication);
    }
}
