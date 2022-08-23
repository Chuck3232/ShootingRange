using Application.Commands.User;
using Application.Dto;
using Application.Services.Interface;
using Domain.Models;
using Infrascture.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShootingRange;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(ApplicationDbContext dbContext, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateJwt(LoginUser command)
        {
            var user = _dbContext.Users
                .Include(u=>u.Role)
                .FirstOrDefault(u => u.Email == command.Email);

            if(user is null)
            {
                throw new Exception("Invalid username or password");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash);

            if(!isValidPassword)
            {
                throw new Exception("Invalid username or password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email,$"{user.Email}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            user.Status = "active";
            _dbContext.SaveChangesAsync();
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterUser command)
        {
            if (await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == command.Email) != null)
                throw new Exception("User with this email  already exists.");

            var user = new User(command.Email, command.FirstName, command.LastName);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeRole(ChangeRole command)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == command.UserId);
            if (user==null)
                throw new KeyNotFoundException("User doesn't exist");
            user.RoleId = command.NewRole;
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditUser(EditUser command)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == command.UserId);
            if (user == null)
                throw new KeyNotFoundException("User doesn't exist");
            user.Update(command.Email, command.FirstName, command.LastName, command.RoleId);
            await _dbContext.SaveChangesAsync();
        }
        public List<UserDto> GetAllInstructors()
        {
            var users = _dbContext.Users.Where(u => u.RoleId == 2 && u.Status == "active")
                                        .Include(u => u.Role);
            var usersDto = users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role.Name,
                status = u.Status,

            });
            return usersDto.ToList();
        }
        public List<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.Include(u => u.Role);
            var usersDto = users.Select(u => new UserDto
            {
                Id=u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role.Name,
                status = u.Status,

            });
            return usersDto.ToList();
        }


        public async Task DeleteUser(DeleteUser command)
        {
            _dbContext.Remove(_dbContext.Users.Where(u => u.Id == command.UserId).FirstOrDefault());
            await _dbContext.SaveChangesAsync();
        }
    }
}
