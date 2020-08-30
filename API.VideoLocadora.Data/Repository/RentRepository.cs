using API.VideoLocadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.Data.Repository
{
    public class RentRepository
    {
        private List<Rent> rents;
        public RentRepository()
        {
            rents = new List<Rent>()
            {
            };
        }
    }
}
