using Sat.Recruitment.Api.Domain.Interfaces;

namespace Sat.Recruitment.Api.Application.Users
{
    public interface IUserCreator
    {
        IUser CreateUser(IUser user);
    }
}
