using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application.Interfaces
{
    public interface IFilmAppService
    {
        IEnumerable<Film> GetFilms();
        void PostFilm(Film film);
        void PutFilm(Film film);
        void DeleteFilm(int id);
    }
}
