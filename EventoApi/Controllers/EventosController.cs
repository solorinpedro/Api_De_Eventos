using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventoApi.Dal;
using EventoApi.Models;

namespace EventoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly Contexto _context;

        public EventosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet("/Eventos/GetEventos")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
          if (_context.Eventos == null)
          {
              return NotFound();
          }
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("/Eventos/GetEventos{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
          if (_context.Eventos == null)
          {
              return NotFound();
          }
            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/Eventos/PutEventos{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Eventos/PostEventos")]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
          if (_context.Eventos == null)
          {
              return Problem("Entity set 'Contexto.Eventos'  is null.");
          }
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("/Eventos/DeleteEvento{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            if (_context.Eventos == null)
            {
                return NotFound();
            }
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
