using Common.Models;

namespace ClientsDAO
{
    public interface IClientDAO
    {
        void AddNewClient(Client client);
        Client GetClient(string personId);
        void UpdateClient(Client client);
    }
}
