namespace ProductTrader.Logic;

/// <summary>
/// Initializes a new instance of the <see cref="ProductEventArgs"/> class.
/// </summary>
/// <param name="name">The name of the product.</param>
/// <param name="value">The current value of the product.</param>
/// <param name="minValue">The minimum allowed value for the product.</param>
/// <param name="maxValue">The maximum allowed value for the product.</param>
public class ProductEventArgs( string name , double value , double minValue , double maxValue ) : EventArgs
{
        #region PROPERTIES

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the current value of the product.
        /// </summary>
        public double Value { get; } = value;

        /// <summary>
        /// Gets the minimum allowed value for the product.
        /// </summary>
        public double MinValue { get; } = minValue;

        /// <summary>
        /// Gets the maximum allowed value for the product.
        /// </summary>
        public double MaxValue { get; } = maxValue;

        #endregion
}