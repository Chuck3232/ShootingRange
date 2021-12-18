using Infrascture.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Seeder
{
    public class RoleSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
                _dbContext.SaveChanges();
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name="Admin"
                },
                new Role()
                {
                    Name="Instructor"
                },
                new Role()
                {
                    Name="Overseer"
                },
                new Role()
                {
                    Name="Armourer"
                },
                new Role()
                {
                    Name="Receptionist"
                },
            };
            return roles;
        }
    }
}
