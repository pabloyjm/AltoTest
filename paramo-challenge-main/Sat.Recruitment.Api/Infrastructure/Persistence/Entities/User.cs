using System;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Domain.Entities;
using Sat.Recruitment.Api.Domain.Interfaces;

namespace Sat.Recruitment.Api.Infrastructure.Persistence.Entities
{
    public abstract class User : AuditableEntity, IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Money { get; set; }
        public UserType? UserType { get; set; }
        public virtual void AddMoney(decimal amount)
        {
            Money += amount;
        }
    }
}
