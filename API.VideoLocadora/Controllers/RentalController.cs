using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.VideoLocadora.Controllers
{
    [Produces("application/json")]
    [Route("api/retals")]
    public class RentalController : Controller
    {
        private readonly IRentalAppService _rentalAppService;

        public RentalController(IRentalAppService rentalAppService)
        {
            _rentalAppService = rentalAppService;
        }

        [HttpGet(Name = "GetAllRents")]
        [ProducesResponseType(typeof(IEnumerable<Rent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Rent> GetAllRents()
        {
            return _rentalAppService.GetAllRents();
        }

        [HttpGet(Name = "GetRentById")]
        [ProducesResponseType(typeof(Rent), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Rent GetRentById([FromQuery] long clientCpf, [FromQuery] int filmId, [FromQuery] DateTime dataInicio)
        {
            return _rentalAppService.GetRentById(clientCpf, filmId, dataInicio);
        }


        [HttpPost(Name = "CreateNewRent")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string CreateNewRent([FromBody] Models.Retal retal)
        {
            return _rentalAppService.CreateNewRent(retal.clientCpf, retal.filmId, retal.periodo);
        }

        [HttpPost(Name = "DevolverFilme")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DevolverFilme([FromBody] Models.Return ret)
        {
            return _rentalAppService.DevolverFilme(ret.clientCpf, ret.filmId, ret.dataLocacao);
        }

    }
}
