namespace ProductTrader.Logic
{
    public class Trader : ITrader
    {
        #region fields
        private bool _hasBought = false;
        private double _buyValue = 0;
        #endregion fields

        #region properties
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
        #endregion properties
        public Trader(string name, double purchaseValue, double retailValue)
        {
            throw new NotImplementedException();
        }

        #region methods
        public void UpdateProduct(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{Name,-20} {CurrentProfit,10:f} EUR {PurchaseValue,10:f} EUR {RetailValue,10:f} EUR";
        }
        #endregion methods
    }
}
