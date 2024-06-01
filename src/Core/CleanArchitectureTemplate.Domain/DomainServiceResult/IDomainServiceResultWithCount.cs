using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.DomainServiceResult
{
    public interface IDomainServiceResultWithCount<TAggregate> : IDomainServiceResult<TAggregate>
    {
         long Count { get; set; }
    }
}
