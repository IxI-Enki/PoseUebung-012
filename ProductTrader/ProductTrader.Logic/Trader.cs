namespace ProductTrader.Logic;

public class Trader : ITrader
{
        #region FIELDS

        /// <summary>
        /// Tracks whether the trader has bought a product.
        /// </summary>
        private bool _hasBought = false;

        /// <summary>
        /// Stores the value at which the product was bought.
        /// </summary>
        private double _buyValue = 0;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the name of the trader.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the total profit made by the trader in the past, excluding the current profit.
        /// </summary>
        public double PastProfit { get; private set; }

        /// <summary>
        /// Gets the current retail value of the product the trader is holding.
        /// </summary>
        public double RetailValue { get; private set; }

        /// <summary>
        /// Gets the current profit of the trader, considering both past profits and the difference between the buying and selling prices.
        /// </summary>
        public double CurrentProfit { get; private set; }

        /// <summary>
        /// Gets the value at which the product was bought.
        /// </summary>
        public double PurchaseValue { get; private set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Trader"/> class.
        /// </summary>
        /// <param name="name">The name of the trader.</param>
        /// <param name="purchaseValue">The initial purchase value of the product.</param>
        /// <param name="retailValue">The retail value of the product.</param>
        public Trader(string name , double purchaseValue , double retailValue)
        {
                Name = name;
                PurchaseValue = purchaseValue;
                RetailValue = retailValue;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Updates the trader's state based on the latest product information.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event arguments containing the product information.</param>
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

        /// <summary>
        /// Prints the current profit of the trader, colored green for positive profit, red for negative profit, and white otherwise.
        /// </summary>
        private void PrintProfit()
        {
                if (CurrentProfit > 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                else if (CurrentProfit < 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{this}");
                Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Simulates buying a product. Updates the trader's state accordingly.
        /// </summary>
        /// <param name="product">The product information received in the event arguments.</param>
        private void Buy(ProductEventArgs product)
        {
                CurrentProfit = PastProfit;
                CurrentProfit += _hasBought ? _buyValue - product.Value : 0;
        }

        /// <summary>
        /// Simulates holding a product. Updates the trader's state accordingly.
        /// </summary>
        /// <param name="product">The product information received in the event arguments.</param>
        private void Hold(ProductEventArgs product)
        {
                _hasBought = true;
                _buyValue = product.Value;
                CurrentProfit = PastProfit;
        }

        /// <summary>
        /// Simulates selling a product. Updates the trader's state accordingly.
        /// </summary>
        /// <param name="product">The product information received in the event arguments.</param>
        private void Sell(ProductEventArgs product)
        {
                PastProfit += product.Value - _buyValue;
                _hasBought = false;
                _buyValue = 0.0;
                CurrentProfit = PastProfit;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Returns a string representation of the Trader object.
        /// </summary>
        /// <returns>A string containing the trader's name, current profit, purchase value, and retail value.</returns>
        public override string ToString() => $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";

        #endregion
}