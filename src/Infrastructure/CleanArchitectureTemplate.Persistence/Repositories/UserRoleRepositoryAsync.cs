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
    public class UserRoleRepositoryAsync : RepositoryAsync<UserRole>, IUserRoleRepositoryAsync
    {

        private readonly ApplicationDbContext _dbContext;

        public UserRoleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsInRole(string userId, string roleId)
        {
            return _dbContext.UserRoles.Any(ur => ur.UserId == userId && ur.RoleId == roleId);
        }

        public string GetRoleByName(string role)
        {
            return _dbContext.Roles.Where(r => r.RoleName == role).First().Id;
        }

    }
}
