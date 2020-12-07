using BlazingPizza2020.Order.Abstracts;
using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Order.Classes
{
    public class Pizza {
        public Tamanio tamanio { get; set; }
        private string masa { get; set; }
        public int costo { get; set; }
        public string cobertura { get; set; }
        public List<Pizza> coberturasFinales { get; set; }
        public List<PizzaBuilder> coberturas { get; set; }
        public void setCosto(int costo) {
            this.costo = costo;
        }
        public void setTamanio(Tamanio tamanio) {
            this.tamanio = tamanio;
        }
        public void setMasa(string masa) {
            this.masa = masa;
        }

        public void setCobertura(string cobertura) {
            this.cobertura = cobertura;
        }

        public void setCoberturas(List<PizzaBuilder> coberturas) {
            this.coberturas = coberturas;
        }

        public string toString() {
            
            return "{" +
                    " costo='" + costo + "'"+ 
                    ", cobertura='" + cobertura +"'"+ 
                    "},";
        }
        public string toStrings() {
            string coverturAux = "Pizza{" +
                    "masa='" + masa+"'"+
                    ", tamanio='" + tamanio.tamanio+"'"+
                    ", costo='" + tamanio.costo+"'"+
                    ", cobertura {";
            foreach (var cobertura in coberturas) 
            { 
                Pizza pizzaAux = cobertura.getPizza();
                coverturAux += pizzaAux.toString();
            }
            coverturAux += ""+  
                "}}";
            return coverturAux;
        }
    }
}