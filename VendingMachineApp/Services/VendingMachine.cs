using System.Diagnostics;
using VendingMachineApp.Enums;
using VendingMachineApp.Models;

namespace VendingMachineApp
{
    public class VendingMachine
    {

        public List<Product>? Products { get; }
        public decimal? Balance { get; set; }
        public Product? SelectedProduct { get; set; }
        public IPayment PaymentStrategy { get; set; }
        private readonly ICoinIdentifier coinIdentifier;

        private IVendingState _state;
        private static List<Product> CreateDefaultProducts()
        {
            return new List<Product>
        {
            new Product("Soda", 1.50m, 10),
            new Product("Chips", 1.00m, 10),
            new Product("Candy", 0.65m, 10)
        };
        }
        private readonly Dictionary<CoinType, decimal> coinValues = new()
        {
            {CoinType.Nickel, 0.05m},
            {CoinType.Dime, 0.10m},
            {CoinType.Quarter, 0.25m}
        };

        public VendingMachine()
        {
            Products = CreateDefaultProducts();
            _state = new IdleState();
            coinIdentifier = new CoinIdentifier();
            PaymentStrategy = new CashPayment();
            Balance = 0;
        }




        public void SetState(IVendingState state)
        {
            _state = state;
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Available Products:");
            for (int i = 0; i < Products?.Count; i++)
            {
                var p = Products[i];
                Console.WriteLine($"{i}: {p.Name} - ${p.Price} (Stock: {p.Quantity})");
            }
        }

        public void InsertCoin(string coinType, int quantity)
        {
            CoinType coin = coinIdentifier.Identify(coinType);

            if (coinValues.ContainsKey(coin))
            {
                decimal currentAmount = quantity * coinValues[coin];
                _state.InsertCoin(this, currentAmount);

            }
            else
            {
                Console.WriteLine("Coin returned: invalid coin(s)");
            }


        }

        public void SelectProduct(int index) => _state.SelectProduct(this, index);
        public void Dispense() => _state.Dispense(this);

        public void ReturnChange()
        {

            Console.WriteLine($"Returning change: ${Balance}");
            Balance = 0;
            SetState(new IdleState());
        }
    }
}