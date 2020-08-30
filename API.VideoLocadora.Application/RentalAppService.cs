using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Domain.Inferfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace API.VideoLocadora.Application
{
    public class RentalAppService : IRentalAppService
    {

        private readonly IClientRepository _clientRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IRentRepository _rentRepository;

        public RentalAppService(IClientRepository clientRepository, IFilmRepository filmRepository, IRentRepository rentRepository)
        {
            _clientRepository = clientRepository;
            _filmRepository = filmRepository;
            _rentRepository = rentRepository;
        }

        public IEnumerable<Rent> GetAllRents()
        {
            return _rentRepository.GetAllRents();
        }

        public Rent GetRentById(long clientCpf, int filmId, DateTime dataInicio)
        {
            return _rentRepository.GetRentById(clientCpf, filmId, dataInicio);
        }

        public string CreateNewRent(long clientCpf, int filmId, int periodo)
        {
            DateTime hoje = DateTime.Now;

            Film film = _filmRepository.GetFilmById(filmId);
            if (film != null && film.Status == "Disponivel")
            {
                Client client = _clientRepository.GetClientById(clientCpf);
                if (client != null)
                {

                    Rent Locacao = new Rent(client, film, hoje, null, periodo, true, 0);

                    if (_rentRepository.CreateNewRent(Locacao))
                    {
                        _filmRepository.UpdateFilmStatus(film.Id, "Indisponivel");

                        return "Filme locado com sucesso";
                    }
                    else
                    {
                        return $"Nao foi possivel Locar o Filme: { film.Name }";
                    }
                }
                else
                {
                    return $"Nao foi possivel Locar o Filme: { film.Name }, cliente nao existe.";
                }
            }
            else
            {
                return "Filme indisponivel.";
            }
        }

        public string DevolverFilme(long clientCpf, int filmId, DateTime dataLocacao)
        {
            Rent locacao = _rentRepository.GetRentById(clientCpf, filmId, dataLocacao);

            if (locacao != null && locacao.EndDate == null)
            {
                locacao.EndDate = DateTime.Now;

                if (_rentRepository.DevolverFilme(locacao))
                {
                    _filmRepository.UpdateFilmStatus(locacao.Film.Id, "Disponivel");

                    return "Filme devolvido com sucesso";
                }
                else
                {
                    return "Nao foi possivel devolver o filme";
                }
            }
            else
            {
                return "Locacao Inexistente ou ja devolvida";
            }
        }

    }
}
