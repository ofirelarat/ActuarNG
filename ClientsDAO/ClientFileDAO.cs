using Common.Models;
using SettingMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsDAO
{
    public class ClientFileDAO : IClientDAO
    {
        private string CLIENTS_ARCHIVE_FILE_PATH;
        public ClientFileDAO(ConfigMgr configMgr)
        {
            CLIENTS_ARCHIVE_FILE_PATH = configMgr.GetClientArchivePathPath();
        }

        public void AddNewClient(ContactFormPerson formPerson)
        {
            throw new NotImplementedException();
        }

        public ContactFormPerson GetClient(string personId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ContactFormPerson formPerson)
        {
            throw new NotImplementedException();
        }
    }
}
