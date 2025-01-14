﻿namespace ProductTrader.Logic;

public class Product : IProduct
{
        #region CONSTANTS

        /// <summary>
        /// The update interval in milliseconds for the product value simulation.
        /// </summary>
        private const int UPDATETIME = 200; // Milliseconds

        /// <summary>
        /// A static random number generator for product value fluctuations. 
        /// Uses the current UTC millisecond as a seed for better randomness.
        /// </summary>
        private static readonly Random RANDOM = new( DateTime.UtcNow.Millisecond );

        #endregion

        #region FIELDS

        /// <summary>
        /// The time at which the product simulation was started.
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// A flag indicating whether the product value simulation is currently running.
        /// </summary>
        private volatile bool _isRunning = false;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the current value of the product.
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Gets the minimum value reached by the product since its creation.
        /// </summary>
        public double MinValue { get; private set; }

        /// <summary>
        /// Gets the maximum value reached by the product since its creation.
        /// </summary>
        public double MaxValue { get; private set; }

        #endregion

        #region EVENTS

        /// <summary>
        /// Event that is raised when the product's value changes. 
        /// Subscribers to this event can receive notifications about value updates.
        /// </summary>
        public event EventHandler? Changed;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="startValue">The initial value of the product. Must be non-negative.</param>
        public Product( string name , double startValue )
        {
                Name = name;

                double value = startValue >= 0 ? startValue : 0.0;
                Value = value;
                MaxValue = value;
                MinValue = value;
        }

        #endregion

        #region METHODSa

        /// <summary>
        /// Starts simulating product value fluctuations.
        /// </summary>
        public void Start( )
        {
                if( !_isRunning )
                {
                        _isRunning = true;

                        Thread thread = new( Run ) { IsBackground = true };

                        _startTime = DateTime.UtcNow;

                        thread.Start( );
                }
        }

        /// <summary>
        /// The core loop that continuously updates the product value and raises the Changed event.
        /// </summary>
        private void Run( )
        {
                while( _isRunning )
                {
                        Thread.Sleep( UPDATETIME );

                        double valueChange = CalculateChangedValue( RANDOM.Next( 0 , 50 ) / 1000.0 );
                        Value += valueChange;

                        if( Value < MinValue )
                                MinValue = Value;
                        else if( Value > MaxValue )
                                MaxValue = Value;

                        Changed?.Invoke( this , new ProductEventArgs( Name , Value , MinValue , MaxValue ) );
                }
        }

        /// <summary>
        /// Calculates a random value change between -5% and +5% of the current product value.
        /// </summary>
        /// <param name="valueChange">A random number between 0 and 0.05 generated by the internal random number generator.</param>
        /// <returns>A random value change to be applied to the product value.</returns>
        private double CalculateChangedValue( double valueChange )
        {
                int plusOrMinus = RANDOM.Next( 0 , 2 );
                double result;

                if( plusOrMinus == 0 )
                        result = Value * valueChange * -1.0;
                else
                        result = Value * valueChange;

                return result;
        }

        /// <summary>
        /// Stops simulating product value fluctuations.
        /// </summary>
        public void Stop( ) => _isRunning = false;

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Returns a string representation of the Product object.
        /// </summary>
        /// <returns>A string containing the product's name, current value, minimum value, maximum value, and the elapsed time since the simulation started.</returns>
        public override string ToString( ) => $"{Name,-20} {Value,10:f}€ {MinValue,10:f}€ {MaxValue,10:f}€  Time:{( DateTime.UtcNow - _startTime ).TotalSeconds:f} sec";

        #endregion
}