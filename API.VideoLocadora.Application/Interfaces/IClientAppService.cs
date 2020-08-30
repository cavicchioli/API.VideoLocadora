using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application.Interfaces
{
    public interface IClientAppService
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(long cpf);
        string PostClient(Client film);
        string DeleteClient(long cpf);
    }
}
