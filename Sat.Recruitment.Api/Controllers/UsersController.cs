using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.DataManagers;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(CreateUserRequest request)
        {
            var result = new Result();
            try
            {                
                if (request.IsRequestValid())
                {
                    var userDataManager = new UserDataManager(result);
                    await userDataManager.CreateNewUser(request);
                    result.IsSuccess = true;
                    result.Errors = SuccessMessagesHelper.UserCreatedMessage();
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Errors = e.Message;
            }
            return result;
        }
    }    
}
