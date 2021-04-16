using Common.Models;
using Newtonsoft.Json;
using SettingMgr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClientsDAO
{
    public class ClientFileDAO : IClientDAO
    {
        private string CLIENTS_ARCHIVE_FILE_PATH;

        private List<ContactFormPerson> cachedClients;
        public ClientFileDAO(ConfigMgr configMgr)
        {
            CLIENTS_ARCHIVE_FILE_PATH = configMgr.GetClientArchivePathPath();

            using (FileStream stream = new FileStream(CLIENTS_ARCHIVE_FILE_PATH, FileMode.OpenOrCreate));

            cachedClients = ReadClients() ?? new List<ContactFormPerson>();
        }

        public void AddNewClient(ContactFormPerson formPerson)
        {
            List<ContactFormPerson> clients = cachedClients;
            clients.Add(formPerson);

            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(CLIENTS_ARCHIVE_FILE_PATH, json);
        }

        public ContactFormPerson GetClient(string personId)
        {
            List<ContactFormPerson> clients = cachedClients;
            ContactFormPerson matchedClient = clients.Find((contactForm) => 
                            contactForm.Person_1.Id == personId || contactForm.Person_2.Id == personId);
            
            return matchedClient;
        }

        public void UpdateClient(ContactFormPerson formPerson)
        {
            throw new NotImplementedException();
        }

        private List<ContactFormPerson> ReadClients()
        {
            using (StreamReader r = new StreamReader(CLIENTS_ARCHIVE_FILE_PATH))
            {
                string json = r.ReadToEnd();
                List<ContactFormPerson> clients = JsonConvert.DeserializeObject<List<ContactFormPerson>>(json);

                return clients;
            }
        }
    }
}
