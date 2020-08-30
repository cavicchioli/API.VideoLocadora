using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace API.VideoLocadora.Domain.Models
{
    public class Film
    {
        public Film(int id, string name, string genre, string status, bool active)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Status = status;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }

    }
}