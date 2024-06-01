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
    public class UserRepositoryAsync : RepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> Authentication(string username, string password)
        {
            var user = await _dbContext.Users.Where(a => a.Username == username && a.HashPasscode == password ).FirstOrDefaultAsync();
            return user;
        }



        public async Task<bool> ExistUser(string username)
        {
            return await _dbContext.Users.AnyAsync(a => a.Username == username);
        }

        public async Task<bool> Register(User user)
        {
            var result = 0;
            _dbContext.Users.AddAsync(user);
            result = await _dbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
