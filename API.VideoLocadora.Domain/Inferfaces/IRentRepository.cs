using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Domain.Inferfaces
{
    public interface IRentRepository
    {
        IEnumerable<Rent> GetAllRents();
        Rent GetRentById(long clientCpf, int filmId, DateTime dataInicio);
        bool CreateNewRent(Rent newRent);
        bool DevolverFilme(Rent devolucao);
    }
}
