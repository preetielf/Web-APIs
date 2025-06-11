using VendingMachineApp.Enums;

public class CoinIdentifier : ICoinIdentifier
    {
        public CoinType Identify(string input)
        {
            return input.ToLower() switch
            {
                "nickel" => CoinType.Nickel,
                "dime" => CoinType.Dime,
                "quarter" => CoinType.Quarter,
                "penny" => CoinType.Penny,
                _ => CoinType.Unknown
            };
        }
    }