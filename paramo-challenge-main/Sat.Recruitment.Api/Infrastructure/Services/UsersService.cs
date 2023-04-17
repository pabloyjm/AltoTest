using System;
using System.IO;

namespace Sat.Recruitment.Api.Services
{
    public partial class UsersService
    {
        private StreamReader ReadUsersFromFile()
        {
            string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
