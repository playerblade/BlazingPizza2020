using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Ci { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int Phone { get; set; }

    }
}
