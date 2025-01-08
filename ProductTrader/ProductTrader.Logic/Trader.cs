namespace ProductTrader.Logic;

public class Trader : ITrader
{
        #region FIELDS
        private bool _hasBought = false;
        private double _buyValue = 0;
        #endregion 

        #region PROPERTIES
        public string Name { get; }
        public double PurchaseValue { get; private set; }
        public double PastProfit
        {
                get;
                private set;
        }
        public double CurrentProfit
        {
                get;
                private set;
        }
        public double RetailValue { get; private set; }
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
                        {
                                PastProfit += product.Value - _buyValue;
                                _hasBought = false;
                                _buyValue = 0.0;
                                CurrentProfit = PastProfit;
                        }
                        else if (_hasBought == false && product.Value >= PurchaseValue)
                        {
                                _hasBought = true;
                                _buyValue = product.Value;
                                CurrentProfit = PastProfit;
                        }
                        else
                        {
                                CurrentProfit = PastProfit;
                                CurrentProfit += _hasBought ? _buyValue - product.Value : 0;
                        }
                        if (CurrentProfit > 0)
                        {
                                ;
                        }
                        Console.WriteLine($"{this}");
                }
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
                return $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        }
        #endregion
}
