using Common.Models;
using System.Collections.Generic;

namespace ClientsDAO
{
    public interface IClientDAO
    {
        void AddNewClient(Client client);
        Client GetClient(string personId);
        List<Client> GetClients();
        void UpdateClient(Client client);
    }
}
