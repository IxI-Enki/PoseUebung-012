namespace ProductTrader.Logic;

public class ProductEventArgs : EventArgs
{
        #region CONSTRUCTORS
        public ProductEventArgs(string name , double value , double minValue , double maxValue)
        {
                Name = name;
                Value = value;
                MinValue = minValue;
                MaxValue = maxValue;
        }
        #endregion

        #region PROPERTIES
        public string Name { get; }
        public double Value { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        #endregion
}