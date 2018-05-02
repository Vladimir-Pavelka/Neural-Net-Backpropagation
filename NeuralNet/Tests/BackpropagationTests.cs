namespace Tests
{
    using FluentAssertions;
    using NeuralNet;
    using Training;
    using Xunit;

    public class BackpropagationTests
    {
        [Fact]
        public void When_TotalError_Invoked_Then_Result_Is_Correct()
        {
            var totalError = Backpropagation.TotalError(new[] { 0.01, 0.99 }, new[] { 0.75136507, 0.772928465 });

            totalError.Should().BeApproximately(0.298371109, 0.000001);
        }

        [Fact]
        public void When_Training_Iteration_Performed_Then_TotalError_Decreases()
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
            var initialError = Backpropagation.TotalError(net, trainingSet);

            Backpropagation.Train(net, new TrainingConfiguration(0.01, 2000, 0), trainingSet);

            var finalError = Backpropagation.TotalError(net, trainingSet);

            finalError.Should().BeLessThan(initialError);
        }
    }
}