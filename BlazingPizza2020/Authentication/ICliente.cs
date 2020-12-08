using BlazingPizza2020.Authentication;
using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Authentication
{
    public interface ICliente {

        public void createCliente(string Name, string LastName, string Ci, string User, string Password, string Longitude, string Latitude, int Phone) {}

    }
}