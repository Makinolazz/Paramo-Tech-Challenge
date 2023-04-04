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

        public static CreateUserRequest GetNullNameUserRequest()
        {
            return new CreateUserRequest
            {
                Name = null,
                Email = "scrappyCoco@gmail.com",
                Address = "Av. Nazca",
                Phone = "+54 1122334455",
                UserType = "Normal",
                Money = 99
            };
        }

        public static CreateUserRequest GetNullEmailUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "ScrappyCoco",
                Email = null,
                Address = "Av. Nazca",
                Phone = "+54 1122334455",
                UserType = "Normal",
                Money = 88
            };
        }

        public static CreateUserRequest GetInvalidEmailUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "ScrappyCoco",
                Email = "scrappy-coco.com",
                Address = "Av. Nazca",
                Phone = "+54 1122334455",
                UserType = "Normal",
                Money = 77
            };
        }

        public static CreateUserRequest GetNullAddressUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "ScrappyCoco",
                Email = "scrappy@coco.com",
                Address = null,
                Phone = "+54 1122334455",
                UserType = "Normal",
                Money = 150
            };
        }

        public static CreateUserRequest GetNullPhoneUserRequest()
        {
            return new CreateUserRequest
            {
                Name = "ScrappyCoco",
                Email = "scrappy@coco.com",
                Address = "Av. Nazca",
                Phone = null,
                UserType = "Normal",
                Money = 200
            };
        }

        public static CreateUserRequest GetInvalidUserTypeRequest()
        {
            return new CreateUserRequest
            {
                Name = "ScrappyCoco",
                Email = "scrappy@coco.com",
                Address = "Av. Nazca",
                Phone = "+54 1122334455",
                UserType = "MegaUser",
                Money = 500
            };
        }
    }
}
