using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Shared.Security.JwtToken
{
    public interface IUserContext
    {
        string Id { get; set; }
        string RoleId { get; set; }

    }
    public class UserContext : IUserContext
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
    }
}
