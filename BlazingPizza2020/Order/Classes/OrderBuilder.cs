using BlazingPizza2020.Order.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Order.Classes
{
    public class OrderBuilder
    {
        public int CostoPedido { get; set; }
        public List<Pizza> pizzas { get; set; }
    }
}
