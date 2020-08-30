using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.VideoLocadora.Application.Interfaces
{
    public interface IRentalAppService
    {
        IEnumerable<Rent> GetAllRents();

        Rent GetRentById(long clientCpf, int filmId, DateTime dataInicio);

        string CreateNewRent(long clientCpf, int filmId, int periodo);

        string DevolverFilme(long clientCpf, int filmId, DateTime dataLocacao);

        
    }
}
