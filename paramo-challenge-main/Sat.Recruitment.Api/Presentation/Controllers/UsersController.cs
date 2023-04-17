using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Application.Users;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Domain.Entities;
using Sat.Recruitment.Api.Domain.Interfaces;
using Sat.Recruitment.Api.Infrastructure.Messaging;
using Sat.Recruitment.Api.Infrastructure.Persistence.Repositories;
using Sat.Recruitment.Api.Infrastructure.Services;
using Sat.Recruitment.Api.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly List<IUser> _users = new List<IUser>();
        private readonly IUserCreator _userCreator;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserCreator userCreator)
        {
            _userCreator = userCreator;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDto user)
        {
            Enum.TryParse(user.UserType, true, out UserType parsedUsetype);

            EmailService.NormalizeEmail(user.Email);

            IUser defUser = new DefaultUser
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Money = decimal.Parse(user.Money),
                UserType = parsedUsetype
            };

            string errors = UserValidatorService.Validate(defUser);

            if (!string.IsNullOrEmpty(errors))
                return new Result() { IsSuccess = false, Errors = errors };

            IUser newUser = _userCreator.CreateUser(defUser);

            return _userRepository.Add(newUser);

        }

    }

}
