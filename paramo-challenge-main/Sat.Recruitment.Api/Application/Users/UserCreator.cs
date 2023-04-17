using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Domain.Entities;
using Sat.Recruitment.Api.Domain.Interfaces;
using System;

namespace Sat.Recruitment.Api.Application.Users
{
    public class UserCreator : IUserCreator
    {
        public IUser CreateUser(IUser user)
        {
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = "UserCreator";

            if (user.UserType == UserType.Normal)
            {
                NormalUser normalUser = (NormalUser)user;

                if (normalUser.Money > 100)
                {
                    decimal percentage = Convert.ToDecimal(0.12);
                    decimal gif = user.Money * percentage;
                    normalUser.AddMoney(gif);
                }
                else if (normalUser.Money > 10)
                {
                    decimal percentage = Convert.ToDecimal(0.8);
                    decimal gif = user.Money * percentage;
                    normalUser.AddMoney(gif);
                }

                return normalUser;
            }
            else if (user.UserType == UserType.Premium)
            {
                PremiumUser premiumUser = (PremiumUser)user;

                if (premiumUser.Money > 100)
                {
                    decimal gif = premiumUser.Money * 2;
                    premiumUser.AddMoney(gif);
                }

                return premiumUser;
            }
            else if (user.UserType == UserType.SuperUser)
            {
                SuperUser superUser = (SuperUser)user;

                if (superUser.Money > 100)
                {
                    decimal percentage = Convert.ToDecimal(0.20);
                    decimal gif = superUser.Money * percentage;
                    superUser.AddMoney(gif);
                }

                return superUser;
            }
            else
            {
                throw new ArgumentException("Invalid user type", nameof(UserType));
            }
        }
    }
}
