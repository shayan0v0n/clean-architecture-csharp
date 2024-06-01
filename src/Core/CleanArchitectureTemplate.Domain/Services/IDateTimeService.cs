using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
