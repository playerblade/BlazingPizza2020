using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza2020.Authentication;
using BlazingPizza2020.Contexts;
using BlazingPizza2020.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientsController(ClientContext context)
        {
            _context = context;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {

            return await _context.Client.ToListAsync();

        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
        public async Task<ActionResult<Client>> PostClient(Proxy clientProxy)
        {
            //Proxy clientProxy = new Proxy();
            //clientProxy.createCliente(client.Name, client.LastName, client.Ci, client.User, client.Password, client.Longitude, client.Latitude, client.Phone);

            _context.Client.Add(clientProxy.cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = clientProxy.cliente.Id }, clientProxy.cliente);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }

        [HttpPost("login")]
        public string PostClientLigin(Proxy clientProxy)
        {

            var clientAux = _context.Client.FromSqlRaw("SELECT * FROM dbo.Client c WHERE c.User = '" + clientProxy.cliente.User + "'").ToList();
            //_context.Client.Add(clientProxy.cliente);
            //await _context.SaveChangesAsync();

            var item = _context.Client.FindAsync(clientAux);

            if (item == null)
            {
                return "no foud";
            }

            return item.ToString();
        }
    }
}
