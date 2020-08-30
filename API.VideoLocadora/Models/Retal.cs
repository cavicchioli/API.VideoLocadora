using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace API.VideoLocadora.Models
{
    public class Retal
    {
        public long clientCpf { get; set; }
        public int filmId { get; set; }
        public int periodo { get; set; }
    }
}
