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
                throw new NotImplementedException();
        }
        #endregion

        #region METHODS
        public void UpdateProduct(object sender , EventArgs eventArgs)
        {
                throw new NotImplementedException();
        }
        #endregion

        #region OVERRIDES
        public override string ToString()
        {
                return $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        }
        #endregion
}
