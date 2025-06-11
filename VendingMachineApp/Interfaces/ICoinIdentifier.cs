using VendingMachineApp.Enums;

public interface ICoinIdentifier
    {
        CoinType Identify(string input);
    }