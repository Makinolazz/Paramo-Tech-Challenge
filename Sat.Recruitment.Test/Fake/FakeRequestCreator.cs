using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Test.Fake
{
    public class FakeRequestCreator
    {
        public static CreateUserRequest GetValidUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
        }

        public static CreateUserRequest GetDuplicatedUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
        }
    }
}
