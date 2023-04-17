using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Domain.Interfaces;
using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Api.Services
{
    public class UserValidatorService
    {
        public static string Validate(IUser user)
        {
            var errors = new StringBuilder();

            if(string.IsNullOrWhiteSpace(user.Name))
            {
                errors.AppendLine("The name is required");
            }

            if(string.IsNullOrWhiteSpace(user.Email))
            {
                errors.AppendLine("The email is required");
            } else if(!IsValidEmail(user.Email))
            {
                errors.AppendLine("The email address is not valid");
            }

            if(string.IsNullOrWhiteSpace(user.Address))
            {
                errors.AppendLine("The address is required");
            }

            if(string.IsNullOrWhiteSpace(user.Phone))
            {
                errors.AppendLine("The phone is required");
            } else if(!IsValidPhoneNumber(user.Phone))
            {
                errors.AppendLine("The phone number is not valid");
            }

            if(user.UserType == UserType.Unknown)
            {
                errors.AppendLine("User type is required");
            }

            return errors.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return address.Address == email;
            } catch
            {
                return false;
            }
        }

        private static bool IsValidPhoneNumber(string phone)
        { 
            return Regex.Match(phone, @"^\+?\d{10,}$").Success; 
        }
    }
}
