using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public abstract class AuditableBaseEntity
    {
        public virtual string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
