using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Role 
    {
        public virtual string Id {get;set;}
        public string RoleName { get; set; }
    }
}
