using Microsoft.AspNetCore.Identity;

namespace API_PortalAluno.Models.User
{
    public class UserAdmin : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public int? ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int? AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

    }
}
