namespace VendingMachineApp {

class Program{
    static void Main(){
        
   var vendingMachine = new VendingMachine();

        vendingMachine.DisplayProducts();
        vendingMachine.InsertCoin("nickel",40);
        vendingMachine.SelectProduct(0); // Soda
        vendingMachine.Dispense();
        vendingMachine.ReturnChange();
        vendingMachine.DisplayProducts();
    }
}
}