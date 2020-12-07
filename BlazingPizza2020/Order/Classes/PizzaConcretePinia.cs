using BlazingPizza2020.Order.Abstracts;
using System;

namespace BlazingPizza2020.Order.Classes
{
    public class PizzaConcretePinia:PizzaBuilder
    {   
        protected override void buildCosto(){
            pizza.setCosto(20);
        }
        protected override void buildCobertura(){
            pizza.setCobertura("Piña");
        }
    }
}