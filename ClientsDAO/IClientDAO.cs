using Common.Models;

namespace ClientsDAO
{
    public interface IClientDAO
    {
        void AddNewClient(ContactFormPerson formPerson);
        ContactFormPerson GetClient(string personId);
        void UpdateClient(ContactFormPerson formPerson);
    }
}
