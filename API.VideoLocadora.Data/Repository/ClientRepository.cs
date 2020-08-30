using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.VideoLocadora.Data.Repository
{
    public class ClientRepository
    {
  
        private List<Client> clients;

        public ClientRepository()
        {
            clients = new List<Client>
            {
                new Client(22222222222, "Nome 1", "(11) 95862-8596", "email@gmail.com", true),
                new Client(11111111111, "Nome 2", "(11) 40002-2020", "email@yahoo.com", true),
            };
        }

        public IEnumerable<Client> GetAllClients()
        {
            return clients;
        }

        public Client GetClientById(long cpf)
        {
            return clients.Where(client=>client.Cpf == cpf && client.Active ==true).FirstOrDefault();
        }

        public bool CreateNewClient(Client newClient)
        {
            Client client = GetClientById(newClient.Cpf);

            if (client == null || client.Active == false)
            {
                clients.Add(client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteClient(long cpf)
        {
            Client client = GetClientById(cpf);

            if (client != null && client.Active == true)
            {
                clients.Remove(client);
                client.Active = false;
                clients.Add(client);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
