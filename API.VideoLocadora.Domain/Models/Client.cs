using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.VideoLocadora.Domain.Models
{
    public class Client
    {
        public Client(long cpf, string name, string telephone, string email, bool active)
        {
            Cpf = cpf;
            Name = name;
            Telephone = telephone;
            Email = email;
            Active = active;
        }

        public long Cpf { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

    }
}