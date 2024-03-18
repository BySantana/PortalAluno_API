using API_PortalAluno.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_PortalAluno.Services
{
    public class AuthService
    {
        private readonly UserManager<UserAdmin> _userManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<UserAdmin> userManager, TokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserAdmin> CreateAccountAlunoAsync(UserLogin userLogin, int alunoId)
        {
            try
            {
                var user = _mapper.Map<UserAdmin>(userLogin);
                user.AlunoId = alunoId;
                user.ProfessorId = null;

                var result = await _userManager.CreateAsync(user, userLogin.Password);

                if (result.Succeeded)
                {
                    return user;
                }

                return null;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar Criar Usuário. Erro: {ex.Message}");
            }
        }
    }
}
