using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Tables
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceTable<Client> _table;
        
        public AzureClient()
        {
            _client = new MobileServiceClient("http://xamarintestuninorte.azurewebsites.net");
            _table = _client.GetTable<Client>();
        }

        public Task<IEnumerable<Client>> GetClients()
        {
            return _table.ToEnumerableAsync();
        }

        public async void SaveClient(Client client)
        {
            await _table.InsertAsync(client);
        }

    }
}
