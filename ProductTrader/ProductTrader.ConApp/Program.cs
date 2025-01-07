namespace ProductTrader.ConApp
{
        internal class Program
        {
                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                static void Main(/*string[] args*/)
                {
                }

                /// <summary>
                /// Prints the header information when the product changes.
                /// </summary>
                /// <param name="sender">The source of the event.</param>
                /// <param name="e">The event data.</param>
                static void PrintHeader(object sender , EventArgs e)
                {
                        Console.Clear();
                        Console.WriteLine("Product-Trader");
                        Console.WriteLine();
                }
        }
}
