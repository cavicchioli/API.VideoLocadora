using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.VideoLocadora.Controllers
{
    [Produces("application/json")]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }


        [HttpGet(Name = "GetClients")]
        [ProducesResponseType(typeof(IEnumerable<Client>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Client> GetClients()
        {
            return _clientAppService.GetClients();
        }

        [HttpGet(Name = "GetClientById")]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Client GetClientById([FromQuery]long cpf)
        {
            return _clientAppService.GetClientById(cpf);
        }


        [HttpPost(Name = "PostClient")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string PostClient([FromBody]Client client)
        {

            return _clientAppService.PostClient(client);

        }

        [HttpPost("{cpf}",Name = "DeleteClient")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DeleteClient([FromRoute]long cpf)
        {
            return _clientAppService.DeleteClient(cpf);
        }

    }
}
