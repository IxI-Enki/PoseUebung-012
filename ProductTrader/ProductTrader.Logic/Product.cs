namespace ProductTrader.Logic;

public class Product : IProduct
{
        #region CONSTANTS
        private const int UPDATETIME = 50; // Milliseconds
        private static readonly Random RANDOM = new(DateTime.UtcNow.Millisecond);
        #endregion 

        #region FIELDS
        private DateTime _startTime;
        private volatile bool _isRunning = false;
        #endregion

        #region PROPERTIES
        public string Name { get; }
        public double Value { get; private set; }
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        #endregion

        #region EVENTS
        public event EventHandler? Changed;
        #endregion

        #region CONSTRUCTORS
        public Product(string name , double startValue)
        {
                Name = name;

                double value = startValue >= 0 ? startValue : 0.0;
                Value = value;
                MaxValue = value;
                MinValue = value;
        }
        #endregion 

        #region METHODS
        public void Start()
        {
                if (!_isRunning)
                {
                        _isRunning = true;

                        Thread thread = new(Run) { IsBackground = true };

                        _startTime = DateTime.UtcNow;

                        thread.Start();
                }
        }

        private void Run()
        {
                double valueChange = 0.0;

                while (_isRunning)
                {
                        Thread.Sleep(UPDATETIME);

                        valueChange = CalculateChangedValue(RANDOM.Next(0 , 50) / 1000.0);
                        Value += valueChange;

                        if (Value < MinValue)
                                MinValue = Value;
                        else if (Value > MaxValue)
                                MaxValue = Value;

                        Changed?.Invoke(this , new ProductEventArgs(Name , Value , MinValue , MaxValue));
                }
        }

        private double CalculateChangedValue(double valueChange)
        {
                int plusOrMinus = RANDOM.Next(0 , 2);
                double result;

                if (plusOrMinus == 0)
                        result = Value * valueChange * -1.0;
                else
                        result = Value * valueChange;

                return result;
        }

        public void Stop() => _isRunning = false;
        #endregion

        #region OVERRIDES
        public override string ToString() => $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        #endregion
}