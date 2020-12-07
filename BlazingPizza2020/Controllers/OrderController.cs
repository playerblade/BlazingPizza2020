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
    //[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly PizzaContext _contextPizza;
        private readonly PizzaCoverageContext _contextPizzaCoverage;

        public OrderController(OrderContext context, PizzaContext contextPizza, PizzaCoverageContext contextPizzaCoverage)
        {
            _context = context;
            _contextPizza = contextPizza;
            _contextPizzaCoverage = contextPizzaCoverage;
        }

        [Route("api/Order")]
        [HttpGet]
        public string GetAll()
        {
            return "sdasdads";
        }



        [Route("api/Order")]
        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetOrder(int id)
        {
            var pizza = await _context.Order.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }


        // POST: api/Pizzas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("api/Order")]
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

            //orderBuilder.pizzas = PedidoLista;

            CalcularCosto costo = new CalcularCosto();
            costo.setPedidoLista(PedidoLista);
            orderBuilder.pizzas = costo.CalcularCostoPedido();
            orderBuilder.CostoPedido = costo.costoTotal;

            return orderBuilder;
        }

        [Route("api/Order/Confirm")]
        [HttpPost]
        public async Task<ActionResult<OrderBuilder>> PostOrderSave(OrderBuilder orderBuilder)
        {
            Pedido pedido = new Pedido();
            pedido.IdClient = 1;
            pedido.IdDelivery = 1;
            pedido.Price = orderBuilder.CostoPedido;
            pedido.Quantity = orderBuilder.pizzas.Count;
            pedido.StartDate = "2012-12-12 00:00:00.000";
            pedido.EndDate = "2012-12-12 00:00:00.000";
            pedido.State = "Cocina";

            _context.Order.Add(pedido);
            await _context.SaveChangesAsync();

            List<Pizza> PedidoLista = orderBuilder.pizzas;

            for (int j = 0; j < PedidoLista.Count; j++)
            {

                PizzaModel pizzaModel = new PizzaModel();
                pizzaModel.IdOrder = pedido.Id;
                pizzaModel.IdKitchen = 1;
                pizzaModel.Price = PedidoLista[j].costo;
                pizzaModel.State = "1";

                string size = PedidoLista[j].tamanio.tamanio;
                Tamanio tamanio = new Tamanio();
                switch (size)
                {
                    case "Pequeño":
                        pizzaModel.IdSize = 1;
                        break;
                    case "Mediano":
                        pizzaModel.IdSize = 2;
                        break;
                    case "Grande":
                        pizzaModel.IdSize = 3;
                        break;
                }

                _contextPizza.Pizza.Add(pizzaModel);
                await _contextPizza.SaveChangesAsync();

                for (int i = 0; i < PedidoLista[j].coberturasFinales.Count; i++)
                {
                    PizzaCoverage pizzaCoverage = new PizzaCoverage();
                    pizzaCoverage.IdPizza = pizzaModel.Id;

                    string coverage = PedidoLista[j].coberturasFinales[i].cobertura;
                    switch (coverage)
                    {
                        case "Piña":
                            pizzaCoverage.IdCoverage = 1;
                            break;
                        case "Jamon":
                            pizzaCoverage.IdCoverage = 2;
                            break;
                        case "Chorizo":
                            pizzaCoverage.IdCoverage = 3;
                            break;
                    }

                    _contextPizzaCoverage.PizzaCoverage.Add(pizzaCoverage);
                    await _contextPizzaCoverage.SaveChangesAsync();
                }
            }

            //orderBuilder.pizzas = PedidoLista;

            return orderBuilder;
        }
    }
}
