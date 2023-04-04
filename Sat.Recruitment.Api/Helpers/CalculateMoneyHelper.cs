using Sat.Recruitment.Api.Constants;

namespace Sat.Recruitment.Api.Helpers
{
    public static class CalculateMoneyHelper
    {
        public static decimal CalculatePremiumUserMoney(decimal money)
        {
            if (money > MoneyCalculationConstants.ONE_HUNDRED_USD_LIMIT)
            {
                return money + (money * MoneyCalculationConstants.PREMIUM_USER_HIGHER_USD100_PERCENTAGE);
            }

            return money;
        }

        public static decimal CalculateSuperUserMoney(decimal money)
        {
            if (money > MoneyCalculationConstants.ONE_HUNDRED_USD_LIMIT)
            {
                return money + (money * MoneyCalculationConstants.SUPER_USER_HIGHER_USD100_PERCENTAGE);
            }

            return money;
        }

        public static decimal CalculateNormalUserMoney(decimal money)
        {
            if (money > MoneyCalculationConstants.ONE_HUNDRED_USD_LIMIT)
            {
                return money + (money * MoneyCalculationConstants.NORMAL_USER_HIGHER_USD100_PERCENTAGE);
            }
            else if (money > MoneyCalculationConstants.TEN_USD_LIMIT)
            {
                return money + (money * MoneyCalculationConstants.NORMAL_USER_LOWER_USD100_PERCENTAGE);
            }

            return money;
        }
    }
}
