using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PortalAluno.Context;
using API_PortalAluno.Models;
using System.Drawing.Drawing2D;

namespace API_PortalAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
        {
            return await _context.Materia
                .Include(a => a.Professor)
                .Include(a => a.Turma)
                .ToListAsync();
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.Materia.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
            _context.Materia.Add(materia);
            await _context.SaveChangesAsync();

            try
            {
                InsertProfessorTurma(materia.TurmaId, materia.ProfessorId);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            

            return CreatedAtAction("GetMateria", new { id = materia.Id }, materia);
        }

        private async void InsertProfessorTurma(int turmaId, int professorId)
        {
            _context.ProfessorTurma.Add(new ProfessorTurma { TurmaId = turmaId, ProfessorId = professorId });
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return _context.Materia.Any(e => e.Id == id);
        }
    }
}
