namespace Program
{
    using System;
    using NeuralNet;
    using Training;

    public class Program
    {
        public static void Main()
        {
            var net = new NeuralNetwork(2, 2, 1, ActivationFunctions.Sigmoid);
            var trainingSamples = new[]
            {
                new TrainingSample(new[] {0d, 0}, new[] {0d}),
                new TrainingSample(new[] {0d, 1}, new[] {1d}),
                new TrainingSample(new[] {1d, 0}, new[] {1d}),
                new TrainingSample(new[] {1d, 1}, new[] {0d})
            };
            var trainingSet = new TrainingSet(trainingSamples);

            Backpropagation.Train(net, new TrainingConfiguration(0.01, 940, 0), trainingSet);

            Console.ReadKey();
        }
    }
}
