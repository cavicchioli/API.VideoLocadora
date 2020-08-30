using API.VideoLocadora.Domain.Models;
using System.Collections.Generic;

namespace API.VideoLocadora.Application.Interfaces
{
    public interface IRentalAppService
    {
        IEnumerable<Rent> GetRetalList();

        void RentFilm(int clientId, int filmId, int period);

        void ReturnFilm(int clientId, int filmId);
    }
}
