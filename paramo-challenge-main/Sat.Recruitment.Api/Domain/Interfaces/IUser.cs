using Sat.Recruitment.Api.Common;
using System;

namespace Sat.Recruitment.Api.Domain.Interfaces
{
    public interface IUser : IAuditableEntity
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        decimal Money { get; set; }
        UserType? UserType { get; set; }
        void AddMoney(decimal amount);
    }
}
