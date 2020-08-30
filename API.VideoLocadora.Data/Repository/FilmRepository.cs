using API.VideoLocadora.Domain.Inferfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.VideoLocadora.Data.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private List<Film> films;

        public FilmRepository()
        {
            films = new List<Film>
            {
                new Film(1, "Star Wars","Genero 1", "Available", true),
                new Film(2, "O Poderoso Chefao","Genero 2","Available", true),
                new Film(3, "Branca de Neve", "Genero 3","Available", true),
                new Film(4, "Frozen", "Genero 3","Available", true)
            };
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return films;
        }

        public Film GetFilmById(int id)
        {
            return films
                .Where(x => x.Id == id && x.Active==true)
                .FirstOrDefault();
        }

        public bool CreateNewFilm(Film newFilm)
        {
            Film filmeRepitido = GetFilmById(newFilm.Id);

            if (filmeRepitido == null || filmeRepitido.Active==false)
            {
                films.Add(newFilm);
                return true;
            }
            else
            {
                return false;
            } 
        }

        public bool DeleteFilm(int id)
        {
            Film filme = GetFilmById(id);

            if (filme != null && filme.Active == true)
            {
                films.Remove(filme);
                filme.Active = false;
                films.Add(filme);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateFilmStatus(int id, string status)
        {
            Film filme = GetFilmById(id);

            if (filme != null && filme.Active == true)
            {
                films.Remove(filme);
                filme.Status = status;
                films.Add(filme);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
} 
