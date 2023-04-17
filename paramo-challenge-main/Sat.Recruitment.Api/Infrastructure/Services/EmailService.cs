using System;

namespace Sat.Recruitment.Api.Infrastructure.Services
{
    public static class EmailService
    {
        internal static void NormalizeEmail(string email)
        {
            //Normalize email
            string[] aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            int atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
