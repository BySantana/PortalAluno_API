﻿using System;
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
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        [HttpPut("{alunoId}, {novaTurmaId}")]
        public async Task<bool> TrocarTurma(int alunoId, int novaTurmaId)
        {
            var materiasAlunos = await _context.MateriaAlunos.
                AsNoTracking().
                Where(a => a.AlunoId == alunoId).
                ToArrayAsync();

            var aluno = await _context.Alunos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == alunoId);

            if (aluno != null)
            {
                aluno.TurmaId = novaTurmaId;
                _context.Alunos.Update(aluno);
            }

            _context.MateriaAlunos.RemoveRange(materiasAlunos);

            try
            {
                await _context.SaveChangesAsync();
                await InsereMaterias(novaTurmaId, alunoId);
            }
            catch
            {
                throw;
            }

            return true;
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            try
            {
                await InsereMaterias(aluno.TurmaId, 0);
            } catch (Exception ex)
            {
                ex.ToString();
            }

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.AsNoTracking().Any(e => e.Id == id);
        }

        private async Task<int> LastAlunoCreated()
        {
            return await _context.Alunos
                .AsNoTracking()
                .OrderByDescending(aluno => aluno.Id)
                .Select(aluno => aluno.Id)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> InsereMaterias(int turmaId, int alunoId)
        {
            var turma = await _context.Turmas.FindAsync(turmaId);

            if (turma != null)
            {
                var materias = await _context.Materia.Where(x => x.TurmaId == turma.Id).ToListAsync();

                foreach (var a in materias)
                {
                    _context.MateriaAlunos.Add(new MateriaAluno
                    {
                        AlunoId = alunoId == 0 ? await LastAlunoCreated() : alunoId,
                        MateriaId = a.Id,
                        Status = "Cursando"
                    });
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
