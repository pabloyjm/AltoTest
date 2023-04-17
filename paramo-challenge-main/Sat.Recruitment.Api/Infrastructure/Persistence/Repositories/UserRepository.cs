using Sat.Recruitment.Api.Domain.Interfaces;
using Sat.Recruitment.Api.Infrastructure.Messaging;
using System;
using System.Diagnostics;

namespace Sat.Recruitment.Api.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Add(IUser newUser)
        {
            IUser user = GetByEmail(newUser.Email);

            if (user is null)
            {
                _context.Users.Add(newUser);
                Debug.WriteLine("User Created");

                return new Result() { IsSuccess = true, Errors = "User Created" };
            }
            else
            {
                return new Result() { IsSuccess = false, Errors = "The user exists" };
            }
        }

        public void Delete(IUser user) { throw new NotImplementedException(); }

        public IUser GetByEmail(string email) { throw new NotImplementedException(); }

        public IUser GetById(int id) { throw new NotImplementedException(); }

        public void Update(IUser user) { throw new NotImplementedException(); }
    }
}
