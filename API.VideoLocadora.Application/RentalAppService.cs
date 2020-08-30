using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Application
{
    public class RentalAppService : IRentalAppService
    {
        //locar um filme e devolver um filme.

        public IEnumerable<Rent> GetRetalList()
        {
            return new List<Rent>();
        }

        public void RentFilm(int clientId, int filmId, int period)
        {

        }

        public void ReturnFilm(int clientId, int filmId)
        {

        }



    }
}
