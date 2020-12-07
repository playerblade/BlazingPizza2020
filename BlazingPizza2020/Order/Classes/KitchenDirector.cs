using BlazingPizza2020.Order.Abstracts;
using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Order.Classes
{
    public class KitchenDirector
    {  
        private PizzaBuilder pizzaBuilder;
        List<PizzaBuilder> pizzaBuilders = new List<PizzaBuilder>();
        public void setPizzaBuilder(PizzaBuilder pizzaBuilder){
            this.pizzaBuilder = pizzaBuilder;
        }
        public void setPizzaBuilders(List<PizzaBuilder> pizzaBuilders){
            this.pizzaBuilders = pizzaBuilders;
        }
        public Pizza getPizza(){ return pizzaBuilder.getPizza(); }
        public void construirPizza(){
            
                this.pizzaBuilder.createNuevaPizza();
                this.pizzaBuilder.buildCostoAux();
                pizzaBuilder.buildMasa("Suave");
                this.pizzaBuilder.buildCoberturaAux(); 
            foreach (var pizzaBuilder in pizzaBuilders) 
            { 
                pizzaBuilder.createNuevaPizza();
                pizzaBuilder.buildCostoAux();
                pizzaBuilder.buildMasa("Suave");
                pizzaBuilder.buildCoberturaAux(); 
            } 
            this.pizzaBuilder.buildCoberturas(pizzaBuilders);
        }   
    }
}