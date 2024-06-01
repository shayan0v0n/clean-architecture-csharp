using CleanArchitectureTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Repositories
{
    public interface IRoleRepositoryAsync : IRepositoryAsync<Role>
    {
        Task<Role> GetRoleByName(string roleName);

    }
}
