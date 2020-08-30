using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Domain.Inferfaces
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        Film GetFilmById(int id);
        bool CreateNewFilm(Film newFilm);
        bool DeleteFilm(int id);
    }
}
