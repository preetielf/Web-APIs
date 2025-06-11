using VendingMachineApp;

public class IdleState : IVendingState
{
    public void InsertCoin(VendingMachine vm, decimal amount)
    {
        vm.Balance += amount;
        vm.PaymentStrategy.ProcessPayment(amount);
        vm.SetState(new HasMoneyState());
    }

    public void SelectProduct(VendingMachine vm, int index)
    {
        Console.WriteLine("Insert money first.");
    }

    public void Dispense(VendingMachine vm)
    {
        Console.WriteLine("Insert money and select a product first.");
    }
}

public class HasMoneyState : IVendingState
{
    public void InsertCoin(VendingMachine vm, decimal amount)
    {
        vm.Balance += amount;
        vm.PaymentStrategy.ProcessPayment(amount);
    }

    public void SelectProduct(VendingMachine vm, int index)
    {
        if (index < 0 || index >= vm?.Products?.Count)
        {
            Console.WriteLine("Invalid product.");
            return;
        }

        var product = vm?.Products?[index]!;

        if (product.Quantity == 0)
        {
            Console.WriteLine("Out of stock.");
            return;
        }

        if (vm?.Balance < product.Price)
        {
            Console.WriteLine($"Insufficient funds. {product.Name} costs ${product.Price}.");
            return;
        }
      

        vm!.SelectedProduct = product;
        vm.SetState(new DispensingState());

    }
    public void Dispense(VendingMachine vm)
    {
        Console.WriteLine("Select product first.");
    }
}

public class DispensingState : IVendingState
{
    public void Dispense(VendingMachine vm)
    {
        var p = vm.SelectedProduct;
        p!.Quantity--;
        vm.Balance -= p.Price;
        Console.WriteLine($"Dispensing {p.Name}. Remaining balance: ${vm.Balance}");
        vm.SelectedProduct = null;

        vm.SetState(vm.Balance > 0 ? new HasMoneyState() : new IdleState());
       
    }

    public void InsertCoin(VendingMachine vm, decimal amount)
    {
         Console.WriteLine("Currently dispensing. Please wait.");
    }

    public void SelectProduct(VendingMachine vm, int index)
    {
       Console.WriteLine("Already selected. Dispensing in progress.");
    }
}

