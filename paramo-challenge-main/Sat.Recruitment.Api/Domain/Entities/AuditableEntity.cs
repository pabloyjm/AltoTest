using Sat.Recruitment.Api.Domain.Interfaces;
using System;

namespace Sat.Recruitment.Api.Domain.Entities
{
    public class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
