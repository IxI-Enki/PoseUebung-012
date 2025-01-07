namespace ProductTrader.Logic
{
    public class Product : IProduct
    {
        private const int UpdateTime = 500;
        #region fields
        private DateTime _startTime;
        #endregion fields

        #region properties
        public string Name { get; }
        public double MinValue { get; private set; }
        public double Value { get; private set; }
        public double MaxValue { get; private set; }
        #endregion properties

        #region events
        public event EventHandler? Changed;
        #endregion events

        #region constructors
        public Product(string name, double startValue)
        {
            throw new NotImplementedException();
        }
        #endregion constructors

        #region methods
        public void Start()
        {
            throw new NotImplementedException();
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        }
        #endregion methods
    }
}