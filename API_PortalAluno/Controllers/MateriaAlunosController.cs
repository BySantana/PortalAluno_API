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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaAluno>>> GetMateriaAlunos()
        {
            return await _context.MateriaAlunos.ToListAsync();
        }

        [HttpGet("{alunoId}")]
        public async Task<ActionResult<IEnumerable<MateriaAluno>>> GetMateriaAlunoByAluno(int alunoId)
        {
            var materiaAluno = await _context.MateriaAlunos.Where(a => a.AlunoId == alunoId).ToListAsync();

            if (materiaAluno == null)
            {
                return NotFound();
            }

            return materiaAluno;
        }

        [HttpPut("{alunoId}, {materiaId}")]
        public async Task<IActionResult> PutMateriaAluno(int alunoId, int materiaId, MateriaAluno materiaAluno)
        {
            if (alunoId != materiaAluno.AlunoId && materiaId != materiaAluno.MateriaId)
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
                if (!MateriaAlunoExists(alunoId, materiaId))
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
        public async Task<ActionResult<MateriaAluno>> PostMateriaAluno(MateriaAluno materiaAluno)
        {
            _context.MateriaAlunos.Add(materiaAluno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MateriaAlunoExists(materiaAluno.AlunoId, materiaAluno.MateriaId))
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

        [HttpDelete("{alunoId}, {materiaId}")]
        public async Task<IActionResult> DeleteMateriaAluno(int alunoId, int materiaId)
        {
            var materiaAluno = await _context.MateriaAlunos.FindAsync(alunoId, materiaId);
            if (materiaAluno == null)
            {
                return NotFound();
            }

            _context.MateriaAlunos.Remove(materiaAluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaAlunoExists(int alunoId, int materiaId)
        {
            return _context.MateriaAlunos.Any(e => e.AlunoId == alunoId && e.MateriaId == materiaId );
        }
    }
}
