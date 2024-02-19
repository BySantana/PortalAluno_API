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
    public class MateriaAlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriaAlunosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MateriaAlunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaAluno>>> GetMateriaAlunos()
        {
            return await _context.MateriaAlunos.ToListAsync();
        }

        // GET: api/MateriaAlunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaAluno>> GetMateriaAluno(int id)
        {
            var materiaAluno = await _context.MateriaAlunos.FindAsync(id);

            if (materiaAluno == null)
            {
                return NotFound();
            }

            return materiaAluno;
        }

        // PUT: api/MateriaAlunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriaAluno(int id, MateriaAluno materiaAluno)
        {
            if (id != materiaAluno.AlunoId)
            {
                return BadRequest();
            }

            _context.Entry(materiaAluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaAlunoExists(id))
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

        // POST: api/MateriaAlunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MateriaAluno>> PostMateriaAluno(MateriaAluno materiaAluno)
        {
            _context.MateriaAlunos.Add(materiaAluno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MateriaAlunoExists(materiaAluno.AlunoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMateriaAluno", new { id = materiaAluno.AlunoId }, materiaAluno);
        }

        // DELETE: api/MateriaAlunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateriaAluno(int id)
        {
            var materiaAluno = await _context.MateriaAlunos.FindAsync(id);
            if (materiaAluno == null)
            {
                return NotFound();
            }

            _context.MateriaAlunos.Remove(materiaAluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaAlunoExists(int id)
        {
            return _context.MateriaAlunos.Any(e => e.AlunoId == id);
        }
    }
}
