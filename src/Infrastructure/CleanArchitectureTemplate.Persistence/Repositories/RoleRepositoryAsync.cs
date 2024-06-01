using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Persistence.Contexts;
using CleanArchitectureTemplate.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Repositories
{
    public class RoleRepositoryAsync : RepositoryAsync<Role>, IRoleRepositoryAsync
    {
        private readonly DbSet<Role> _roles;

        public RoleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _roles = dbContext.Set<Role>();
        }

        public async Task<Role> GetRoleByName(string roleName)
        {
            var role = await _roles.Where(a=>a.RoleName == roleName).FirstOrDefaultAsync();
            return role;
        }
    }
}
