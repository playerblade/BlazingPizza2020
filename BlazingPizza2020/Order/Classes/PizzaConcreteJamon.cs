using BlazingPizza2020.Order.Abstracts;
using System;

namespace BlazingPizza2020.Order.Classes
{
    public class PizzaConcreteJamon:PizzaBuilder
    {   
        protected override void buildCosto(){
            pizza.setCosto(10);
        }
        
        protected override void buildCobertura(){
            pizza.setCobertura("Jamon");
        }
    }
}