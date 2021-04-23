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

        private List<Client> cachedClients;
        public ClientFileDAO(ConfigMgr configMgr)
        {
            CLIENTS_ARCHIVE_FILE_PATH = configMgr.GetClientArchivePathPath();

            using (FileStream stream = new FileStream(CLIENTS_ARCHIVE_FILE_PATH, FileMode.OpenOrCreate));

            cachedClients = ReadClients() ?? new List<Client>();
        }

        public void AddNewClient(Client formPerson)
        {
            List<Client> clients = cachedClients;
            clients.Add(formPerson);

            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(CLIENTS_ARCHIVE_FILE_PATH, json);
        }

        public Client GetClient(string personId)
        {
            List<Client> clients = cachedClients;
            Client matchedClient = clients.Find((client) => 
                            client.ContactForm.Person_1.Id == personId || client.ContactForm.Person_2.Id == personId);
            
            return matchedClient;
        }

        public void UpdateClient(Client formPerson)
        {
            throw new NotImplementedException();
        }

        private List<Client> ReadClients()
        {
            using (StreamReader r = new StreamReader(CLIENTS_ARCHIVE_FILE_PATH))
            {
                string json = r.ReadToEnd();
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(json);

                return clients;
            }
        }
    }
}
