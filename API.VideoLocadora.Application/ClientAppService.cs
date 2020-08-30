using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Inferfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application
{
    public class ClientAppService : IClientAppService
    {

        private readonly IClientRepository _clientRepository;

        public ClientAppService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(long cpf)
        {
            return _clientRepository.GetClientById(cpf);
        }

        public string PostClient(Client client)
        {

            Client dbClient = _clientRepository.GetClientById(client.Cpf);
            if (dbClient == null)
            {
                bool result = _clientRepository.CreateNewClient(client);

               if (result)
                {
                    return "Registro Inserido";
                }
                else
                {
                    return "Erro ao Inserir Registo";
                }
                
            }
            else
            {
                return "Cliente Existente";
            }
            
        }

        public string DeleteClient(long cpf)
        {

            Client dbClient = _clientRepository.GetClientById(cpf);
            if (dbClient != null)
            {
                bool result = _clientRepository.DeleteClient(dbClient.Cpf);

                if (result)
                {
                    return "Registro Excluido";
                }
                else
                {
                    return "Erro ao Excluir Registo";
                }

            }
            else
            {
                return "Cliente Existente";
            }

        }

    }
}
