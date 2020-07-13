using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestItemsController : ControllerBase
    {
        private readonly RestContext _context;

        public RestItemsController(RestContext context)
        {
            _context = context;
        }

        // GET: api/RestItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestItem>>> GetRestItems()
        {
            return await _context.RestItems.ToListAsync();
        }

        // GET: api/RestItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestItem>> GetRestItem(long id)
        {
            var restItem = await _context.RestItems.FindAsync(id);

            if (restItem == null)
            {
                return NotFound();
            }

            return restItem;
        }

        // PUT: api/RestItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestItem(long id, RestItem restItem)
        {
            if (id != restItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(restItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestItemExists(id))
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

        // POST: api/RestItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RestItem>> PostRestItem(RestItem restItem)
        {
            _context.RestItems.Add(restItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestItem", new { id = restItem.Id }, restItem);
        }

        // DELETE: api/RestItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RestItem>> DeleteRestItem(long id)
        {
            var restItem = await _context.RestItems.FindAsync(id);
            if (restItem == null)
            {
                return NotFound();
            }

            _context.RestItems.Remove(restItem);
            await _context.SaveChangesAsync();

            return restItem;
        }

        private bool RestItemExists(long id)
        {
            return _context.RestItems.Any(e => e.Id == id);
        }
    }
}
