using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PortalAluno.Context;
using API_PortalAluno.Models;

namespace API_PortalAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessorTurmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfessorTurmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorTurma>>> GetProfessorTurma()
        {
            return await _context.ProfessorTurma.ToListAsync();
        }

        // GET: api/ProfessorTurmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorTurma>> GetProfessorTurma(int id)
        {
            var professorTurma = await _context.ProfessorTurma.FindAsync(id);

            if (professorTurma == null)
            {
                return NotFound();
            }

            return professorTurma;
        }

        // PUT: api/ProfessorTurmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessorTurma(int id, ProfessorTurma professorTurma)
        {
            if (id != professorTurma.ProfessorId)
            {
                return BadRequest();
            }

            _context.Entry(professorTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorTurmaExists(id))
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

        // POST: api/ProfessorTurmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfessorTurma>> PostProfessorTurma(ProfessorTurma professorTurma)
        {
            _context.ProfessorTurma.Add(professorTurma);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfessorTurmaExists(professorTurma.ProfessorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfessorTurma", new { id = professorTurma.ProfessorId }, professorTurma);
        }

        // DELETE: api/ProfessorTurmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessorTurma(int id)
        {
            var professorTurma = await _context.ProfessorTurma.FindAsync(id);
            if (professorTurma == null)
            {
                return NotFound();
            }

            _context.ProfessorTurma.Remove(professorTurma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorTurmaExists(int id)
        {
            return _context.ProfessorTurma.Any(e => e.ProfessorId == id);
        }
    }
}
