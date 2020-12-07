using BlazingPizza2020.Order.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Order.Abstracts
{
    public abstract class PizzaBuilder
    {
        public Pizza pizza { get; set; }

        public Pizza getPizza()
        {
            return pizza;
        }
        public void createNuevaPizza()
        {
            pizza = new Pizza();
        }
        protected abstract void buildCosto();
        protected abstract void buildCobertura();
        public void buildCoberturas(List<PizzaBuilder> coberturas)
        {
            pizza.setCoberturas(coberturas);
        }
        public void buildMasa(string masa)
        {
            pizza.setMasa(masa);
        }
        public void buildTamanio(Tamanio tamanio)
        {
            pizza.setTamanio(tamanio);
        }

        public void buildCostoAux() { this.buildCosto(); }
        public void buildCoberturaAux() { this.buildCobertura(); }
    }
}
