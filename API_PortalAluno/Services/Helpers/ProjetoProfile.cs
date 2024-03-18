using API_PortalAluno.Models.User;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace API_PortalAluno.Services.Helpers
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<UserAdmin, UserLogin>().ReverseMap();
        }
    }
}
