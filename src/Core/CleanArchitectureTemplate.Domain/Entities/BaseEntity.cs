using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
