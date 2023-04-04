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
        public async Task CreateNewUser(IUser request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = new MailAddress(request.Email.Trim()).Address,
                Address = request.Address,
                Phone = request.Phone,
                UserType = request.UserType,
                Money = CalculateMoney(request.UserType, request.Money)
            };

            await ValidateDuplicatedUser(newUser);
        }

        private async Task ValidateDuplicatedUser(User newUser)
        {
            var users = await new UsersFileReader().GetJsonFileUsers();
            if (users.Any(u => u.Name.ToUpper().Contains(newUser.Name.ToUpper())
                || u.Email.ToUpper().Contains(newUser.Email.ToUpper())
                || u.Address.ToUpper().Contains(newUser.Address.ToUpper())
                || u.Phone.Contains(newUser.Phone)))
            {
                throw new Exception(ErrorMessagesHelper.DuplicatedUserMessage());
            }            
        }

        private decimal CalculateMoney(string userType, decimal money)
        {
            switch (userType.ToUpper()) 
            {
                case UserTypeConstants.NORMAL_USER:
                    return CalculateMoneyHelper.CalculateNormalUserMoney(money);
                case UserTypeConstants.SUPER_USER:
                    return CalculateMoneyHelper.CalculateSuperUserMoney(money);
                case UserTypeConstants.PREMIUM_USER:
                    return CalculateMoneyHelper.CalculatePremiumUserMoney(money);
                default:
                    return money;
            }
        }
    }
}
