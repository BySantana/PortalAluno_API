using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PortalAluno.Context;
using API_PortalAluno.Models;
using API_PortalAluno.Models.User;
using API_PortalAluno.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API_PortalAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public ProfessoresController(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            return await _context.Professores
                //.Include(a => a.Endereco)
                //.Include(a => a.Turmas)
                //.Include(a => a.Materias)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _context.Professores.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();

            try
            {
                await RegisterProfessor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction("GetProfessor", new { id = professor.Id }, professor);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }

        private async Task<int> LastProfessorCreated()
        {
            return await _context.Professores
                .AsNoTracking()
                .OrderByDescending(professor => professor.Id)
                .Select(professor => professor.Id)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> RegisterProfessor()
        {
            var professorId = await LastProfessorCreated();
            var professor = await _context.Professores.FindAsync(professorId);

            if (professor != null)
            {
                await _authService.CreateAccountProfessorAsync(new UserLogin { Password = professor.Senha, UserName = professor.Nome }, professorId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
