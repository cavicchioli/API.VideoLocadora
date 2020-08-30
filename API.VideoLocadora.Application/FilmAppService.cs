using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Inferfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application
{
    public class FilmAppService : IFilmAppService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmAppService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }
        
        public IEnumerable<Film> GetFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        public Film GetFilmById(int id)
        {
            return _filmRepository.GetFilmById(id);
        }

        public string PostFilm(Film film)
        {
            Film db = _filmRepository.GetFilmById(film.Id);
            if (db == null)
            {
                bool result = _filmRepository.CreateNewFilm(db);

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

        public string DeleteFilm(int id)
        {
            Film db = _filmRepository.GetFilmById(id);
            if (db != null)
            {
                bool result = _filmRepository.DeleteFilm(db.Id);

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
                return "Filme Existente";
            }

        }
    }
}
