using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Constants;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sat.Recruitment.Api.DataManagers
{
    public class UserDataManager
    {
        private Result _result;
        public UserDataManager(Result result)
        {
            _result = result;
        }

        public async Task CreateNewUser(CreateUserRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = new MailAddress(request.Email.Trim()).Address,
                Address = request.Address,
                Phone = request.Phone,
                UserType = request.UserType,
                Money = CalculateMoney(request.UserType, decimal.Parse(request.Money))
            };

            await ValidateDuplicatedUser(newUser);
        }

        private async Task ValidateDuplicatedUser(User newUser)
        {
            var users = await new UsersFileReader().GetFileUsers();
            if (users.Any(u => u.Name.Contains(newUser.Name)
                || u.Email.Contains(newUser.Email)
                || u.Address.Contains(newUser.Address)
                || u.Phone.Contains(newUser.Phone)))
            {
                throw new Exception(ErrorMessagesHelper.DuplicatedUserMessage());
            }            
        }

        private decimal CalculateMoney(string userType, decimal money)
        {
            switch (userType) 
            {
                case "Normal":
                    return CalculateMoneyHelper.CalculateNormalUserMoney(money);
                case "SuperUser":
                    return CalculateMoneyHelper.CalculateSuperUserMoney(money);
                case "Premium":
                    return CalculateMoneyHelper.CalculatePremiumUserMoney(money);
                default:
                    return money;
            }
        }
    }
}
