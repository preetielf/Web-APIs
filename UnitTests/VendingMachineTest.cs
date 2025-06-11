using VendingMachineApp;

public class VendingMachineStateTests
    {
        [Fact]
        public void InsertMoney_ShouldIncreaseBalance()
        {
            var machine = new VendingMachine();
            machine.InsertCoin("quarter",4);

            Assert.Equal(1.00m, machine.Balance);
        }

         //[Fact]
        // public void SelectValidProduct_ShouldSetSelectedProduct()
        // {
        //     var machine = new VendingMachine();
        //     machine.InsertCoin("quarter",5);
        //     machine.SelectProduct(0);

        //     Assert.NotNull(machine.SelectedProduct);
        // }
        [Fact]
        public void SelectInvalidProduct_ShouldNotSetSelectedProduct()
        {
            var machine = new VendingMachine();
            machine.InsertCoin("quarter",5);
            machine.SelectProduct(99); // invalid index

            Assert.Null(machine.SelectedProduct);
        }

        [Fact]
        public void VendingMachine_ShouldUseCashPaymentByDefault()
        {
            var machine = new VendingMachine();

            Assert.IsType<CashPayment>(machine.PaymentStrategy);
        }
    }

