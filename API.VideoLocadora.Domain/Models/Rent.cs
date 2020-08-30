using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace API.VideoLocadora.Domain.Models
{
    public class Rent
    {
        public Rent(Client client, Film film, DateTime startDate, DateTime endDate, int period, bool active) {

            Client = client;
            Film = film;
            StartDate = startDate;
            EndDate = endDate;
            Period = period;
            Active = active;
        }

        public Client Client { get; set; }

        public Film Film { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public int Period { get; set; }

        public bool Active { get; set; }

    }
}