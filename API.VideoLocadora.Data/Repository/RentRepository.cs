using API.VideoLocadora.Domain.Inferfaces;
using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace API.VideoLocadora.Data.Repository
{
    public class RentRepository : IRentRepository
    {
        private List<Rent> rents;
        public RentRepository()
        {
            rents = new List<Rent>()
            {
            };
        }

        public IEnumerable<Rent> GetAllRents()
        {
            foreach (var rent in rents)
            {
                int delay = CalculaAtraso(rent);

                if (delay>0)
                {
                    rents.Remove(rent);
                    rent.DelayDays = delay;
                    rents.Add(rent);

                }
            }

            return rents;
        }

        public Rent GetRentById(long clientCpf, int filmId, DateTime dataInicio)
        {
            Rent rent = rents
                .Where(rent => rent.Client.Cpf == clientCpf 
                && rent.Film.Id == filmId 
                && rent.Active == true
                && rent.StartDate == dataInicio)
                .FirstOrDefault();

            if(rent != null)
            {
               
                int delay = CalculaAtraso(rent);

                if (delay > 0)
                {
                    rents.Remove(rent);
                    rent.DelayDays = delay;
                    rents.Add(rent);

                }
            }

            return rent;
        }

        public bool CreateNewRent(Rent newRent)
        {
            Rent locacaoRepitida = GetRentById(newRent.Client.Cpf, newRent.Film.Id, newRent.StartDate);

            if (locacaoRepitida == null || locacaoRepitida.Active == false)
            {
                rents.Add(newRent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DevolverFilme(Rent devolucao)
        {
            Rent locacao = GetRentById(devolucao.Client.Cpf, devolucao.Film.Id, devolucao.StartDate);

            if (locacao != null && locacao.Active == true)
            {
                int delay = CalculaAtraso(locacao);
                rents.Remove(locacao);

                if (delay > 0)
                {
                    locacao.DelayDays = delay;
                }

                locacao.EndDate = DateTime.Now;

                rents.Add(locacao);

                return true;
            }
            else
            {
                return false;
            }
        }

        private int CalculaAtraso(Rent locacao)
        {
            DateTime inicio = locacao.StartDate;
            return (DateTime.Now - inicio.AddDays(locacao.Period)).Days;
        }

    }
}
 