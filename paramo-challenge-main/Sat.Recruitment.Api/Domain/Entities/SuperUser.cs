using System;
using Sat.Recruitment.Api.Infrastructure.Persistence.Entities;

namespace Sat.Recruitment.Api.Domain.Entities
{
    public class SuperUser : User
    {
        public override void AddMoney(decimal amount)
        {
            base.AddMoney(amount);
        }
    }
}
