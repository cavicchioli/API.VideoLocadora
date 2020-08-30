using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.VideoLocadora.Models
{
    public class Return
    {
        //long clientCpf, int filmId, DateTime dataLocacao

        public long clientCpf { get; set; }
        public int filmId { get; set; }
        public DateTime dataLocacao { get; set; }
    }
}
