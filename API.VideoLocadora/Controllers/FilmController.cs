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
    [Route("api/films")]
    public class FilmController : Controller
    {
        private readonly IFilmAppService _filmAppService;

        public FilmController(IFilmAppService filmAppService)
        {
            _filmAppService = filmAppService;
        }

        [HttpGet(Name = "GetFilms")]
        [ProducesResponseType(typeof(IEnumerable<Film>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IEnumerable<Film> GetFilms()
        {
            return _filmAppService.GetFilms();
        }

        [HttpGet(Name = "GetFilmById")]
        [ProducesResponseType(typeof(Film), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public Film GetFilmById([FromQuery] int id)
        {
            return _filmAppService.GetFilmById(id);
        }


        [HttpPost(Name = "PostFilm")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string PostFilm([FromBody] Film film)
        {

            return _filmAppService.PostFilm(film);

        }

        [HttpPost("{id}", Name = "DeleteFilm")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public string DeleteFilm([FromRoute] int id)
        {
            return _filmAppService.DeleteFilm(id);
        }


    }
}
