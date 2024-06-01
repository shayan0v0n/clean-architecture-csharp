using CleanArchitectureTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Repositories
{
    public interface IUserRepositoryAsync : IRepositoryAsync<User>
    {
        Task<User?> Authentication(string username, string password);
        Task<bool> ExistUser(string username);
        Task<bool> Register(User user);
    }
}
