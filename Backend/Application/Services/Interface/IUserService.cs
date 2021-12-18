using Application.Commands.User;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IUserService : IService
    {
        string GenerateJwt(LoginUser command);
        Task RegisterUser(RegisterUser command);
        Task ChangeRole(ChangeRole command);
        Task DeleteUser(DeleteUser command);
    }
}
