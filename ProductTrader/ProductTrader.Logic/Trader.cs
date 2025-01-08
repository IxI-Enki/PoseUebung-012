namespace ProductTrader.Logic;

public class Trader : ITrader
{
        #region FIELDS
        private bool _hasBought = false;
        private double _buyValue = 0;
        #endregion 

        #region PROPERTIES
        public string Name { get; }
        public double PastProfit { get; private set; }
        public double RetailValue { get; private set; }
        public double CurrentProfit { get; private set; }
        public double PurchaseValue { get; private set; }
        #endregion

        #region CONSTRUCTORS
        public Trader(string name , double purchaseValue , double retailValue)
        {
                Name = name;
                PurchaseValue = purchaseValue;
                RetailValue = retailValue;
        }
        #endregion

        #region METHODS
        public void UpdateProduct(object sender , EventArgs e)
        {
                if (e is ProductEventArgs product)
                {
                        if (_hasBought && product.Value >= RetailValue)
                                Sell(product);
                        else if (_hasBought == false && product.Value >= PurchaseValue)
                                Hold(product);
                        else
                                Buy(product);

                        PrintProfit();
                }
        }

        private void PrintProfit()
        {
                if (CurrentProfit > 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                else if (CurrentProfit < 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{this}");
                Console.ForegroundColor = ConsoleColor.White;
        }

        private void Buy(ProductEventArgs product)
        {
                CurrentProfit = PastProfit;
                CurrentProfit += _hasBought ? _buyValue - product.Value : 0;
        }

        private void Hold(ProductEventArgs product)
        {
                _hasBought = true;
                _buyValue = product.Value;
                CurrentProfit = PastProfit;
        }

        private void Sell(ProductEventArgs product)
        {
                PastProfit += product.Value - _buyValue;
                _hasBought = false;
                _buyValue = 0.0;
                CurrentProfit = PastProfit;
        }
        #endregion

        #region OVERRIDES
        public override string ToString() => $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        #endregion
}
