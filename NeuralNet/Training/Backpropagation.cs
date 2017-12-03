namespace Training
{
    using System.Linq;

    public class Backpropagation
    {
        public static double TotalError(double[] ideal, double[] actual)
            => ideal.Zip(actual, (i, a) => i - a)
                .Select(diff => 0.5 * diff * diff)
                .Sum();
    }
}