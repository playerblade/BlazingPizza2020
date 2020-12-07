using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza2020.Contexts;
using BlazingPizza2020.Models;
using JKang.EventBus;
using Microsoft.Extensions.Caching.Memory;
using BlazingPizza2020.EventBus.Handlers;

namespace BlazingPizza2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaContext _context;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMemoryCache _memoryCache;

        public PizzasController(PizzaContext context, IEventPublisher eventPublisher, IMemoryCache memoryCache)
        {
            _eventPublisher = eventPublisher;
            _memoryCache = memoryCache;
            _context = context;
        }

        public List<string> Messages { get; private set; }

        [BindProperty]
        public string Message { get; set; }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaModel>>> GetPizzas()
        {
            await _eventPublisher.PublishEventAsync(new MessageSent(Message));

            return await _context.Pizza.ToListAsync();

        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaModel>> GetPizza(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, PizzaModel pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
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

        // POST: api/Pizzas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PizzaModel>> PostPizza(PizzaModel pizza)
        {
            _context.Pizza.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.Id }, pizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaModel>> DeletePizza(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();

            return pizza;
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.Id == id);
        }
    }
}
