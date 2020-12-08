using BlazingPizza2020.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Models
{
    public class Client : ICliente
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

        public void createCliente(string Name, string LastName, string Ci, string User, string Password, string Longitude, string Latitude, int Phone)
        {
            //this.Id = Id;
            this.Name = Name;
            this.LastName = LastName;
            this.Ci = Ci;
            this.User = User;
            this.Password = Password;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
            this.Phone = Phone;
        }

    }
}
