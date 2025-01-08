namespace ProductTrader.Logic;

public class Product : IProduct
{
        #region CONSTANTS
        private const int UpdateTime = 500;
        #endregion 

        #region FIELDS
        private DateTime _startTime;
        #endregion 

        #region PROPERTIES
        public string Name { get; }
        public double MinValue { get; private set; }
        public double Value { get; private set; }
        public double MaxValue { get; private set; }
        #endregion

        #region EVENTS
        public event EventHandler? Changed;
        #endregion

        #region CONSTRUCTORS
        public Product(string name , double startValue)
        {
                throw new NotImplementedException();
        }
        #endregion 

        #region METHODS
        public void Start()
        {
                throw new NotImplementedException();
        }
        public void Stop()
        {
                throw new NotImplementedException();
        }
        #endregion

        #region OVERRIDES
        public override string ToString()
        {
                return $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        }
        #endregion
}