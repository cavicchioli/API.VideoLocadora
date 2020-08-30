using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application.Interfaces
{
    public interface IFilmAppService
    {
        IEnumerable<Film> GetFilms();
        Film GetFilmById(int id);
        string PostFilm(Film film);
        string DeleteFilm(int id);
    }
}
