using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string? Username { get; set; }
        public string? HashPasscode { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ActiveCode { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public GenderType GenderType { get; set; }
        public string? Image { get; set; }
        public int? Age { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public DateTime ExpireActiveCode { get; set; }
        public DateTime LastLoginDate { get; set; }
    }

    
}
