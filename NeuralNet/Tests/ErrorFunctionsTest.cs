namespace Tests
{
    using FluentAssertions;
    using Training;
    using Xunit;

    public class ErrorFunctionsTest
    {
        private const double Precision = 0.000000001;

        [Fact]
        public void When_TotalError_Invoked_Then_Result_Is_Correct()
        {
            var totalError = ErrorFunctions.TotalError(new[] { 0.01, 0.99 }, new[] { 0.75136507, 0.772928465 });

            totalError.Should().BeApproximately(0.298371109, Precision);
        }

        [Fact]
        public void When_Total_Error_Calculated_Then_It_Is_Correct()
        {
            var testObject = NeuralNetTestSetup.GetConfiguredNet();
            var trainingSet = new TrainingSet(new[] { new TrainingSample(new[] { 0.05, 0.10 }, new[] { 0.01, 0.99 }) });

            var totalError = ErrorFunctions.TotalError(testObject, trainingSet);

            totalError.Should().BeApproximately(0.298371109, Precision);
        }
    }
}