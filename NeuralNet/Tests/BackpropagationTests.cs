namespace Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using NeuralNet;
    using Training;
    using Xunit;

    public class BackpropagationTests
    {
        private const double Precision = 0.000000001;

        [Fact]
        public void When_Training_Iteration_Performed_Then_TotalError_Decreases()
        {
            var net = new NeuralNetwork(2, 2, 1, ActivationFunctions.Sigmoid);
            var trainingSet = PopularProblems.Xor;

            var trainingErrors = new List<double>();
            Backpropagation.Train(net, new TrainingConfiguration(0.1, 10000, 0), trainingSet, trainingErrors.Add);

            trainingErrors.Should().BeInDescendingOrder();
        }

        [Theory]
        [InlineData(1, 0.291027924)]
        //[InlineData(10000, 0.0000351085)]
        public void When_Then(int iterationsCount, double expectedError)
        {
            var net = NeuralNetTestSetup.GetConfiguredNet();
            var trainingSet = new TrainingSet(new[] { new TrainingSample(new[] { 0.05, 0.10 }, new[] { 0.01, 0.99 }) });

            Backpropagation.Train(net, new TrainingConfiguration(0.5, iterationsCount, 0), trainingSet, _ => { });
            var actualError = ErrorFunctions.TotalError(net, trainingSet);

            actualError.Should().BeApproximately(expectedError, Precision);
        }
    }
}