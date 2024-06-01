using CleanArchitectureTemplate.Domain.Repositories;
using CleanArchitectureTemplate.Domain.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CleanArchitectureTemplate.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
