namespace Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class NeuralNetworkTests
    {
        private const double Precision = 0.000000001;

        [Fact]
        public void When_Forward_Pass_Invoked_Then_Output_Is_Calculated_Correctly()
        {
            var testObject = NeuralNetTestSetup.GetConfiguredNet();

            var output = testObject.ForwardPass(new[] { 0.05, 0.10 });

            output.Should().Equal(new[] { 0.75136507, 0.772928465 }, AreEqualApproximately);
        }

        private static bool AreEqualApproximately(double actual, double expected) => Math.Abs(actual - expected) < Precision;
    }
}