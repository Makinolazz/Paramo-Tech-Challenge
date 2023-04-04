using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Test.Fake;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public async void Create_Valid_User_Returns_Success_True()
        {
            var userController = new UsersController();            
            var result = await userController.CreateUser(FakeRequestCreator.GetValidUserRequest());

            Assert.True(result.IsSuccess);
            Assert.Equal(SuccessMessagesHelper.UserCreatedMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Duplicated_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetDuplicatedUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.DuplicatedUserMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Null_Name_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetNullNameUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.NullNameMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Null_Email_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetNullEmailUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.NullEmailMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Invalid_Email_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetInvalidEmailUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.InvalidEmailMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Null_Address_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetNullAddressUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.NullAddressMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Null_Phone_User_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetNullPhoneUserRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.NullPhoneMessage(), result.Errors);
        }

        [Fact]
        public async void Create_Invalid_User_Type_Returns_Success_False()
        {
            var userController = new UsersController();
            var result = await userController.CreateUser(FakeRequestCreator.GetInvalidUserTypeRequest());

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessagesHelper.InvalidUserTypeMessage(), result.Errors);
        }
    }
}
