using BlazingPizza2020.Authentication;
using BlazingPizza2020.Models;
using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Authentication
{
    public class Proxy : ICliente {
        public Client cliente { get; set; }
        public Proxy()
        {
        }

        public void createCliente( string Name, string LastName, string Ci, string User, string Password, string Longitude, string Latitude, int Phone) {
            this.cliente = new Client();
            cliente.createCliente( Name, LastName, Ci, User, Password, Longitude, Latitude, Phone);
        }

    }
}