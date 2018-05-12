namespace Training
{
    using System;
    using System.Linq;
    using NeuralNet;

    public class ErrorFunctions
    {
        public static double TotalError(double[] ideal, double[] actual)
        => ideal.Zip(actual, (i, a) => i - a)
            .Select(diff => 0.5 * diff * diff)
            .Sum();
        //=> ideal.Zip(actual, (i, a) => Math.Abs(i - a)).Sum() / ideal.Length;

        public static double TotalError(NeuralNetwork net, TrainingSet set)
        {
            var netOutputs = set.Select(x => net.ForwardPass(x.Input));
            var trainingSampleErrors = set.Select(x => x.Ideal).Zip(netOutputs, TotalError);
            return trainingSampleErrors.Sum() / set.Count;
        }
    }
}