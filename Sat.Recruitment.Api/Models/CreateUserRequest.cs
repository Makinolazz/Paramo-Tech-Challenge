using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Sat.Recruitment.Api.Models
{
    public class CreateUserRequest : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get ; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }

        public bool IsRequestValid()
        {
            if (Name == null)
            {
                throw new Exception(ErrorMessagesHelper.NullNameMessage());
            }
            if (Email == null)
            {
                throw new Exception(ErrorMessagesHelper.NullEmailMessage());
            }
            if (Address == null)
            {
                throw new Exception(ErrorMessagesHelper.NullAddressMessage());
            }
            if (Phone == null)
            {                
                throw new Exception(ErrorMessagesHelper.NullPhoneMessage());
            }
            return true;    
        }
    }
}
