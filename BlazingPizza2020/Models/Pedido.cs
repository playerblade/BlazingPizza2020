using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdClient{ get; set; }
        public int IdKitchen { get; set; }
        public int IdDelivery { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
