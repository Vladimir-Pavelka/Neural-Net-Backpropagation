namespace Training
{
    using System;
    using System.Linq;
    using NeuralNet;

    public class ErrorFunctions
    {
        public static double TrainingSampleError(double[] expected, double[] actual)
            => expected.Zip(actual, (e, a) => e - a)
                //.Select(diff => 0.5 * diff * diff)
                .Select(Math.Abs)
                .Sum();

        public static double TotalError(NeuralNetwork net, TrainingSet trainingSamples)
        {
            var netOutputs = trainingSamples.Select(x => net.ForwardPass(x.Input));
            var expectedOutpus = trainingSamples.Select(x => x.Ideal);
            var trainingSampleErrors = expectedOutpus.Zip(netOutputs, TrainingSampleError);
            return trainingSampleErrors.Sum() / trainingSamples.Count;
        }
    }
}