using BlazingPizza2020.Order.Classes;
using BlazingPizza2020.Order.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza2020.Contexts;
using Microsoft.EntityFrameworkCore;
using BlazingPizza2020.Models;

namespace BlazingPizza2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string GetAll()
        {
            return "sdasdads";
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderBuilder>> PostOrder(OrderBuilder orderBuilder)
        {
            //ObjectPool<Pizza> CapasidadPizzas = new ObjectPool<Pizza>();
            //CapasidadPizzas = ObjectPool<Pizza>.GetInstance();
            //CapasidadPizzas.SetMaxPoolSize(2);

            List<Pizza> PedidoLista = orderBuilder.pizzas;

            for (int j = 0; j < PedidoLista.Count; j++)
            {

                string size = PedidoLista[j].tamanio.tamanio;
                Tamanio tamanio = new Tamanio();
                switch (size)
                {
                    case "Pequeño":
                        tamanio.costo = 10;
                        tamanio.tamanio = "Pequeño";
                        break;
                    case "Mediano":
                        tamanio.costo = 10;
                        tamanio.tamanio = "Mediano";
                        break;
                    case "Grande":
                        tamanio.costo = 10;
                        tamanio.tamanio = "Grande";
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }


                List<PizzaBuilder> coberturas = new List<PizzaBuilder>();
                KitchenDirector kitchenDirector = new KitchenDirector();
                PizzaBuilder PizzaBuilder = new PizzaConcreteJamon();

                for (int i = 0; i < PedidoLista[j].coberturasFinales.Count; i++)
                {
                    string coverage = PedidoLista[j].coberturasFinales[i].cobertura;
                    switch (coverage)
                    {
                        case "Piña":

                            coberturas.Add(new PizzaConcretePinia());
                            break;
                        case "Jamon":
                            coberturas.Add(new PizzaConcreteJamon());
                            break;
                        case "Chorizo":
                            coberturas.Add(new PizzaConcreteChorizo());
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }
                kitchenDirector.setPizzaBuilder(PizzaBuilder);
                kitchenDirector.setPizzaBuilders(coberturas);
                kitchenDirector.construirPizza();
                PedidoLista[j] = kitchenDirector.getPizza();
                PedidoLista[j].setTamanio(tamanio);
            }

            orderBuilder.pizzas = PedidoLista;

            Pedido pedido = new Pedido();
            pedido.Id = 10;
            pedido.IdClient = 1;
            pedido.IdDelivery = 1;
            pedido.IdKitchen = 1;
            pedido.Price = 10;
            pedido.Quantity = 5;
            pedido.StartDate = "2012-12-12 00:00:00.000";
            pedido.EndDate = "2012-12-12 00:00:00.000";
            pedido.State = "1";

            _context.Order.Add(pedido);
            await _context.SaveChangesAsync();

            return orderBuilder;
        }
    }
}
