using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application
{
    public class FilmAppService : IFilmAppService
    {

        //cadastrar um filme, 


        public IEnumerable<Film> GetFilms()
        {
            return new List<Film>();
        }

        public Film GetFilmById(int id)
        {
            return null;
        }

        public void PostFilm(Film film)
        {

        }

        public void PutFilm(Film film)
        {

        }

        public void DeleteFilm(int id)
        {

        }
    }
}
