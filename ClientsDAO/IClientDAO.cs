using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsDAO
{
    interface IClientDAO
    {
        void AddNewClient(ContactFormPerson formPerson);
        ContactFormPerson GetClient(string personId);
        void UpdateClient(ContactFormPerson formPerson);
    }
}
