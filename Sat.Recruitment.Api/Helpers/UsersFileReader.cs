using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Helpers
{
    public class UsersFileReader
    {
        private readonly List<User> _users = new List<User>();
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public async Task<List<User>> GetFileUsers()
        {
            var reader = ReadUsersFromFile();
            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();
            return _users;
        }
    }
}
