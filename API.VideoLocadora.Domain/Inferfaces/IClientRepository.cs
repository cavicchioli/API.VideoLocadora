using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Domain.Inferfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(long cpf);
        bool CreateNewClient(Client newClient);
        bool DeleteClient(long cpf);
    }
}
