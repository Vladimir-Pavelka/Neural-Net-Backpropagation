namespace Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NeuralNet;
    using Xunit;

    public class NeuralNetworkTests
    {
        [Fact]
        public void When_Forward_Pass_Invoked_Then_Output_Is_Calculated_Correctly()
        {
            var testObject = new NeuralNetwork(2, 2, 2);
            testObject.HiddenLayer.First().Weights[0] = 0.15;
            testObject.HiddenLayer.First().Weights[1] = 0.20;
            testObject.HiddenLayer.First().Bias = 0.35;
            testObject.HiddenLayer.Last().Weights[0] = 0.25;
            testObject.HiddenLayer.Last().Weights[1] = 0.30;
            testObject.HiddenLayer.Last().Bias = 0.35;

            testObject.OutputLayer.First().Weights[0] = 0.40;
            testObject.OutputLayer.First().Weights[1] = 0.45;
            testObject.OutputLayer.First().Bias = 0.60;
            testObject.OutputLayer.Last().Weights[0] = 0.50;
            testObject.OutputLayer.Last().Weights[1] = 0.55;
            testObject.OutputLayer.Last().Bias = 0.60;

            var output = testObject.ForwardPass(new[] { 0.05, 0.10 });

            output.Should().Equal(new[] { 0.75136507, 0.772928465 }, AreEqualApproximately);
        }

        private static bool AreEqualApproximately(double actual, double expected) => Math.Abs(actual - expected) < 0.000001;
    }
}