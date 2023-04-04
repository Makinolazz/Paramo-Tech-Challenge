namespace Sat.Recruitment.Api.Helpers
{
    public static class ErrorMessagesHelper
    {
        public static string DuplicatedUserMessage()
        {
            return "The user is duplicated";
        }

        public static string NullNameMessage()
        {
            return "The name is required";
        }

        public static string NullEmailMessage()
        {
            return "The email is required";
        }

        public static string NullAddressMessage()
        {
            return "The address is required";
        }

        public static string NullPhoneMessage()
        {
            return "The phone is required";
        }
    }
}
