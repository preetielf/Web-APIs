using VendingMachineApp;

public interface IVendingState
{
    public void InsertCoin(VendingMachine vm, decimal amount);
    public void SelectProduct(VendingMachine vm, int index);
    public void Dispense(VendingMachine vm);
}