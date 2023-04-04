using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
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
        [Phone]
        public string Phone { get; set; }
        public string UserType { get; set; }
        [Range(0.0, Double.MaxValue)]
        public decimal Money { get; set; }

        public bool IsRequestValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception(ErrorMessagesHelper.NullNameMessage());
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception(ErrorMessagesHelper.NullEmailMessage());
            }
            if (string.IsNullOrEmpty(Address))
            {
                throw new Exception(ErrorMessagesHelper.NullAddressMessage());
            }
            if (string.IsNullOrEmpty(Phone))
            {                
                throw new Exception(ErrorMessagesHelper.NullPhoneMessage());
            }
            return true;    
        }
    }
}
