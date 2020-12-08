using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza2020.Contexts;
using BlazingPizza2020.Models;

namespace BlazingPizza2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private readonly KitchenContext _context;
        private readonly PizzaContext _contextPizza;

        public KitchenController(KitchenContext context, PizzaContext contextPizza)
        {
            _context = context;
            _contextPizza = contextPizza;
        }

        [HttpGet]
        public List<PizzaModel> GetPizzasPorPreparar()
        {
            //var blogs = _contextPizza.Pizza.SqlQuery("SELECT * FROM dbo.Blogs").ToList();
            return _contextPizza.Pizza.FromSqlRaw("SELECT * FROM dbo.Pizza p WHERE p.State = 'Preparando'").ToList();
            //return  _contextPizza.Pizza.ToList();
        }

        [HttpGet("Preparadas")]
        public List<PizzaModel> GetPizzasPreparadas()
        {
            //var blogs = _contextPizza.Pizza.SqlQuery("SELECT * FROM dbo.Blogs").ToList();
            return _contextPizza.Pizza.FromSqlRaw("SELECT * FROM dbo.Pizza p WHERE p.State = 'Preparado'").ToList();
            //return  _contextPizza.Pizza.ToList();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, PizzaModel pizzaModel)
        {
            if (id != pizzaModel.Id)
            {
                return BadRequest();
            }

            pizzaModel.State = "Preparado";
            _contextPizza.Entry(pizzaModel).State = EntityState.Modified;

            try
            {
                await _contextPizza.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientPizza(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClientPizza(int id)
        {
            return _contextPizza.Pizza.Any(e => e.Id == id);
        }
    }
}
