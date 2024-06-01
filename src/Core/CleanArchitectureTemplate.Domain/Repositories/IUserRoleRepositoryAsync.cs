using CleanArchitectureTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Repositories
{
    public interface IUserRoleRepositoryAsync : IRepositoryAsync<UserRole>
    {
        bool IsInRole(string userId, string roleId);
        string GetRoleByName(string role);
    }
}
