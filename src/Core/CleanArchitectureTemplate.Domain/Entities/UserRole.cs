using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class UserRole 
    {
        public virtual int Id { get; set; }
        public  string UserId{ get; set; }
        public string RoleId { get; set; }

    }
}
