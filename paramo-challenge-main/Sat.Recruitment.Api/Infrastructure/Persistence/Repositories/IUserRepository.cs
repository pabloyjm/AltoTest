using Sat.Recruitment.Api.Domain.Interfaces;
using Sat.Recruitment.Api.Infrastructure.Messaging;
using System;

namespace Sat.Recruitment.Api.Infrastructure.Persistence.Repositories
{
    public interface IUserRepository
    {
        Result Add(IUser newUser);
        void Delete(IUser user);
        IUser GetByEmail(string email);
        IUser GetById(int id);
        void Update(IUser user);
    }
}
