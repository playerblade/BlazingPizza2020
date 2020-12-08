using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public int IdSize { get; set; }
        public int IdOrder { get; set; }
        public int IdKitchen { get; set; }

        [Column(TypeName = "float")]
        public float Price { get; set; }

        public string State { get; set; }
    }
}
